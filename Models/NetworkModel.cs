using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektroenergetskaMreza.Model
{
    public class NetworkModel
    {
        public List<SubstationEntity> Substations = new List<SubstationEntity>();
        public List<NodeEntity> Nodes = new List<NodeEntity>();
        public List<SwitchEntity> Switches = new List<SwitchEntity>();
        public List<LineEntity> Lines = new List<LineEntity>();

        public NetworkModel() { }
    }
}
