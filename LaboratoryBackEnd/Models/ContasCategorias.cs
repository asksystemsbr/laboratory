using LaboratoryBackEnd.Data.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("contas_categorias")]
    public class ContasCategorias : IIdentifiable
    {
        [Key]
        [Column("categoria_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required] 
        [StringLength(255)]
        [Column("nome")] 
        public string Nome { get; set; }

        public virtual ICollection<SubCategoria> SubCategorias { get; set; } = new List<SubCategoria>();
    }

