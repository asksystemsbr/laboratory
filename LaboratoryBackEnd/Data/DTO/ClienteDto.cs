
namespace LaboratoryBackEnd.Data.DTO
{
    public class ClienteDto
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string? CpfCnpj { get; set; }

        public int? EnderecoId { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public int SituacaoId { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Sexo { get; set; }

        public DateTime? Nascimento { get; set; }

        public int? ConvenioId { get; set; }

        public int? PlanoId { get; set; }

        public string? RG { get; set; }

        public string? RazaoSocial { get; set; }

        public string? IE { get; set; }

        public string? IM { get; set; }

        public string? NomeResponsavel { get; set; }

        public string? CpfResponsavel { get; set; }

        public string? TelefoneResponsavel { get; set; }

        public string? NomeSocial { get; set; }

        public string? NomeMae { get; set; }

        public string? Foto { get; set; }

        public string? Profissao { get; set; }

        public string? Matricula { get; set; }

        public DateTime? ValidadeMatricula { get; set; }

        public string? TitularConvenio { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
