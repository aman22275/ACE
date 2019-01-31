using System.ComponentModel.DataAnnotations;

namespace DF.ACE.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}