using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        page2Entities p2 = new page2Entities();
        public Page2()
        {
            InitializeComponent();
            DG1.ItemsSource = p2.mdates.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = p2.mdates.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            mdate rec = new mdate();
            rec.namee =na.Text;
            rec.email = em.Text;
            rec.departmint = de.Text;
            p2.mdates.Add(rec);
            p2.SaveChanges();
            MessageBox.Show("Data Saved Sucssfully");
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = p2.mdates.Where(x => x.namee.Contains(na.Text)).ToList();                                                                      
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            mdate ff = p2.mdates.FirstOrDefault(x => x.namee == na.Text);
            ff.email = em.Text;
            ff.departmint= de.Text;
            p2.mdates.AddOrUpdate(ff);
            p2.SaveChanges();
            MessageBox.Show("Update");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            p2.mdates.Remove(p2.mdates.First(x => x.namee == na.Text));
            p2.SaveChanges();
            MessageBox.Show("Remove");
        }
    }
}
