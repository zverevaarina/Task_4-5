using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Stanok
    {
        public bool State { get; set; }
        public int Index { get; set; }

        public Stanok(int i)
        {
            State = false;
            Index = i;
        }

        public void Turn()
        {
            if (!State)
            {
                State = true;
            }
            else
                State = false;
        }
    }
}
