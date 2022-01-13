using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMonitor
{
    /// <summary>
    /// Handles interactivity between the client and the database.
    /// </summary>
    public static class DatabaseConnection
    {
        /// <summary>
        /// Stores the connection string to the database and is used when instantiating the "SqlConnection" class which the "Connection" property uses.
        /// </summary>
        private static readonly string connectionString = @"Data Source=DYLAN-DESKTOP\SQLExpress;Initial Catalog=JobMonitor;User ID=user;Password=321";
        /// <summary>
        /// Used to connect to and access the database.
        /// </summary>
        public static SqlConnection Connection { get; } = new SqlConnection(connectionString);

        /// <summary>
        /// Gets all rows and columns of the Job table.
        /// </summary>
        /// <returns>A "SqlDataReader" if any Job records are returned, otherwise null.</returns>
        public async static Task<SqlDataReader> GetJobRecords()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Job");
            sqlCommand.Connection = Connection;
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            return reader;
        }

        /// <summary>
        /// Inserts a new row into the database for the "Job" table.
        /// </summary>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Description of the job.</param>
        /// <param name="jobDate">Date of the job.</param>
        /// <returns>Boolean representing whether or not a row was inserted into the "Job" table.</returns>
        public async static Task<bool> InsertJob(string jobName, string jobDescription, DateTime jobDate)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Job (JobName, JobDescription, JobDate) " +
                                                    $"VALUES('{jobName}', '{jobDescription}', {jobDate})", Connection);
            int rowsAffected = await sqlCommand.ExecuteNonQueryAsync();
            
            if (rowsAffected > 0) return true;
            else return false;
        }
    }
}
