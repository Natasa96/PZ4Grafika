using ElektroenergetskaMreza.Model;
using ElektroenergetskaMreza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredmetniZadatak4.Utils
{
    public class MapConvertor
    {
        private static double LAT1 = 45.2324;
        private static double LAT2 = 45.277013;
        private static double LON1 = 19.793909;
        private static double LON2 = 19.894459;

        public static NetworkModel networkModel = XMLParser.Instance.model;
        public static List<Point> values = new List<Point>();

        public static double MinimalLat { get; set; }
        public static double MaximalLat { get; set; }
        public static double MinimalLon { get; set; }
        public static double MaximalLon { get; set; }

        public static void GetMapPosition(out double x, out double y)
        {
            foreach (var sub in networkModel.Substations)
            {
                Convertor.ToLatLon(sub.X, sub.Y, 34, out double latitude, out double lon);
                if(CheckRange(latitude,lon))
                    values.Add(new Point { X = lon, Y = latitude });
            }

            foreach (var node in networkModel.Nodes)
            {
                Convertor.ToLatLon(node.X, node.Y, 34, out double latitude, out double longitude);
                if (CheckRange(latitude, longitude))
                    values.Add(new Point { X = longitude, Y = latitude });
            }

            foreach (var sw in networkModel.Switches)
            {
                Convertor.ToLatLon(sw.X, sw.Y, 34, out double latitude, out double longitude);
                if (CheckRange(latitude, longitude))
                    values.Add(new Point { X = longitude, Y = latitude });
            }

            MinimalLat = values.Min(v => v.Y);
            MaximalLat = values.Max(v => v.Y);

            MinimalLon = values.Min(v => v.X);
            MaximalLon = values.Max(v => v.X);

            x = 800 / (MaximalLat - MinimalLat);
            y= 800 / (MaximalLon - MinimalLon);
        }

        private static bool CheckRange(double lat, double lon)
        {
            if (LAT1 <= lat && LAT2 >= lat && LON1 <= lon && LON2 >= lon)
                return true;
            return false;
        }
    }
}
