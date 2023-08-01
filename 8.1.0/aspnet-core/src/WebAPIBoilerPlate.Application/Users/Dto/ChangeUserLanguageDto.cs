using System.ComponentModel.DataAnnotations;

namespace WebAPIBoilerPlate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}