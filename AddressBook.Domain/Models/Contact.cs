using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;
//class 
namespace AddressBook.Models
{
    [Table("AddressBook")]
    public class Contact
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Mail is Required")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is Invalid")]
        public string ContactMail { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [RegularExpression(@"^(\+91|0)?[6789]\d{9}$", ErrorMessage ="Mobile Number is Invalid")]
        public string ContactMobile { get; set; }

        public string? ContactLandline { get; set; }

        public string? ContactWebsite { get; set; }

        public string? ContactAddress { get; set; }

    }
}
