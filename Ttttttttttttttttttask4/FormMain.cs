using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solution;

namespace Task_4
{
    public partial class FormMain : Form
    {
        
        List<Thread> tw_list;
        int max;
        Graphics g;
        int i = 0;
        int j = 0;

        MyDraw m;
        object locker = new object();

        Factory f;
        public FormMain()
        {
            m = new MyDraw();
            InitializeComponent();
            f = new Factory();
            max = 3;
            tw_list = new List<Thread>();
            g = pictureBox1.CreateGraphics();
        }

        public void Start1(Object w)
        {
            while (true)
            {
                ILifter l = f.GetLifter();
                while (l == null)
                {
                    l = f.GetLifter();
                }
                f.workers[(int)w].Start(f.stanoks[(int)w], l);
                f.AddLifter(l);
            }
        }

        public void Draw()
        {
            MyDraw myDraw = new MyDraw();
            while(true)
            {
                myDraw.DrawWorker(g, f.workers);
                myDraw.DrawLifter(g, f.lifters1);
                
            }
        }

        private void AddStanok_Click(object sender, EventArgs e)
        {
            if (f.workers.Count < max)
            {
                Worker w = new Worker();
                f.AddWorker(w);
                Stanok s = new Stanok(j);
                j++;
                f.AddStanok(s);
                if (f.lifters.Count < max - 1)
                {
                    ILifter l = new Lifter();
                    f.AddLifter(l);
                }
                Thread thread_worker = new Thread(new ParameterizedThreadStart(Start1));
                tw_list.Add(thread_worker);
                MyDraw d = new MyDraw();
                d.DrawWorker(g, f.workers);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Thread thread_draw = new Thread(new ThreadStart(Draw));
            thread_draw.Start();
            foreach (Thread t in tw_list)
            {
                t.Start(i);
                i++;
            }
            i = 0;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
