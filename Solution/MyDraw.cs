using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution
{
    public class MyDraw
    {
        Image dont_w;
        Image working;
        Image box;
        Image lifter;
        Image asd;

        public MyDraw()
        {
            dont_w = Image.FromFile(System.IO.Path.GetFullPath(@"img\1.jpg"));
            working = Image.FromFile(System.IO.Path.GetFullPath(@"img\2.jpg"));
            box = Image.FromFile(System.IO.Path.GetFullPath(@"img\3.png"));
            lifter = Image.FromFile(System.IO.Path.GetFullPath(@"img\4.png"));
            asd = Image.FromFile(System.IO.Path.GetFullPath(@"img\5.png"));
        }
        
        public void DrawWorker(Graphics g, List<Worker> workers)
        {
            int x = 0;
            int y = 0;

            if (workers != null)
            {
                foreach(Worker w in workers)
                {
                    if (w.State)
                    {
                        g.DrawImage(working, x, y, 200, 200);
                    }
                    else
                        g.DrawImage(dont_w, x, y, 200, 200);
                    if (w.Detail)
                    {
                        g.DrawImage(box, x + 130, y + 130, 70, 70);
                    }
                    y += 200;
                }
            }
        }

        public void DrawLifter(Graphics g, Queue<ILifter> lifters)
        {
            int x = 200;
            int y = 0;
           
            if (lifters != null)
            {
                foreach (ILifter l in lifters)
                {
                    if (l.State)
                        switch (l.Index)
                        {
                            case 0:
                                g.DrawImage(lifter, x, y, 200, 200);
                                break;
                            case 1:
                                g.DrawImage(lifter, x, y+200, 200, 200);
                                break;
                            case 2:
                                g.DrawImage(lifter, x, y+200, 200, 200);
                                break;
                        }
                    if (!l.State)
                        switch (l.Index)
                        {
                            case 0:
                                g.DrawImage(asd, x, y, 200, 200);
                                break;
                            case 1:
                                g.DrawImage(asd, x, y + 200, 200, 200);
                                break;
                            case 2:
                                g.DrawImage(asd, x, y + 200, 200, 200);
                                break;
                        }
                }
            }  
        }
    }
}
