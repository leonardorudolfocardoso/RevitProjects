using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace PrintToPdf
{
    class BfsDocument
    {
        public Document Doc { get; private set; }
        public string Proprietario {get; private set;}
        public string Cnpj { get; private set; }
        public string Obra { get; private set; }
        public string Endereco { get; private set; }
        public string Disciplina { get; private set; }
        public string Numero { get; private set; }
        public int Ano { get; private set; }
        public string Codigo { get; private set; }
        public string Revisao { get; private set; }
        public string Data { get; private set; }
        public string TotalDeFolhas { get; private set; }
        public List<String> ProjectInfos = new List<String>()
        {
            "Nome do cliente",
            "Cadastro do proprietário",
            "Nome do projeto",
            "Endereço do projeto",
            "Sigla da disciplina",
            "Número do projeto",
            "Ano do projeto",
            "Data da emissão do projeto",
            "Total de folhas"
        };

        public BfsDocument(Document doc)
        {
            // get the doc project information
            this.Doc = doc;
            this.GetInformations();
        }

        private void GetInformations()
        {
            // collecting info element
            Element info = new FilteredElementCollector(this.Doc)
                              .OfClass(typeof(ProjectInfo))
                              .ToElements()[0];

            //assign the properties
            try
            {
                this.Proprietario = info.LookupParameter("Nome do cliente").AsString();
                this.Cnpj = info.LookupParameter("Cadastro do proprietário").AsString();
                this.Obra = info.LookupParameter("Nome do projeto").AsString();
                this.Endereco = info.LookupParameter("Endereço do projeto").AsString();
                this.Disciplina = info.LookupParameter("Sigla da disciplina").AsString();
                this.Numero = info.LookupParameter("Número do projeto").AsString();
                this.Ano = info.LookupParameter("Ano do projeto").AsInteger();
                this.Codigo = String.Format("{0}-{1}-{2}", this.Numero, this.Ano, this.Disciplina);
                this.Revisao = (new FilteredElementCollector(this.Doc)
                                   .OfClass(typeof(Revision))
                                   .ToElements()[0] as Revision).RevisionNumber;
                this.Data = info.LookupParameter("Data de emissão do projeto").AsString();
                this.TotalDeFolhas = info.LookupParameter("Total de folhas").AsString();
            }
            catch(Exception)
            {
                String message = "Erro ao coletar informações, verifique os valores em Informações do projeto: \n";
                foreach (String str in this.ProjectInfos)
                {
                    message += str + "\n";
                }
                MessageBox.Show(message, "Erro");
            }

        }
    }
}
