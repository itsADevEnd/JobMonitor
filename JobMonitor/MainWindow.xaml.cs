using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace JobMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Job> Jobs { get; set; } = new ObservableCollection<Job>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNewJob_Click(object sender, RoutedEventArgs e)
        {
            AddNewJob jobCreation = new AddNewJob();
            jobCreation.ShowDialog();
        }

        private void JobDateSort_Click(object sender, RoutedEventArgs e)
        {
            Jobs.OrderBy(jobs => jobs.JobDate);
        }
    }
}
