using System;
using System.Collections.Generic;
using System.IO;
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

namespace ToDoUp.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ChangeEndAddServis : Window
    {
        private DB.Service Service;

        private Model.ServisesContoller contoller;


        private string s = @"pack://application:,,,/";


        public ChangeEndAddServis()
        {
            InitializeComponent();
            var s = new DB.Service();
            s.MainImagePath = s+ @"Услуги салона красоты\No.jpg.bmp";
            gr.DataContext = s;
        }

        public ChangeEndAddServis ( Model.Servis servis )
        {
            InitializeComponent();

            contoller = new Model.ServisesContoller(servis);
            Service = contoller.ServiceOne;
            Service.MainImagePath = s + Service.MainImagePath;
            gr.DataContext = Service;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if( Service==null)
            {
                Service = gr.DataContext as DB.Service;
                contoller = new Model.ServisesContoller(Service);
            }
            else
            {
                Service = gr.DataContext as DB.Service;
                Service.MainImagePath = Service.MainImagePath.Substring(s.Length);
                contoller.ServiceOne = Service;
                contoller.Save();
            }
           
            this.DialogResult = true;
            this.Close();
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();

            bool opend = open.ShowDialog().Value;
            if (opend == true)
            {
                string filename = open.FileName;
                FileInfo info = new FileInfo(filename);
                image.Source = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
