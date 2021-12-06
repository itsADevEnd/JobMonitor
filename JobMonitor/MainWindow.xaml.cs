﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private static int temporaryJobId = -1;

        public static BindingList<Job> Jobs { get; set; } = new BindingList<Job>()
        {
            new Job("Make wooden frame", "12/02/2022", "Make a wooden frame for our client."),
            new Job("Build crafting table", "14/12/2021", "Build a table to be used for crafting."),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long"),
            new Job("This is 40 characters long which is being tested n", "14/12/2027", "40 characters long")
        };

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

        private void JobListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Job? selectedJob = (sender as ListView).SelectedItem as Job;

            if (selectedJob != null)
            {
                Edit.IsEnabled = true;
                temporaryJobId = selectedJob.JobId;
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
                    break;
                default:
                    UpdateJob();
                    JobNameTextBox.IsEnabled = false;
                    JobDateDatePicker.IsEnabled = false;
                    JobDescriptionTextBox.IsEnabled = false;
                    editButton.Content = "Edit Job";
                    break;
            }
        }

        private void UpdateJob()
        {
            Jobs[temporaryJobId].JobName = JobNameTextBox.Text;
            Jobs[temporaryJobId].JobDescription = JobDescriptionTextBox.Text;
            Jobs[temporaryJobId].JobDate = JobDateDatePicker.Text;
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
