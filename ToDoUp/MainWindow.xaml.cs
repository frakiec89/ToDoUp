using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoUp.Model;

namespace ToDoUp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServisesContoller contoller;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            contoller = new ServisesContoller();

           Refresh( contoller.Servis);
        }

        private void btChange_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var s = button.DataContext as Servis;

            Forms.ChangeEndAddServis window1 = new Forms.ChangeEndAddServis(s);
            window1.ShowDialog();
            if (window1.DialogResult==true)
            {
                contoller = new ServisesContoller();
                Refresh(contoller.Servis);
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var s = button.DataContext as Servis;
            MessageBox.Show(s.FilePath);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Forms.ChangeEndAddServis addServis = new Forms.ChangeEndAddServis();
            addServis.ShowDialog();
        }

        private void Refresh ( List<Model.Servis> servis )
        {
            lbMain.ItemsSource = servis;
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
          Refresh( contoller.Servis.Where(x => x.Name.StartsWith(poisk.Text)).ToList());
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            Refresh(contoller.Servis.OrderBy(x=>x.Name).ToList());
        }
        
        private void down_Click(object sender, RoutedEventArgs e)
        {
            Refresh(contoller.Servis.OrderByDescending(x=>x.Name).ToList());
        }

        private void dick_Click(object sender, RoutedEventArgs e)
        {
            Refresh(contoller.Servis.OrderByDescending(x => x.Discont).ToList());
        }

        private void cells_Click(object sender, RoutedEventArgs e)
        {
            Refresh(contoller.Servis.OrderByDescending(x => x.RealPrice).ToList());
        }
    }

    
}