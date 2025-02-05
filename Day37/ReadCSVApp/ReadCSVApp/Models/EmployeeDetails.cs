using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSVApp.Models
{
    internal class EmployeeDetails
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? MgrId { get; set; }
        public DateTime DOJ { get; set; }
        public decimal Sal { get; set; }
        public decimal? Comm { get; set; }
        public int Deptno { get; set; }

        public EmployeeDetails(int empno, string ename, string job, int? mgrId, DateTime doj, decimal sal, decimal? comm, int deptno)
        {
            Empno = empno;
            Ename = ename;
            Job = job;
            MgrId =mgrId;
            DOJ = doj;
            Sal = sal;
            Comm = comm;
            Deptno = deptno;
        }
    }

}
