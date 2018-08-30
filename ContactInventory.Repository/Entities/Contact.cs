//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactInventory.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Contact
    {
        [Required(ErrorMessage = "FirstName is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be string")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be string")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Id is Required.")]        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage="Provided Email Id not valid.")]
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provided phone number not valid.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Status is Required.")]        
        [Range(0, 1, ErrorMessage = "Provide Status is not valid.")]
        public int Status { get; set; }
        public int ID { get; set; }
    }
}
