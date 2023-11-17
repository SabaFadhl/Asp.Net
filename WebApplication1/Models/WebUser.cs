using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WebUser
    {
        public int Id { get; set; }
        [Display(Name = "User")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        [Display(Name = "Photo")]
        public string UImage { get; set; }
    }
}
