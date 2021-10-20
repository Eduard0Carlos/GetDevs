using Domain.Entities;

namespace WebAPI.Models
{
    public class CompanyRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoImageUrl { get; set; }
        public string Sector { get; set; }
        public string Cnpj { get; set; }
        public int CompanySize { get; set; }
        public string Slogan { get; set; }
    }

    public static class CompanyRegisterModelExtension
    {
        public static User ConvertToUser(this CompanyRegisterModel registerModel)
        {
            return new User(
                registerModel.Email, 
                registerModel.Password
                );
        }

        public static Company ConvertToCompany(this CompanyRegisterModel registerModel)
        {
            return new Company(
                registerModel.Name,
                registerModel.Url, 
                registerModel.Sector, 
                registerModel.Cnpj, 
                registerModel.CompanySize, 
                registerModel.Slogan,
                registerModel.LogoImageUrl
                );
        }
    }
}
