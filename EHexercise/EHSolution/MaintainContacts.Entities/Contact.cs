using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainContacts.Entities
{
    [Table("TblContact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Display(Name = "First Name")]
        [Required (ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "Atleast 2 characters required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "Atleast 2 characters required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Please enter valid Email address.")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter valid Email address.")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid Phone number.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        public int StatusID { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }
    }
}