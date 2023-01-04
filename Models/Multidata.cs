using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Multidata
    {
        public IEnumerable<biodata> bio  { get;set; }
        public IEnumerable<nextofkin> nxt { get; set; }
    }
}
