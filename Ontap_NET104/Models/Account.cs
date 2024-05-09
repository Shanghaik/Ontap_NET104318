using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ontap_NET104.Models
{
    public class Account
    {
        // Data Anotation Validation cho phép chúng ta validate dữ liệu ngay từ Models
        [Required]
        [StringLength(256 ,MinimumLength = 10, ErrorMessage = "Độ dài Username phải từ 10 đến 256")]   
        public string Username { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 10, ErrorMessage = "Độ dài Username phải từ 10 đến 256")]
        public string Password { get; set; }
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$", 
            ErrorMessage = "Số điện thoại phải đúng format và có 10 chữ số")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

    }
}
