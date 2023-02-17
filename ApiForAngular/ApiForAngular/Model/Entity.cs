using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular.Model
{
    public class Entity
    {
        public int pid { get; set; } = 0;
        public string pname { get; set; } = null;
        public decimal? price { get; set; }
        public int? pqty { get; set; }
    }
}
