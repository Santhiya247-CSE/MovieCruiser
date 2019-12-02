using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCruiser
{
    public class Favorite
    {
        [Key]
        public int F_id { get; set; }
        public  int M_Id { get; set; }
        public string M_Title { get; set; }
        public string M_Boxoffice { get; set; }
        public genre Genre { get; set; }
        public int Custid { get; set; }

    }
}