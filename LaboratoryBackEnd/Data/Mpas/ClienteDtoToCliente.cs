using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Utils;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class ClienteDtoToCliente
    {
        public Cliente MapDtoToCliente(ClienteDto clienteDto)
        {
            return new Cliente
            {
                ID = clienteDto.ID,
                Nome = clienteDto.Nome,
                CpfCnpj = clienteDto.CpfCnpj,
                EnderecoId = clienteDto.EnderecoId,
                Telefone = clienteDto.Telefone,
                Email = clienteDto.Email,
                SituacaoId = clienteDto.SituacaoId,
                DataCadastro = clienteDto.DataCadastro,
                Sexo = clienteDto.Sexo,
                Nascimento = clienteDto.Nascimento,
                ConvenioId = clienteDto.ConvenioId,
                PlanoId = clienteDto.PlanoId,
                RG = clienteDto.RG,
                RazaoSocial = clienteDto.RazaoSocial,
                IE = clienteDto.IE,
                IM = clienteDto.IM,
                NomeResponsavel = clienteDto.NomeResponsavel,
                CpfResponsavel = clienteDto.CpfResponsavel,
                TelefoneResponsavel = clienteDto.TelefoneResponsavel,
                NomeSocial = clienteDto.NomeSocial,
                NomeMae = clienteDto.NomeMae,
                Foto = clienteDto.Foto != null ? new Files().ConvertBase64ToBytes(clienteDto.Foto) : null,  // Convertendo a string Base64 para byte[]
                Profissao = clienteDto.Profissao,
                Matricula = clienteDto.Matricula,
                ValidadeMatricula = clienteDto.ValidadeMatricula,
                TitularConvenio = clienteDto.TitularConvenio,
                Endereco = clienteDto.Endereco,  // Atribui o objeto de Endereço, se ele for o mesmo
                Senha = clienteDto.Senha,
                TelefoneCelular = clienteDto.TelefoneCelular
            };
        }
    }
}
