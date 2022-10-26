using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_3.Models
{
    public class Customer
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę!")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Proszę podać poprawy Email!")]
        public string Email { get; set; }

        public int Age { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$")]
        public string ZipCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
