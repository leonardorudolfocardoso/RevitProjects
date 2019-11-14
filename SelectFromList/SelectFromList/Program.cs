using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectFromList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>()
            {
                { "Leonardo", 23 },
                { "Amanda", 22 },
                { "Vitor", 9 }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectFromList(keyValuePairs, false, "Selecione a pessoa", "Selecionar pessoa"));
        }
    }
}
