using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("metodos_pagamento")]
    public class MetodosPagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("metodo_pagamento_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("descricao")]
        public string Descricao { get; set; }

        public ICollection<Contas> Contas { get; set; } = new List<Contas>();
    }
}
