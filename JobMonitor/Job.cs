using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobMonitor
{
    public class Job : INotifyPropertyChanged
    {
        private static int id = 0;
        private string jobName = "";
        private string jobDate = "";
        private string jobDescription = "";

        public int JobID { get; set; }
        public string JobName
        {
            get
            {
                return jobName;
            }
            set
            {
                if (value != jobName)
                {
                    jobName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string JobDate
        {
            get
            {
                return jobDate;
            }
            set
            {
                if (value != jobDate)
                {
                    jobDate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string JobDescription
        {
            get
            {
                return jobDescription;
            }
            set
            {
                if (value != jobDescription)
                {
                    jobDescription = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Job(string jobName, string jobDescription, string jobDate)
        {
            JobID = id;
            JobName = jobName;
            string[] jobDateSplit = jobDate.Split('/');
            JobDate = new DateTime(int.Parse(jobDateSplit[2]), int.Parse(jobDateSplit[1]), int.Parse(jobDateSplit[0])).ToShortDateString();
            JobDescription = jobDescription;
            JobDate = jobDate;
            id++;
        }

        public Job(int jobID, string jobName, string jobDescription, string jobDate)
        {
            JobID = jobID;
            JobName = jobName;
            JobDescription = jobDescription;
            JobDate = jobDate;
        }
    }
}
