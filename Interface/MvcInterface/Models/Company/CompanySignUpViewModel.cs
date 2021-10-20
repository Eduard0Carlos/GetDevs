namespace MvcInterface.Models
{
    public class CompanySignUpViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Sector { get; set; }
        public string Cnpj { get; set; }
        public string LogoImageUrl { get; set; }
        public int CompanySize { get; set; }
        public string Slogan { get; set; }
    }
}
