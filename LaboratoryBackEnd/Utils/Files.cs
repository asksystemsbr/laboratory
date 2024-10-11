namespace LaboratoryBackEnd.Utils
{
    public class Files
    {
        public byte[] ConvertBase64ToBytes(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return null;
            }

            // Remove o prefixo da string Base64, se necessário (por exemplo, "data:image/png;base64,")
            var base64Data = base64String.Substring(base64String.IndexOf(",") + 1);
            return Convert.FromBase64String(base64Data);
        }
    }
}
