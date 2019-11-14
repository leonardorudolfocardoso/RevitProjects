using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

namespace ImportLevel
{
    class ImportLevel
    {
        #region Properties
        UIApplication _uiapp;
        UIDocument _uidoc;
        Application _app;
        Document _doc;
        Document _linkdoc;
        List<Level> _linklevels;
        List<Level> _doclevels;

        private UIApplication uiApp { get => _uiapp; set => _uiapp = value; }
        private UIDocument uiDoc { get => _uidoc; set => _uidoc = value; }
        private Application App { get => _app; set => _app = value; }
        private Document Doc { get => _doc; set => _doc = value; }
        private Document linkDoc { get => _linkdoc; set => _linkdoc = value; }
        private List<Level> linkLevels { get => _linklevels; set => _linklevels = value; }
        private List<Level> docLevels { get => _doclevels; set => _doclevels = value; }
        #endregion
        #region Constructors
        public ImportLevel(
            UIApplication uiapp, 
            UIDocument uidoc, 
            Application app, 
            Document doc)
        {
            this.uiApp = uiapp;
            this.uiDoc = uidoc;
            this.App = app;
            this.Doc = doc;
        }
        #endregion
        #region Methods
        public bool Run()
        {
            if (!this.select_link_doc())
            {
                return false;
            }
            this.docLevels = this.collect_levels(this.Doc);
            if (!this.select_levels(this.linkDoc))
            {
                return false;
            }
            this.delete_existing_levels();
            this.create_levels();
            return true;
        }

        private void create_levels()
        {
            Transaction transaction = new Transaction(this.Doc, "Criar níveis");
            transaction.Start();
            foreach (Level level in this.linkLevels)
            {
                Level tempLevel = Level.Create(this.Doc, level.Elevation);
                tempLevel.Name = level.Name;
                this.docLevels.Add(tempLevel);
            }
            this.Doc.Delete(this.docLevels.First().Id);
            this.docLevels.RemoveAt(0);
            transaction.Commit();
            
        }

        private void delete_existing_levels()
        {
            int cont = -1;
            Transaction transaction = new Transaction(this.Doc, "Deletar níveis existentes");
            transaction.Start();
            do
            {
                cont++;
                this.docLevels[0].Name = "temp" + cont.ToString();
            } 
            while ((from level in this.linkLevels select level.Name)
                   .ToList().Contains("temp" + cont.ToString()));

            for (int i=1; i<this.docLevels.Count; i++)
            {
                this.Doc.Delete(this.docLevels[i].Id);
            }
            transaction.Commit();
        }

        private bool select_link_doc()
        {
            // collecting the links
            var links = new FilteredElementCollector(this.Doc)
                            .OfClass(typeof(RevitLinkInstance))
                            .ToElements();

            // getting the links names
            var link_names = from link in links select link.Name;

            // constructing a dictionary between link names and objects
            var linksDic = link_names.Zip(links, (ln, l) => new { Name = ln, Link = l })
                            .ToDictionary(x => x.Name, x => (x.Link as object));

            SelectFromList selectFromList = new SelectFromList(linksDic, 
                false,
                "Selecione o arquivo Link RVT base.");
            System.Windows.Forms.DialogResult dialogResult = selectFromList.ShowDialog();

            switch (dialogResult)
            {
                case System.Windows.Forms.DialogResult.OK:
                    List<RevitLinkInstance> selectedLink = selectFromList
                                                          .SelectedValues
                                                          .Cast<RevitLinkInstance>()
                                                          .ToList();
                    this.linkDoc = selectedLink.First().GetLinkDocument();
                    return true;
                default:
                    return false;
            }
        }

        private List<Level> collect_levels(Document doc)
        {
            List<Level> levels = new FilteredElementCollector(doc)
                                        .OfCategory(BuiltInCategory.OST_Levels)
                                        .WhereElementIsNotElementType()
                                        .ToElements()
                                        .Cast<Level>()
                                        .ToList();
            levels.OrderBy(level => level.Elevation);
            return levels;
        }

        private bool select_levels(Document doc)
        {
            // getting the levels
            var levels = collect_levels(doc);

            // getting the levels names
            var level_names = from level in levels select level.Name;

            // constructing a dictionary between level names and objects
            var levelsDic = level_names.Zip(levels, (level_name, level) => new { Name = level_name, Level = level })
                                       .ToDictionary(x => x.Name, x => (x.Level as object));

            // form instance and result
            SelectFromList selectFromList = new SelectFromList(levelsDic, true,
                "Selecione os níveis a importar");
            System.Windows.Forms.DialogResult dialogResult = selectFromList.ShowDialog();

            switch (dialogResult)
            {
                case System.Windows.Forms.DialogResult.OK:
                    this.linkLevels = selectFromList.SelectedValues.Cast<Level>().ToList();
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
