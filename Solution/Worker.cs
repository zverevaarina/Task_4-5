using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Solution
{
    public class Worker
    {
        public bool State { get; set; }
        public bool Detail { get; set; }
        Random r;

        public delegate void DoWork(Stanok stanok, ILifter lifter);
        public event DoWork StartWork;
        public event DoWork StopWork;
        public Worker()
        {
            State = false;
            Detail = false;
            r = new Random();
            StartWork += StartDoDetail;
            StopWork += StopDo;
        }

        public void Start(Stanok stanok, ILifter lifter)
        {
            StartWork(stanok, lifter);
        }

        public void StartDoDetail(Stanok stanok,ILifter lifter)
        {
            if (!stanok.State)
                stanok.Turn();
            State = true;
            int k = r.Next(2, 5);
            Thread.Sleep(k*1000);
            StopWork(stanok, lifter);
        }

        public void StopDo(Stanok stanok, ILifter lifter)
        {
            Detail = true;
            State = false;
            stanok.Turn();
            int k = r.Next(1, 3);
            Thread.Sleep(k * 1000);
            CallLifter(lifter,stanok);
        }

        public void CallLifter(ILifter lifter,Stanok stanok)
        {
            lifter.GetDetail(stanok);
            //Thread.Sleep(3000);
            Detail = false;
        }
    }
}
