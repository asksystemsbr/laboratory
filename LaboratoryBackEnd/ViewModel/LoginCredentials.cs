namespace LaboratoryBackEnd.ViewModel
{
    public class LoginCredentials
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public string token { get; set; }

        public List<string>? permissions { get; set; }
    }
}
