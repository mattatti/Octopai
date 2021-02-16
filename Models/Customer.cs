using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Octopai.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(6)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }
        public int ZipCode { get; set; }
        [Column(TypeName = "nvarchar(2)")]
        public string State { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }
        public int PhoneNumber1 { get; set; }
        public int PhoneNumber2 { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string LastModifiedDate { get; set; }
    }
}
