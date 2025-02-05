using System.Reflection.PortableExecutable;
using ReadCSVApp.Models;
using System.Linq;

namespace GenericDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = ReadCsvAndProcess("C:\\Users\\admin\\Downloads\\emp_duplicate.csv"); //Make a list by removing unwanted characters
            var uniqueEmployeeEmpnos = new HashSet<int>();  // To hold unique Empno values
            var uniqueEmployeeList = new List<EmployeeDetails>(); // List to store unique employees

            
            foreach (var employee in employees)
            {
                if (uniqueEmployeeEmpnos.Add(employee.Empno)) // If hash set is adding Empno, then it is unique
                {
                    uniqueEmployeeList.Add(employee);
                }
            }

            
            Console.WriteLine($"Total unique employees: {uniqueEmployeeList.Count}");

            var jobCount = GroupEmployeesByJob(uniqueEmployeeList); //Dictionary to group the employees based on JOb.
            Console.WriteLine("JOBWISE EMPLOYEE COUNT");
            foreach (var job in jobCount)
            {
                Console.WriteLine($"{job.Key}: {job.Value} employees");
            }
        }
        private static List<EmployeeDetails> ReadCsvAndProcess(string filePath)
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            StreamReader reader = new StreamReader(filePath);
            bool isHeader = true;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }
                line = line.Replace("'", "");
                line = line.Replace("\"", "");
                string[] values = line.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                    values[i] = values[i].Replace("'", "");
                }
                int empno = int.TryParse(values[0], out empno) ? empno : 0;
                string ename = values[1];
                string job = values[2];
                int? mgrId = string.IsNullOrEmpty(values[3]) ? (int?)null : int.TryParse(values[3], out int mid) ? mid : (int?)null;
                DateTime doj = DateTime.TryParse(values[4], out DateTime parsedDOJ) ? parsedDOJ : DateTime.MinValue;
                decimal sal = decimal.TryParse(values[5], out decimal parsedSal) ? parsedSal : 0.0m;
                decimal? comm = string.IsNullOrEmpty(values[6]) ? (decimal?)null : decimal.TryParse(values[6], out decimal parsedComm) ? parsedComm : (decimal?)null;
                int deptno = int.TryParse(values[7], out int parsedDept) ? parsedDept : 0;

                employeeDetails.Add(new EmployeeDetails(empno, ename, job, mgrId, doj, sal, comm, deptno));
            }            
            reader.Close();
            return employeeDetails;
        }
        static Dictionary<string, int> GroupEmployeesByJob(List<EmployeeDetails> employees) 
        {
            Dictionary<string, int> jobCount = new Dictionary<string, int>();

            foreach (var employee in employees)
            {
                if (jobCount.ContainsKey(employee.Job))
                {
                    jobCount[employee.Job]++;
                }
                else
                {
                    jobCount[employee.Job] = 1;
                }
            }

            return jobCount;
        }
    }
}
