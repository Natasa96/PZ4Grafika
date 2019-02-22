using ElektroenergetskaMreza.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ElektroenergetskaMreza.Utils
{
    public class XMLParser
    {
        public NetworkModel model = new NetworkModel();
        private string Path = @"C:\Users\Natasa\Desktop\FAX\blok5\PredmetniZadatak3\Geographic.xml";

        public static XMLParser parser = null;

        private XMLParser()
        {
            PopulateEntities();
        }

        private void PopulateEntities()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNode node = doc.SelectSingleNode("NetworkModel/Substations");
            foreach(XmlNode n in node.ChildNodes)
            {
                SubstationEntity sb = new SubstationEntity();
                foreach (XmlNode child in n.ChildNodes)
                {
                    if (child.Name == "Id")
                        sb.ID = long.Parse(child.InnerText);
                    else if (child.Name == "Name")
                        sb.Name = child.InnerText;
                    else if (child.Name == "X")
                        sb.X = Double.Parse(child.InnerText);
                    else if (child.Name == "Y")
                        sb.Y = Double.Parse(child.InnerText);   
                }
                model.Substations.Add(sb);
            }

            node = doc.SelectSingleNode("NetworkModel/Nodes");
            foreach(XmlNode n in node.ChildNodes)
            {
                NodeEntity ne = new NodeEntity();
                foreach(XmlNode child in n.ChildNodes)
                {
                    if (child.Name == "Id")
                        ne.ID = long.Parse(child.InnerText);
                    else if (child.Name == "Name")
                        ne.Name = child.InnerText;
                    else if (child.Name == "X")
                        ne.X = Double.Parse(child.InnerText);
                    else if (child.Name == "Y")
                        ne.Y = Double.Parse(child.InnerText);
                }
                model.Nodes.Add(ne);
            }

            node = doc.SelectSingleNode("NetworkModel/Switches");
            foreach(XmlNode n in node.ChildNodes)
            {
                SwitchEntity se = new SwitchEntity();
                foreach (XmlNode child in n.ChildNodes)
                {
                    if (child.Name == "Id")
                        se.ID = long.Parse(child.InnerText);
                    else if (child.Name == "Status")
                        se.Status = child.InnerText;
                    else if (child.Name == "Name")
                        se.Name = child.InnerText;
                    else if (child.Name == "X")
                        se.X = Double.Parse(child.InnerText);
                    else if (child.Name == "Y")
                        se.Y = Double.Parse(child.InnerText);
                }
                model.Switches.Add(se);
            }

            node = doc.SelectSingleNode("NetworkModel/Lines");
            foreach (XmlNode n in node.ChildNodes)
            {
                LineEntity line = new LineEntity();
                foreach (XmlNode child in n.ChildNodes)
                {
                    if (child.Name == "Id")
                        line.ID = long.Parse(child.InnerText);
                    if (child.Name == "IsUnderground")
                        line.IsUnderGround = bool.Parse(child.InnerText);
                    if (child.Name == "Name")
                        line.Name = child.InnerText;
                    if (child.Name == "R")
                        line.R = float.Parse(child.InnerText);
                    if (child.Name == "ConductorMaterial")
                        line.ConductingMaterial = child.InnerText;
                    if (child.Name == "LineType")
                        line.LineType = child.InnerText;
                    if (child.Name == "ThermalConstantHeat")
                        line.TermalConstantHeat = long.Parse(child.InnerText);
                    if (child.Name == "FirstEnd")
                        if(child.InnerText != null)
                            line.FirstEnd = long.Parse(child.InnerText);
                    if (child.Name == "SecondEnd")
                            if(child.InnerText != null)
                                line.SecondEnd = long.Parse(child.InnerText);
                    if(child.Name == "Vertices")
                    {
                        foreach(XmlNode pnode in child.ChildNodes)
                        {
                            Point p = new Point();
                            foreach (XmlNode point in pnode.ChildNodes)
                            {
                                if (point.Name == "X")
                                    p.X = Double.Parse(point.InnerText);
                                else if (point.Name == "Y")
                                    p.Y = Double.Parse(point.InnerText);
                            }
                            line.Vertices.Add(p);
                        }
                    }
                }
                if(line.SecondEnd != 0 && line.FirstEnd != 0)
                    model.Lines.Add(line);
            }
        }

        public static XMLParser Instance
        {
            get
            {
                if (parser == null)
                    parser = new XMLParser();

                return parser;
            }
        }
    }
}
