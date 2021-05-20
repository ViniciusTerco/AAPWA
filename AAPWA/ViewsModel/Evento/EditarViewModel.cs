namespace AAPWA.ViewsModel.Evento
{
    public class EditarViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public string id { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public string horaInicial { get; set; }
        public string horaFinal { get; set; }
        public string situacao { get; set; }
        public string descricaoLocal { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public string dataInclusao { get; set; }
        public string dataModificacao { get; set; }
    }
}