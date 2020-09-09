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

namespace ToDoUp.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ChangeEndAddServis : Window
    {

        private DB.Service Service;

        private Model.ServisesContoller contoller;

        public ChangeEndAddServis()
        {
            InitializeComponent();
           


        }

        public ChangeEndAddServis ( Model.Servis servis )
        {
            InitializeComponent();

            contoller = new Model.ServisesContoller(servis);
            Service = contoller.ServiceOne;

            gr.DataContext = Service;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Service = gr.DataContext as DB.Service;

            contoller.ServiceOne = Service;
            contoller.Save();
            this.DialogResult = true;
            this.Close();
        }
    }
}
