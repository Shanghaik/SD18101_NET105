using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsData.Models
{
    // Trong Data Anotation chúng ta có thể thực hiện được validate
    // cho thuộc tính của đối tượng
    public class Sinhvien
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "You must enter a Name for Sinhvien")]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [EmailAddress(ErrorMessage = "Email doesn't match suitable format")] // Kiểu email
        public string Email { get; set; }
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$")]
        public string PhoneNumber { get; set; }

        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public int Major { get; set; }

    }
}
