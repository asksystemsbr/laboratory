using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryBackEnd.Models
{
    [Table("status_pagamento")]
    public class StatusPagamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_pagamento_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("descricao")]
        public string Descricao { get; set; }

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}