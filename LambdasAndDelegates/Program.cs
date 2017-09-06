using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    class Program
    {

        

        static void Main(string[] args)
        {
            
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
