using LaboratoryBackEnd.Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("clientes")]
    public class Cliente : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cliente_id")]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Column("nome")]
        public string Nome { get; set; }

        [StringLength(20)]
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [StringLength(255)]
        [Column("endereco")]
        public string Endereco { get; set; }

        [StringLength(20)]
        [Column("telefone")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("situacao_id")]
        public int SituacaoId { get; set; }

        [Required]
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }

