using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apiexamen.Models
{
    public class Currency
    {
        [Key]
        public double monto { get; set; }
        public string divisa { get; set; }
        public Currency(double x,string y) { monto = x; divisa = y; }  
        
    }
}