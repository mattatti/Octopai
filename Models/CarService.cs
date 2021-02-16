using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Octopai.Models
{
    public class CarService
    {
        [Key]
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public int CarModelId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ServiceStartDate { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ServiceEndDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ServiceName { get; set; }
        public float Cost { get; set; }
        public float NetHours { get; set; }
    }
}
