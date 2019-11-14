#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace LimparProjeto
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Initializing variables
            // categories dic to recognize choosen categories 
            Dictionary<string, Category> categoriesDic = new Dictionary<string, Category>();
            List<string> categoryNames = new List<string>();

            // categories exception, which are not to be deleted
            List<string> categoryExceptions = new List<string>(){
                "Níveis",
                "Informações do projeto",
                "Materiais",
                "Vistas",
                "Tabelas",
                "Itens de detalhe",
                "Vínculos RVT"
            };

            // populating categoryNames and categoriesDic
            foreach (Category category in doc.Settings.Categories)
            {
                if (category.AllowsBoundParameters)
                {
                    categoryNames.Add(category.Name);
                    categoriesDic.Add(category.Name, category);
                }
            }

            // categories deletion try count to count how many times it was tryed to delete each category
            List<int> zeros = new List<int>(new int[categoriesDic.Count]);
            Dictionary<string, int> categoriesDeletionTryCount = categoriesDic.Keys.Zip(zeros, (k, v) => new { k, v })
                .ToDictionary(x => x.k, x => x.v);

            // sorting categoryNames to show in GUI
            categoryNames.Sort();

            // creating selectFromList instance, show it and get its result
            SelectFromList selectFromList = new SelectFromList(categoryNames);
            System.Windows.Forms.DialogResult dialogResult = selectFromList.ShowDialog();
            List<string> selectedCategories = selectFromList.GetSelectedItems();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // main loop, iterating over categories trying to delete them, until none of them least or max attempt achived
                Category category;
                string categoriesDeleted = "";
                string categoriesNotDeleted = "";
                string categoriesNotToBeDeleted = "";
                while (true) 
                {
                    if (!selectedCategories.Any())
                    {
                        break;
                    }
                    if (categoryExceptions.Contains(selectedCategories[0]))
                    {
                        categoriesNotToBeDeleted += "  -" + selectedCategories[0] + "\n";
                        selectedCategories.RemoveAt(0);
                    }
                    else
                    {
                        categoriesDic.TryGetValue(selectedCategories[0], out category);
                        Transaction t = new Transaction(doc, "Limpar " + category.Name);
                        // trying to delete category elements
                        try
                        {
                            var elementIds = new FilteredElementCollector(doc)
                                                        .OfCategoryId(category.Id)
                                                        .WhereElementIsNotElementType()
                                                        .ToElementIds();
                            if (elementIds.Any())
                            {
                                t.Start();
                                doc.Delete(elementIds);
                                t.Commit();
                                categoriesDeleted += "  -" + category.Name + "\n";
                            }
                            selectedCategories.Remove(category.Name);
                        } 
                        catch (Exception)
                        {
                            // if not possible, handle it
                            t.RollBack();
                            selectedCategories.Remove(category.Name);
                            // adding in the category.Name count
                            categoriesDeletionTryCount[category.Name] += 1;
                            // at least 8 attempts to delete
                            if (categoriesDeletionTryCount[category.Name] < 8){
                                selectedCategories.Add(category.Name);
                            } else
                            {
                                categoriesNotDeleted += "  -" + category.Name + "\n";
                            }

                        }
                    }
                }
                string text = "";
                if (categoriesDeleted.Any())
                {
                    text += "Categorias excluídas: \n" + categoriesDeleted;
                }
                if (categoriesNotDeleted.Any())
                {
                    text += "\nCategorias que não puderam ser excluídas: \n" + categoriesNotDeleted;
                }
                if (categoriesNotToBeDeleted.Any())
                {
                    text += "\nCategorias que não devem ser excluídas: \n" + categoriesNotToBeDeleted;
                }
                ToolExtract toolExtract = new ToolExtract(text);
                toolExtract.ShowDialog();
 
                return Result.Succeeded;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Limpar projeto foi cancelado.", "Limpar projeto");
            }
            return Result.Cancelled;
        }
    }
}
