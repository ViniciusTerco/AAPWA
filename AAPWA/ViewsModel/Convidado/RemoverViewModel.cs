namespace AAPWA.ViewsModel.Convidado
{
    public class RemoverViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string documento { get; set; }
        public string dataNacimento { get; set; }
        public string evento { get; set; }
        public string situacao { get; set; }
        public string observacao { get; set; }
        public string dataInclusao { get; set; }
        public string dataModificacao { get; set; }
    }
}