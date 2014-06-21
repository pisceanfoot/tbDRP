using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tbDRP
{
    public class ThreadRunner
    {
        public static void Run(Action runner)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Work), runner);
        }

        private static void Work(object obj)
        {
            Action runner = (Action)obj;
            runner();
        }
    }
}
