using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMonitor
{
    public class Job
    {
        private static int id = 0;
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDate { get; set; }
        public string JobDescription { get; set; }

        public Job(string jobName, string jobDate, string jobDescription)
        {
            JobId = id;
            JobName = jobName;
            string[] jobDateSplit = jobDate.Split('/');
            JobDate = new DateTime(int.Parse(jobDateSplit[2]), int.Parse(jobDateSplit[1]), int.Parse(jobDateSplit[0])).ToShortDateString();
            JobDate = jobDate;
            JobDescription = jobDescription;
            id++;
        }
    }
}
