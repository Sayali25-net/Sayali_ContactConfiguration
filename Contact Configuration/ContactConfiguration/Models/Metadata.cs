using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactConfiguration.Models
{
    public class ContactMetadata
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [Range(0, Int64.MaxValue, ErrorMessage = "Contact number should not contain characters")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Contact number should have minimum 10 digits")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}