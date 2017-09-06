using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4},
            };

            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach (var cust in phxCusts)
            {
                Console.WriteLine(cust.City + " " + cust.FirstName);
            }

            //var data = new ProcessData();
            //BizRulesDelegate addDel = (x, y) => x + y;
            //BizRulesDelegate multiplyDel = (x, y) => x * y;
            ////data.Process(2, 3, addDel);
            ////data.Process(2, 3, multiplyDel);

            //Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            //Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            ////data.ProcessAction(2, 3, myAction);
            ////data.ProcessAction(2, 3, myAction);

            //Func<int, int, int> funcAddDel = (x, y) => x + y;
            //Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            ////data.ProcessFunc(3, 2, funcAddDel);
            //data.ProcessFunc(3, 2, funcMultiplyDel);

            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
                Console.WriteLine("Still working on " + e.WorkType);
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

    }
}
