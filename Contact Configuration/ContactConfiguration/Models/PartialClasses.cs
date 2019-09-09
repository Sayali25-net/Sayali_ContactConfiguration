using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactConfiguration.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(ContactMetadata))]
        public partial class Contact
        {
        }

    }
}