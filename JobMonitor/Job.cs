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
        public static int NextJobID { get; set; }
        private string jobName = "";
        private DateTime jobDate;
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
        public DateTime JobDate
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

        public Job(string jobName, string jobDescription, DateTime jobDate)
        {
            JobID = NextJobID;
            JobName = jobName;
            JobDate = jobDate;
            JobDescription = jobDescription;
            JobDate = jobDate;
            NextJobID++;
        }

        public Job(int jobID, string jobName, string jobDescription, DateTime jobDate)
        {
            JobID = jobID;
            JobName = jobName;
            JobDescription = jobDescription;
            JobDate = jobDate;
        }
    }
}
