namespace LaboratoryBackEnd.DTOs
{
    public class RecepcaoEspecialidadeExameDto
    {
        public int RecepcaoId { get; set; }
        public int EspecialidadeId { get; set; }
        public List<int> ExamesId { get; set; } = new List<int>();
    }
}
