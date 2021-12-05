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

namespace JobMonitor
{
    /// <summary>
    /// Interaction logic for AddNewJob.xaml
    /// </summary>
    public partial class AddNewJob : Window
    {
        public AddNewJob()
        {
            InitializeComponent();
        }

        private void JobName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? jobNameTextBox = sender as TextBox;

            if (jobNameTextBox.Text == "Job name here...")
            {
                jobNameTextBox.Text = "";
            }
        }

        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            if (JobName.Text != "Job name here..." && JobName.Text.Length > 0)
            {
                if (JobDescription.Text.Length > 0)
                {
                    MainWindow.Jobs.Add(new Job(JobName.Text, JobDate.Text, JobDescription.Text));
                    Close();
                }
                else
                {
                    MessageBox.Show("You must have a job name for this job.");
                }
            }
            else
            {
                MessageBox.Show("You must have a job name for this job.");
            }
        }
    }
}
