using ElektroenergetskaMreza.Utils;
using HelixToolkit.Wpf;
using PredmetniZadatak4.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PredmetniZadatak4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string MAP_PATH = "Images/PZ4-map.jpg";
        private Point start = new Point();
        private Point diffOffset = new Point();
        private int zoomMax = 200;
        private int zoomCurent = 1;
        private static LookBackConverter lookBackConverter = new LookBackConverter();
        double crLat = 0;
        double crLon = 0;
        double nextLat, nextLon = 0;

        private GeometryModel3D hitgeo;
        private Dictionary<string, GeometryModel3D> models = new Dictionary<string, GeometryModel3D>();

        public MainWindow()
        {
            InitializeComponent();
            DrawMarkers();
        }

        private void DrawMarkers()
        {
            double lat, lon;
            double offset = 2;

            MapConvertor.GetMapPosition(out lat, out lon);

            foreach (var node in MapConvertor.networkModel.Nodes)
            {
                Convertor.ToLatLon(node.X, node.Y, 34, out double latitude, out double longitude);
                double posX = Convertor.RoundToNearest((longitude - MapConvertor.MinimalLon) * lon, 5);
                double posZ = Convertor.RoundToNearest((latitude - MapConvertor.MinimalLat) * lat, 5);

                //double posX = Convertor.RoundToNearest(latitude / 800, 10);
                //double posZ = Convertor.RoundToNearest(longitude / 800, 10);

                MeshGeometry3D mesh = new MeshGeometry3D();

                if (posX <= 800 && posX >= 0 && posZ <= 800 && posZ >= 0)
                {
                    mesh.Positions = new Point3DCollection()
                { new Point3D(posX - offset,1,posZ - offset),
                  new Point3D(posX + offset,1,posZ - offset),
                  new Point3D(posX - offset,5, posZ - offset),
                  new Point3D(posX + offset,5, posZ - offset),

                  new Point3D(posX - offset,1,posZ + offset),
                  new Point3D(posX + offset,1,posZ + offset),
                  new Point3D(posX - offset,5, posZ + offset),
                  new Point3D(posX + offset,5, posZ + offset)};
                    mesh.TriangleIndices = new Int32Collection()
                    {
                        2, 3, 1, 3, 1, 0, 7, 1, 3,
                        7, 5, 1, 6, 5, 7, 6, 4, 5,
                        6, 2, 0, 2, 0, 4, 2, 7, 3,
                        2, 6, 7, 0, 1, 5, 0, 5, 4
                    };
                    GeometryModel3D model = new GeometryModel3D();
                    model.Geometry = mesh;
                    model.Material = new DiffuseMaterial() { Brush = Brushes.LightBlue };
                    GroupMain.Children.Add(model);
                    string info = string.Format("Id: {0}\nName: {1}\nType: {2}", node.ID, node.Name, node.GetType());
                    models.Add(info, model);
                }
            }

            foreach(var sub in MapConvertor.networkModel.Substations)
            {
                Convertor.ToLatLon(sub.X, sub.Y, 34, out double latitude, out double longitude);
                double posX = Convertor.RoundToNearest((longitude - MapConvertor.MinimalLon) * lon, 5);
                double posZ = Convertor.RoundToNearest((latitude - MapConvertor.MinimalLat) * lat, 5);
                MeshGeometry3D mesh = new MeshGeometry3D();

                if (posX <= 800 && posX >= 0 && posZ <= 800 && posZ >= 0)
                {
                    mesh.Positions = new Point3DCollection()
                { new Point3D(posX - offset,1,posZ - offset),
                  new Point3D(posX + offset,1,posZ - offset),
                  new Point3D(posX - offset,5, posZ - offset),
                  new Point3D(posX + offset,5, posZ - offset),

                  new Point3D(posX - offset,1,posZ + offset),
                  new Point3D(posX + offset,1,posZ + offset),
                  new Point3D(posX - offset,5, posZ + offset),
                  new Point3D(posX + offset,5, posZ + offset)};
                    mesh.TriangleIndices = new Int32Collection()
                    {
                        2, 3, 1, 3, 1, 0, 7, 1, 3,
                        7, 5, 1, 6, 5, 7, 6, 4, 5,
                        6, 2, 0, 2, 0, 4, 2, 7, 3,
                        2, 6, 7, 0, 1, 5, 0, 5, 4
                    };
                    GeometryModel3D model = new GeometryModel3D();
                    model.Geometry = mesh;
                    model.Material = new DiffuseMaterial() { Brush = Brushes.Lime };
                    GroupMain.Children.Add(model);
                    string info = string.Format("Id: {0}\nName: {1}\nType: {2}", sub.ID, sub.Name, sub.GetType());
                    models.Add(info, model);
                }
            }

            foreach (var sw in MapConvertor.networkModel.Switches)
            {
                Convertor.ToLatLon(sw.X, sw.Y, 34, out double latitude, out double longitude);
                double posX = Convertor.RoundToNearest((longitude - MapConvertor.MinimalLon) * lon, 5);
                double posZ = Convertor.RoundToNearest((latitude - MapConvertor.MinimalLat) * lat, 5);
                MeshGeometry3D mesh = new MeshGeometry3D();

                if (posX <= 800 && posX >= 0 && posZ <= 800 && posZ >= 0)
                {
                    mesh.Positions = new Point3DCollection()
                { new Point3D(posX - offset,1,posZ - offset),
                  new Point3D(posX + offset,1,posZ - offset),
                  new Point3D(posX - offset,5, posZ - offset),
                  new Point3D(posX + offset,5, posZ - offset),

                  new Point3D(posX - offset,1,posZ + offset),
                  new Point3D(posX + offset,1,posZ + offset),
                  new Point3D(posX - offset,5, posZ + offset),
                  new Point3D(posX + offset,5, posZ + offset)};
                    mesh.TriangleIndices = new Int32Collection()
                    {
                        2, 3, 1, 3, 1, 0, 7, 1, 3,
                        7, 5, 1, 6, 5, 7, 6, 4, 5,
                        6, 2, 0, 2, 0, 4, 2, 7, 3,
                        2, 6, 7, 0, 1, 5, 0, 5, 4
                    };
                    GeometryModel3D model = new GeometryModel3D();
                    model.Geometry = mesh;
                    model.Material = new DiffuseMaterial() { Brush = Brushes.MistyRose };
                    GroupMain.Children.Add(model);
                    string info = string.Format("Id: {0}\nName: {1}\nType: {2}", sw.ID, sw.Name, sw.GetType());
                    models.Add(info, model);
                }
            }

            foreach (var line in MapConvertor.networkModel.Lines)
            {
                var linesegments = line.Vertices;
                var current = linesegments[0];
                var next = linesegments[1];
                int i = 2;
                int max = linesegments.Count;
                while (true)
                {
                    Convertor.ToLatLon(current.X, current.Y, 34, out double crLat, out double crLon);
                    Convertor.ToLatLon(next.X, next.Y, 34, out double nextLat, out double nextLon);
                    double posX = Convertor.RoundToNearest((crLon - MapConvertor.MinimalLon) * lon, 5);
                    double posZ = Convertor.RoundToNearest((crLat - MapConvertor.MinimalLat) * lat, 5);
                    double posX2 = Convertor.RoundToNearest((nextLon - MapConvertor.MinimalLon) * lon, 5);
                    double posZ2 = Convertor.RoundToNearest((nextLat - MapConvertor.MinimalLat) * lat, 5);
                    MeshGeometry3D mesh = new MeshGeometry3D();

                    if (posX <= 800 && posX >= 0 && posZ <= 800 && posZ >= 0 && posX2 <= 800 && posX2 >= 0 && posZ2 <= 800 && posZ2 >= 0)
                    {
                        mesh.Positions = new Point3DCollection()
                        { new Point3D(posX ,1,posZ ),
                          new Point3D(posX2 ,1,posZ2 ),
                          new Point3D(posX2 ,2, posZ2 ),
                          new Point3D(posX ,2, posZ ),

                          new Point3D(posX2 ,1,posZ2 ),
                          new Point3D(posX ,1,posZ ),
                          new Point3D(posX2 ,2, posZ2 ),
                          new Point3D(posX ,2, posZ )};
                        mesh.TriangleIndices = new Int32Collection()
                            {
                                2, 3, 1, 3, 1, 0, 7, 1, 3,
                                7, 5, 1, 6, 5, 7, 6, 4, 5,
                                6, 2, 0, 2, 0, 4, 2, 7, 3,
                                2, 6, 7, 0, 1, 5, 0, 5, 4
                            };
                        GeometryModel3D model = new GeometryModel3D();
                        model.Geometry = mesh;
                        model.Material = new DiffuseMaterial() { Brush = Brushes.Red };
                        GroupMain.Children.Add(model);
                        current = next;
                        if (i + 1 < max)
                        {
                            next = linesegments[i++];
                        }
                        else
                            break;
                    }
                    else
                    {
                        current = next;
                        if (i + 1 < max)
                        {
                            next = linesegments[i++];
                        }
                        else
                            break;
                    }
                }
            }

        }

        private void viewPort_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            viewPort.CaptureMouse();
            start = e.GetPosition(this);
            diffOffset.X = translacija.OffsetX;
            diffOffset.Y = translacija.OffsetY;
        }

        private void viewPort_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            viewPort.ReleaseMouseCapture();
        }

        private void viewPort_MouseMove(object sender, MouseEventArgs e)
        {
            if (viewPort.IsMouseCaptured)
            {
                Point end = e.GetPosition(this);
                double offsetX = end.X - start.X;
                double offsetY = end.Y - start.Y;
                double w = this.Width;
                double h = this.Height;
                double translateX = (offsetX * 100) / w;
                double translateY = -(offsetY * 100) / h;
                translacija.OffsetX = diffOffset.X + (translateX /  skaliranje.ScaleX);
                translacija.OffsetY = diffOffset.Y + (translateY /  skaliranje.ScaleY);

            }
        }

        private void viewPort_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point p = e.MouseDevice.GetPosition(this);
            double scaleX = 1;
            double scaleY = 1;
            if (e.Delta > 0 && zoomCurent < zoomMax)
            {
                //scaleX = skaliranje.ScaleX + 0.1;
                //scaleY = skaliranje.ScaleY + 0.1;
                //zoomCurent++;
                //skaliranje.ScaleX = scaleX;
                //skaliranje.ScaleY = scaleY;
                double x = CameraMain.Position.X;
                double y = CameraMain.Position.Y;
                double z = CameraMain.Position.Z;
                CameraMain.Position = new Point3D(x - 5, y - 5, z - 5);
            }
            else if (e.Delta <= 0 && zoomCurent > -zoomMax)
            {
                //scaleX = skaliranje.ScaleX - 0.1;
                //scaleY = skaliranje.ScaleY - 0.1;
                //zoomCurent--;
                //skaliranje.ScaleX = scaleX;
                //skaliranje.ScaleY = scaleY;
                double x = CameraMain.Position.X;
                double y = CameraMain.Position.Y;
                double z = CameraMain.Position.Z;
                CameraMain.Position = new Point3D(x + 5, y +5, z +5);
            }
        }

        private void viewPort_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.MiddleButton == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Middle)
            {
                Point mousePos = e.GetPosition(viewPort);
                PointHitTestParameters hitParams = new PointHitTestParameters(mousePos);
                VisualTreeHelper.HitTest(viewPort, null, delegate (HitTestResult hr)
                {
                    RayMeshGeometry3DHitTestResult rayHit = hr as
                    RayMeshGeometry3DHitTestResult;
                    if (rayHit != null)
                    {
                        Point3D point = rayHit.PointHit;
                        double x = CameraMain.LookDirection.X;
                        double y = CameraMain.LookDirection.Y;
                        double z = CameraMain.LookDirection.Z;
                        double xoff = x - point.X;

                        CameraMain.LookDirection = new Vector3D(x, y, z);
                        CameraMain.Position = new Point3D(x, y, z);

                    }
                    return HitTestResultBehavior.Continue;
                }, hitParams);
            }
        }

        private void viewPort_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mouseposition = e.GetPosition(viewPort);
            Point3D testpoint3D = new Point3D(mouseposition.X, mouseposition.Y, 0);
            Vector3D testdirection = new Vector3D(mouseposition.X, mouseposition.Y, 800);

            PointHitTestParameters pointparams =
                     new PointHitTestParameters(mouseposition);
            RayHitTestParameters rayparams =
                     new RayHitTestParameters(testpoint3D, testdirection);

            //test for a result in the Viewport3D     
            hitgeo = null;
            VisualTreeHelper.HitTest(viewPort, null, HTResult, pointparams);
        }

        private HitTestResultBehavior
               HTResult(System.Windows.Media.HitTestResult rawresult)
        {

            RayHitTestResult rayResult = rawresult as RayHitTestResult;

            if (rayResult != null)
            {
                bool close = false;
                foreach(string info in models.Keys)
                {
                    if((GeometryModel3D)models[info] == rayResult.ModelHit)
                    {
                        hitgeo = (GeometryModel3D)rayResult.ModelHit;
                        close = true;
                        ToolTipWindow tp = new ToolTipWindow(info);
                        tp.Show();
                    }
                }
                if (!close)
                    hitgeo = null;
            }

            return HitTestResultBehavior.Stop;
        }


    }
}
