using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_planner
{
    internal class UserSettingsModel
    {
        public int ID { get; set; }
        public bool FILTER_CLASS_A { get; set; }
        public bool FILTER_CLASS_B { get; set; }
        public bool FILTER_CLASS_C { get; set; }
        public bool FILTER_CLASS_D { get; set; }
        public bool FILTER_CLASS_R { get; set; }
        public bool FILTER_TYPE_ROAD { get; set; }
        public bool FILTER_TYPE_OVAL { get; set; }
        public bool FILTER_TYPE_ROAD_DIRT { get; set; }
        public bool FILTER_TYPE_OVAL_DIRT { get; set; }
    }
}