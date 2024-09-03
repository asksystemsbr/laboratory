using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryBackEnd.Models
{
    [Table("auditlog")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string ActionType { get; set; }
        public string TableName { get; set; }
        public string Data { get; set; }
        public string UserId { get; set; }
    }
}
