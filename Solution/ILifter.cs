using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public interface ILifter
    {
        bool State { get; set; }
        int Index { get; set; }
        void GetDetail(Stanok s);
    }
}
