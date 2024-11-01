
namespace LaboratoryBackEnd.Data.DTO
{
    public class ExameDTO 
    {
        public int ID { get; set; }

        public string? CodigoExame { get; set; }

        public string NomeExame { get; set; }

        public int? Prazo { get; set; }

        public string? Metodo { get; set; }

        public string? Preparo { get; set; }

        public string? PreparoF { get; set; }

        public string? PreparoC { get; set; }

        public bool? Agenda { get; set; }

        public string? AgendasRelacionadas { get; set; }

        public string? Sinonimos { get; set; }

        public bool? Dissociar { get; set; }

        public string? Formulario { get; set; }

        public string? InstrucoesPreparo { get; set; }

        public string? Coleta { get; set; }

        public string? Distribuicao { get; set; }

        public string? Lembretes { get; set; }

        public string? TecnicaDeColeta { get; set; }

        public string? AlertasRecep { get; set; }

        public string? AlertasRecepOs { get; set; }

        public string? Alertas { get; set; }

        public string? AlertasPos { get; set; }

        public string? SlExamesRefTabelaCod { get; set; }

        public string? SLExamesRefTabelaExame { get; set; }

        public string? SLExamesRefTabelaConv { get; set; }

        public string? SLExamesRefTabelaPlano { get; set; }

        public string? SLExamesRefTabelaAut { get; set; }

        public decimal? SLExamesRefTabelaValor { get; set; }

        public string? Estabilidade { get; set; }

        public string? Tuss { get; set; }

        public string? MeiosDeColeta { get; set; }

        public string? ColetaPac { get; set; }

        public string? ColetaPacF { get; set; }

        public string? ColetaPacC { get; set; }

        public int MaterialApoioId { get; set; }

        public int? EspecialidadeId { get; set; }

        public int? SetorId { get; set; }

        public int? DestinoId { get; set; }

        public string? VolumeMinimo { get; set; }

        public string? CodigoExameApoio { get; set; }

        public string? PrazoApoio { get; set; }

        public string? ValorApoio { get; set; }

        public string? VersaoApoio { get; set; }

        public string? DiasRealizacaoApoio { get; set; }

        public string? MeioColetaSimilar { get; set; }

        public string? MaterialColetaSimilar { get; set; }
        public decimal? Preco { get; set; }
        public DateTime? DataColeta { get; set; }
    }
}