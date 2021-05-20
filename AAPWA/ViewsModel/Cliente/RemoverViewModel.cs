namespace AAPWA.ViewsModel.Cliente
{
    public class RemoverViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public string id { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string dataNascimento { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public string dataInclusao { get; set; }
        public string dataModificacao { get; set; }
        public string Evento { get; set; }
        public string email { get; set; }
    }
}