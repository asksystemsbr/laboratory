using LaboratoryBackEnd.Data.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("laboratorio_apoio")]
    public class LaboratorioApoio: IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [MaxLength(255)]
        [Column("nome_laboratorio")]
        public string NomeLaboratorio { get; set; }

        [MaxLength(255)]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [MaxLength(255)]
        [Column("numero")]
        public string Numero { get; set; }

        [MaxLength(255)]
        [Column("complemento")]
        public string Complemento { get; set; }

        [MaxLength(255)]
        [Column("bairro")]
        public string Bairro { get; set; }

        [MaxLength(255)]
        [Column("cep")]
        public string Cep { get; set; }

        [MaxLength(255)]
        [Column("cidade")]
        public string Cidade { get; set; }

        [MaxLength(255)]
        [Column("UF")]
        public string UF { get; set; }

        [MaxLength(255)]
        [Column("url_api")]
        public string UrlApi { get; set; }
    }
}
