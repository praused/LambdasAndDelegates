using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
   
    class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //pause each iteration by 1 second so we can watch it work
                System.Threading.Thread.Sleep(1000); //Never do this in real software
                //Call helper method to raise the event
                OnWorkPerformed(i + 1, workType);
            }
            //Call helper method to raise the event
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Raise an event by using the delegate, the event must be cast into its delegate type
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this,new WorkPerformedEventArgs(hours,workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //Raise an event by using the delegate, the event must be cast into its delegate type
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
