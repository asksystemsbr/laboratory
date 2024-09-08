using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaboratoryBackEnd.Models
{
    [Table("funcionarios")]
    public class Funcionario : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("funcionario_id")]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Column("nome")]
        public string Nome { get; set; }

        [StringLength(255)]
        [Column("telefone")]
        public string Telefone { get; set; }

        [StringLength(255)]
        [Column("celular")]
        public string Celular { get; set; }

        [StringLength(255)]
        [Column("email")]
        public string Email { get; set; }

        [Column("comissao_vista", TypeName = "decimal(19,2)")]
        public decimal? ComissaoVista { get; set; }

        [Column("comissao_prazo", TypeName = "decimal(19,2)")]
        public decimal? ComissaoPrazo { get; set; }

        [Column("comissao", TypeName = "decimal(19,2)")]
        public decimal? Comissao { get; set; }

        [StringLength(255)]
        [Column("tipo_comissao")]
        public string TipoComissao { get; set; }

        [StringLength(255)]
        [Column("ativo")]
        public string Ativo { get; set; }

        [Column("funcao_id")]
        public int? FuncaoId { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        [Column("cod_bio")]
        public int? CodBio { get; set; }
    }
}