using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChooseFromListForm
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<string> employees = new List<string> { "Leonardo", "Thalia", "Edna", "Antonio" };

            SelectFromListForm form = new SelectFromListForm(employees, "Title", "Instruction");
            Application.Run(form);

            foreach (string item in form.GetCheckedItems())
            {
                Console.WriteLine(item);
            }
        }
    }
}
