using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;


namespace RevitAddInTools
{
    public class RevitAddIn
    {
        #region Properties
        private UIControlledApplication A { get; set; }
        public string Name { get; private set; }
        public string ClassName { get; private set; }
        public string PanelName { get; private set; }
        public string TabName { get; private set; }
        public Image Img { get; set; }
        public Image LImg { get; set; }
        #endregion
        #region Constructors
        public RevitAddIn(UIControlledApplication a, string name, string className, string panelName, string tabName) // Class constructor
        {
            this.A = a;
            this.Name = name;
            this.ClassName = className;
            this.PanelName = panelName;
            this.TabName = tabName;
        }

        #endregion

        #region Methods
        public void AssertTabExistence() // Asserts that the RibbonTab with the given name exists
        {
            try
            {
                // tries to create tab with TabName
                this.A.CreateRibbonTab(this.TabName);
            }
            catch (Exception) { } // tab already exists, nothing to do

        }
        public RibbonPanel GetRibbonPanel() // Gets the RibbonPanel with the given name, if it does not exist, creates it
        {
            List<RibbonPanel> ribbonPanels = this.A.GetRibbonPanels(this.TabName);
            foreach (RibbonPanel rp in ribbonPanels) // Iterates over all ribbonPanels to verify if the given name already exists
            {
                if (rp.Name.Equals(this.PanelName))
                {
                    return rp; // If it does exist a RibbonPanel with the given name, returns it
                }
            }
            return this.A.CreateRibbonPanel(this.TabName, this.PanelName); // If no matching RibbonPanel, creates and returns a new one
        }
        public BitmapSource GetImageSource(Image img)
        {
            BitmapImage bmp = new BitmapImage();

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                bmp.BeginInit();

                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = null;
                bmp.StreamSource = ms;

                bmp.EndInit();
            }
            return bmp;
        }
        #endregion
    }


}
