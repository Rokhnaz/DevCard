using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevCard_MVC.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100, ErrorMessage = "حداکثر طول 3 کاراکتر است")]
        [MinLength(3,ErrorMessage = "حداقل طول 3 کاراکتر است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }
        public string Message { get; set; }
        public int Service { get; set; }
        public SelectList Services { get; set; }
    }
}
