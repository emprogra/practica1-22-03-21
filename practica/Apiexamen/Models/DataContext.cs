using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apiexamen.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Apiexamen.Models.Currency> Currencies { get; set; }

        public System.Data.Entity.DbSet<Apiexamen.Models.producto> productoes { get; set; }
    }
}