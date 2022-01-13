using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private static int temporaryJobID = -1;
        private static int selectedJobID = -1;
        public static BindingList<Job> Jobs { get; set; } = new BindingList<Job>();

        private void AddNewJob_Click(object sender, RoutedEventArgs e)
        {
            AddNewJob jobCreation = new AddNewJob();
            jobCreation.ShowDialog();
        }

        private void JobDateSort_Click(object sender, RoutedEventArgs e)
        {
            Jobs.OrderBy(jobs => jobs.JobDate);
        }

        private void JobListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Job selectedJob)
            {
                Edit.IsEnabled = true;
                selectedJobID = selectedJob.JobID;
                JobNameTextBox.Text = selectedJob.JobName;
                JobDateDatePicker.Text = selectedJob.JobDate;
                JobDescriptionTextBox.Text = selectedJob.JobDescription;
            }
            else if (Edit.IsEnabled == true) Edit.IsEnabled = false;
        }

        private void EditJob_Click(object sender, RoutedEventArgs e)
        {
            Button? editButton = sender as Button;

            switch (editButton.Content.ToString())
            {
                case "Edit Job":
                    JobNameTextBox.IsEnabled = true;
                    JobDateDatePicker.IsEnabled = true;
                    JobDescriptionTextBox.IsEnabled = true;
                    editButton.Content = "Save Changes";
                    CancelChanges.IsEnabled = true;
                    break;
                default:
                    UpdateJob();
                    JobNameTextBox.IsEnabled = false;
                    JobDateDatePicker.IsEnabled = false;
                    JobDescriptionTextBox.IsEnabled = false;
                    editButton.Content = "Edit Job";
                    CancelChanges.IsEnabled = false;
                    break;
            }
        }

        private void UpdateJob()
        {
            Jobs[selectedJobID].JobName = JobNameTextBox.Text;
            Jobs[selectedJobID].JobDescription = JobDescriptionTextBox.Text;
            Jobs[selectedJobID].JobDate = JobDateDatePicker.Text;
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            JobNameTextBox.Text = Jobs[selectedJobID].JobName;
            JobDateDatePicker.Text = Jobs[selectedJobID].JobDate;
            JobDescriptionTextBox.Text = Jobs[selectedJobID].JobDescription;
            CancelChanges.IsEnabled = false;
            JobNameTextBox.IsEnabled = false;
            JobDateDatePicker.IsEnabled = false;
            JobDescriptionTextBox.IsEnabled = false;
            Edit.Content = "Edit Job";
        }

        private async void GetJobs()
        {
            SqlDataReader reader = await DatabaseConnection.GetJobRecords();

            int tempJobID = -1;

            while (await reader.ReadAsync())
            {
                if (tempJobID == -1) tempJobID = reader.GetInt32(0);
                Job job = new Job(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetValue(3).ToString());
                Jobs.Add(job);
            }

            if (tempJobID != -1) temporaryJobID = tempJobID + 1;
            else temporaryJobID = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                DatabaseConnection.Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect to the database.{Environment.NewLine + Environment.NewLine}Exception: {ex.Message}.{Environment.NewLine + Environment.NewLine}Aborting application.", "Error connecting to database");
                Application.Current.Shutdown();
            }

            GetJobs();
        }
    }
}