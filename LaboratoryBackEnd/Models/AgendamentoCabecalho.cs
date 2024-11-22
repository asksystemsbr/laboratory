using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("agendamento_cabecalho")]
    public class AgendamentoCabecalho : IIdentifiable
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("paciente_id")]
        public int? PacienteId { get; set; }
        
        [Column("convenio_id")]
        public int? ConvenioId { get; set; }
        
        [Column("data_hora")]
        public DateTime? DataHora { get; set; }

        [Column("nome_paciente")]
        public string NomePaciente { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("solicitante_id")]
        public int? SolicitanteId { get; set; }

        [Column("cod_convenio")]
        public string CodConvenio { get; set; }

        [Column("plano_id")]
        public int? PlanoId { get; set; }

        [Column("validade_cartao")]
        public DateTime? ValidadeCartao { get; set; }

        [Column("guia")]
        public string Guia { get; set; }

        [Column("titular")]
        public string Titular { get; set; }

        [Column("senha_autorizacao")]
        public string SenhaAutorizacao { get; set; }

        [Column("medicamento")]
        public string Medicamento { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }

        [Column("total")]
        public decimal? Total { get; set; }

        [Column("recepcao_id")]
        public int? RecepcaoId { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        [Column("desconto")]
        public decimal? Desconto { get; set; }

        [Column("tipo_desconto")]
        public string? TipoDesconto { get; set; }
    }
}
