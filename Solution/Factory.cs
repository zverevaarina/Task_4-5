using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Solution
{
    public class Factory
    {
        public List<Worker> workers;
        public Queue<ILifter> lifters;
        public Queue<ILifter> lifters1;
        public List<Stanok> stanoks;
        static object locker = new object();

        public Factory()
        {
            workers = new List<Worker>();
            lifters = new Queue<ILifter>();
            lifters1 = new Queue<ILifter>();
            stanoks = new List<Stanok>();
        }

        public void AddWorker(Worker w)
        {
            if (w != null)
                workers.Add(w);
        }

        public void AddStanok(Stanok s)
        {
            if (s != null)
                stanoks.Add(s);
        }

        public void AddLifter(ILifter l)
        {
            if (l != null)
            {
                lifters.Enqueue(l);
                if (lifters1.Count < 3)
                {
                    lifters1.Enqueue(l);
                }
            }
        }

        // lock на очередь
        public ILifter GetLifter()
        {
            lock (locker)
            {
                if (lifters.Count == 0)
                    Thread.Sleep(3000);
                if (lifters.Count != 0)
                {
                    return lifters.Dequeue();
                }
            }
            return null;
        }
    }
}
