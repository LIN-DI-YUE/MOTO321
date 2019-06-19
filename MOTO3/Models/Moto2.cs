using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MOTO3.Models
{
    public class Moto2
    {
     

        public int ID { get; set; }
        public string Motoname { get; set; }
        public int CC { get; set; }
        public decimal price { get; set; }
    }
    public class Moto2DBContext : DbContext
    {
        public DbSet<Moto2> Moto2s { get; set; }
    }
}