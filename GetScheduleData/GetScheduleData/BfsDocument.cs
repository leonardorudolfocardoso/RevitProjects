using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace GetScheduleData
{
    class BfsDocument
    {
        public Document Doc { get; set; }
        public string Proprietario {get; set;}
        public string Cnpj { get; set; }
        public string Obra { get; set; }
        public string Endereco { get; set; }
        public string Disciplina { get; set; }
        public string Numero { get; set; }
        public int Ano { get; set; }
        public string Codigo { get; set; }
        public string Revisao { get; set; }

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

            // assign the properties
            //try
            //{
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
            //}
            //catch(Exception){
            //    MessageBox.Show("Erro ao coletar informações, verifique os valores em Informações do projeto.", "Erro");
            //}
        }
    }
}
