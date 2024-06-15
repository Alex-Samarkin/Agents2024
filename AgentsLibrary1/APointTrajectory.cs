using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsLibrary1
{
    public class APointTrajectory
    {
        public List<APoint> Point { get; set; } = new List<APoint>();
        public List<double> Time { get; set; } = new List<double>();
        
        // extract X and Y values from the list of points
        public List<double> X => Point.Select(x => x.X).ToList();
        public List<double> Y => Point.Select(x => x.Y).ToList();
        // extract velosity from the list of points
        public List<double> Vel => Point.Select(x => x.Vel).ToList();
        // extract angle from the list of points
        public List<double> Angle => Point.Select(x => x.Angle).ToList();
        // find x and y proection of the velocity vector from the list of points
        public List<double> VelX => Point.Select(x => x.Vel * Math.Cos(x.Angle)).ToList();
        public List<double> VelY => Point.Select(x => x.Vel * Math.Sin(x.Angle)).ToList();
        // extract a point at Time: find index of time in the list of times and return the point with the same index
        public APoint this[double time]
        {
            get
            {
                int index = Time.FindIndex(x => x == time);
                return Point[index];
            }
        }
        // extract a point at index
        public APoint this[int index]
        {
            get
            {
                return Point[index];
            }
        }
        // extract a time at index
        public double TimeAt(int index)
        {
            return Time[index];
        }
        // extract last point
        public APoint LastPoint
        {
            get
            {
                return Point.Last();
            }
        }
    }
}
