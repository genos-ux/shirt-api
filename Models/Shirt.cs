using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shirt_api.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        public string? Brand {get; set; }
        public int Size { get; set; }
        public string? Gender { get; set; }
        public double Price { get; set; }
    }
}
