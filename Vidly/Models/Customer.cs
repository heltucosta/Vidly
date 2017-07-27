using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } // fully load the related object

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; } // recognizes as foreign key but do not load the object completely        

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }    
}