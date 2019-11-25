using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCruiser
{
    public class Customer
    {
        [Key]
        public int C_id { get; set; }
        public int Customerid { get; set; }
        [MaxLength(255)]
        public string CustomerName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{dd/MM/yyyy",ApplyFormatInEditMode =true)]
        [Display(Name ="Date Of Birth")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}