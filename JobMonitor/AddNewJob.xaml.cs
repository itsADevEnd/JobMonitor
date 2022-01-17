using System;
using System.Collections.Generic;
using System.Globalization;
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

        private async void AddJob_Click(object sender, RoutedEventArgs e)
        {
            if (JobName.Text.Length > 0 && JobName.Text.Length <= 40)
            {
                if (JobDescription.Text.Length > 0 && JobDescription.Text.Length <= 500)
                {
                    DateTime jobDate = DateTime.Parse(JobDate.Text);

                    if (await DatabaseConnection.InsertJob(JobName.Text, JobDescription.Text, jobDate) == true)
                    {
                        MainWindow.Jobs.Add(new Job(JobName.Text, JobDescription.Text, jobDate));
                        Close();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("There was a problem trying to add this job in the database. Click 'Yes' to ignore this message and try again, otherwise click 'No' to return to the Job List.", "Unable to Add Job", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No) Close();
                    }
                }
                else
                {
                    MessageBox.Show("The job description is either empty or is greater than 500 characters.", "Warning");
                }
            }
            else
            {
                MessageBox.Show("You must either give the job a name or it is greater than 40 characters.", "Warning");
            }
        }
    }
}
