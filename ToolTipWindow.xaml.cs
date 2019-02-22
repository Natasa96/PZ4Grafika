using System;
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
using System.Windows.Shapes;

namespace PredmetniZadatak4
{
    /// <summary>
    /// Interaction logic for ToolTipWindow.xaml
    /// </summary>
    public partial class ToolTipWindow : Window
    {
        public ToolTipWindow(string info)
        {
            InitializeComponent();
            tBoxInfo.Text = info;
        }
    }
}
