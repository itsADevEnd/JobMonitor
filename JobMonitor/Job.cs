using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMonitor
{
    public class Job
    {
        public string JobName { get; set; }
        public DateTime JobDate { get; set; }
        public string JobDescription { get; set; }

        public Job(string jobName, string jobDate, string jobDescription)
        {
            JobName = jobName;
            string[] jobDateSplit = jobDate.Split('/');
            JobDate = new DateTime(int.Parse(jobDateSplit[2]), int.Parse(jobDateSplit[1]), int.Parse(jobDateSplit[0]));
            JobDescription = jobDescription;
        }
    }
}
