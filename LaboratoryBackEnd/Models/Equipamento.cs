using LaboratoryBackEnd.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    [Table("equipamentos")]
    public class Equipamento : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("equipamento_id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("nome_equipamento")]
        public string NomeEquipamento { get; set; }

        [Column("descricao", TypeName = "text")]
        public string Descricao { get; set; }

        [MaxLength(50)]
        [Column("numero_serie")]
        public string NumeroSerie { get; set; }

        [Column("data_aquisicao", TypeName = "date")]
        public DateTime? DataAquisicao { get; set; }

        public virtual ICollection<OrdemServicoEquipamento> OrdemServicoEquipamentos { get; set; } = new List<OrdemServicoEquipamento>();
    }
