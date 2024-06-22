using ScottPlot.AxisRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsLibrary1
{
    public class APointBuilder
    {
        public RandomGenerator Rnd { get; set; } = new RandomGenerator();
        static int _id = 0;
        public APoint Build(int maxx = 1000, int maxy = 1000, double max_vel = 5)
        {
            APoint p = new APoint();
            p.Id = _id++;
            p.X = Rnd.NextUniform(0,maxx);
            p.Y = Rnd.NextUniform(0,maxy);
            p.Vel = Rnd.NextNormal(max_vel/2.0, max_vel/6.0);
            p.Angle = Rnd.NextUniform(0, 2 * Math.PI);

            return p;
        }

    }
}
