using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apiexamen.Models
{
    public class producto
    {
        [Key]
        [Range(typeof(int),"1","99999")]
        public int ProductoID { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3,ErrorMessage ="Ingrese entre 3 a 30 caracteres")]
        public string Description { get; set; }
        [Required]
        public Currency Price { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime LastBuy { get; set; }

    }
}