using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCruiser
{
    public class Movie
    {
        [Key]
        public int M_Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string M_Title { get; set; }
        [Display(Name = "Gross($)")]
        public string M_BoxOffice { get; set; }
        public string M_Active { get; set; }
        [Required]
        [Display(Name ="Date Of Launch")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy",ApplyFormatInEditMode =true)]
        public DateTime M_DateOfLaunch { get; set; }
        public genre Genre { get; set; }
        public bool M_HasTeaser { get; set; }
     //   public Customer Customerid { get; set; }

    }
    public enum genre
    {
        Romance,Adventure,ScienceFiction,SuperHero,Thriller,Comedy
    }
}