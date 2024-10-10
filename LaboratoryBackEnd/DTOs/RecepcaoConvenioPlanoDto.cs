using System;

namespace LaboratoryBackEnd.DTOs
{
    public class RecepcaoConvenioPlanoDto
    {
        public int ID { get; set; }
        public int RecepcaoId { get; set; }
        public int? ConvenioId { get; set; }
        public int? PlanoId { get; set; }
        public string NomeRecepcao { get; set; }
        public string DescricaoConvenio { get; set; }
        public string DescricaoPlano { get; set; }
    }
}