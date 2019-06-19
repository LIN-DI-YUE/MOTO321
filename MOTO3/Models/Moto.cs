using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MOTO3.Models
{
    public class Moto
    {
        public int ID { get; set; }
        public string Motoname { get; set; }
        public int CC { get; set; }
        public decimal price { get; set; }

    }
    
    public class MotoDBContext:DbContext
    {
        public DbSet<Moto> Motos { get; set; }
    }

}