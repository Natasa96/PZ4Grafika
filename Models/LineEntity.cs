using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektroenergetskaMreza.Model
{
    public class LineEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public bool IsUnderGround { get; set; }
        public float R { get;  set; }
        public string ConductingMaterial { get; set; }
        public string LineType { get; set; }
        public long TermalConstantHeat { get; set; }
        public long FirstEnd { get; set; }
        public long SecondEnd { get; set; }
        public List<Point> Vertices { get; set; }

        public LineEntity() { Vertices = new List<Point>(); }
    }
}
