using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MenuDTO
    {
        public string Id { get; set; }
        public string ResId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
    }
}
