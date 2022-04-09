using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_planner
{
    internal class CarModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isOwned { get; set; }
        public byte[] ImageBlob { get; set; }
    }
}