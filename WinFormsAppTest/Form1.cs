using AgentsLibrary1;
using System.Diagnostics;

namespace WinFormsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = Point;
        }

        // APoint
        public APoint Point { get; set; } = new APoint();

        private void button1_Click(object sender, EventArgs e)
        {
            Point.X += 1;
            Point.Y += 1;
            Point.Vel += 1;
            Point.Angle += 1;
            Point.AngleVel += 0.01;
            Point.Accel += 1;
            propertyGrid1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point = Point.Clone();
            propertyGrid1.SelectedObject = Point;
            Point.Update();
            propertyGrid1.Refresh();
        }

        // AAgent
        public AAgent Agent { get; set; } = new AAgent();

        private void button3_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Agent;
            propertyGrid1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // var aa = new List<AAgent>();
            var N = 1000000;
            
            /// measure time from here
            /// 
            var sw = new Stopwatch();
            /// start stopwatch
            /// 
            sw.Start();

            // create array of N agents called aa
            var aa = new AAgent[N];

            for (int i = 0; i < N; i++)
            {
                aa[i] = new AAgent();
            }  
            /// stop stopwatch
            /// 
            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }
    }
}
