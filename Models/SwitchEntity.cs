using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektroenergetskaMreza.Model
{
    public class SwitchEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public SwitchEntity() { }
    }
}
