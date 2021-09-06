using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Models
{
    public class Address
    {
        [Key]
        public string PostNumber { get; set; } //0166
        public string FullName { get; set; } //Sven bruns gate 2
        public string City { get; set; } //Oslo
        public string County { get; set; } //Norway
        public string HouseNumber { get; set; } //0403

 
    }
}
