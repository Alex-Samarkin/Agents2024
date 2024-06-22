using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using AgentsLibrary1.AgentsLibrary1;

namespace AgentsLibrary1
{
    public class RandomGenerator
    {
        #region RandomGenerator
        [DisplayName("Seed"), Description("Seed for random generator"), Category("Random")]
        public int Seed { get; set; } = 0;
        [DisplayName("Random"), Description("Random generator"), Category("Random")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Random Rnd { get; set; } = new MathNet.Numerics.Random.MersenneTwister();
        /// <summary>
        /// ctor
        /// </summary>
        public RandomGenerator()
        {
            Seed = (int)DateTime.Now.Ticks;
            Rnd = new MathNet.Numerics.Random.MersenneTwister(Seed);
        }
        /// <summary>
        /// ctor with seed
        /// </summary>
        /// <param name="seed"></param>
        public RandomGenerator(int seed = 0)
        {
            if(seed == 0) seed = (int)DateTime.Now.Ticks;

            Seed = seed;
            Rnd = new MathNet.Numerics.Random.MersenneTwister(Seed);
        }
        /// <summary>
        /// reset random generator
        /// </summary>
        public void Reset()
        {
            Rnd = new MathNet.Numerics.Random.MersenneTwister(Seed);
        }
        /// <summary>
        /// reset random generator with seed
        /// </summary>
        /// <param name="seed"></param>
        public void Reset(int seed)
        {
            if (seed == 0) seed = (int)DateTime.Now.Ticks;

            Seed = seed;
            Rnd = new MathNet.Numerics.Random.MersenneTwister(Seed);
        }
        /// <summary>
        /// simple next double
        /// </summary>
        /// <returns>next random double</returns>
        public double NextDouble()
        {
            return Rnd.NextDouble();
        }
        /// <summary>
        /// next double in range
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">to</param>
        /// <returns>next random double</returns>
        public double NextDouble(double min, double max)
        {
            return min + (max - min) * Rnd.NextDouble();
        }
        /// <summary>
        /// next int
        /// </summary>
        /// <returns>next random int</returns>
        public int NextInt()
        {
            return Rnd.Next();
        }
        /// <summary>
        /// next int in range
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">to</param>
        /// <returns>next random int</returns>
        public int NextInt(int min, int max)
        {
            return Rnd.Next(min, max);
        }
        #endregion
        #region Uniform Distribution
        /// <summary>
        /// next uniform double
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">to</param>
        /// <returns>next uniform double in range</returns>
        public double NextUniform(double min, double max)
        {
            return ContinuousUniform.Sample(Rnd, min, max);
        }

        /// <summary>
        /// next uniform double in interval
        /// </summary>
        /// <param name="di">interval</param>
        /// <returns>next uniform double in range</returns>
        public double NextUniform(DoubleInterval di)
        {
            return ContinuousUniform.Sample(Rnd, di.Min, di.Max);
        }
        /// <summary>
        /// next uniform int
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">to</param>
        /// <returns>next uniform int</returns>
        public int NextUniform(int min, int max)
        {
            return DiscreteUniform.Sample(Rnd, min, max);
        }
        /// <summary>
        /// next uniform int in interval
        /// </summary>
        /// <param name="ii">interval</param>
        /// <returns>next uniform int</returns>
        public int NextUniform(IntInterval ii)
        {
            return DiscreteUniform.Sample(Rnd, ii.Min, ii.Max);
        }
        #endregion

        #region Normal Distribution
        /// <summary>
        /// next normal double
        /// </summary>
        /// <param name="mean">mean</param>
        /// <param name="stddev">SD</param>
        /// <returns>next normal double</returns>
        public double NextNormal(double mean, double stddev)
        {
            return Normal.Sample(Rnd, mean, stddev);
        }
        /// <summary>
        /// next normal double in interval and wwith mean as value
        /// 
        /// NOTE: min and max used to calculate sd = (max-min)/6.0
        /// NOTE: if mean is not in center of interval, then data is clamed from left or right,
        /// so mean is in center of random data, but not in center of interval
        /// for asymmetric normal distribution use NextAsymmetricNormal
        /// NOTE: if clamp is true, then clampp to min and max
        /// </summary>
        /// <param name="di">interval and mean</param>
        /// <param name="clamp">clamp or not</param>
        /// <returns>next double</returns>
        public double NextNormal(DoubleInterval di, bool clamp = true)
        {
            var sd = (di.Max - di.Min) / 6.0;
            var x = Normal.Sample(Rnd, di.Value, sd);
            if (clamp)
            {
                if (x < di.Min) x = di.Min;
                if (x > di.Max) x = di.Max;
            }
            return x;
        }
        /// <summary>
        /// next normal int
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int NextNormal(int min, int max)
        {
            return (int) Math.Round(Normal.Sample(Rnd, (max+min)/2.0, (max-min)/4.0),0);
        }
        /// <summary>
        /// next normal int in interval
        /// </summary>
        /// <param name="ii"></param>
        /// <param name="clamp"></param>
        /// <returns></returns>
        public int NextNormal(IntInterval ii, bool clamp = true)
        {
            var sd = (ii.Max - ii.Min) / 4.0;
            var x = Normal.Sample(Rnd, ii.Value, sd);
            if (clamp)
            {
                if (x < ii.Min) x = ii.Min;
                if (x > ii.Max) x = ii.Max;
            }
            return (int)Math.Round(x, 0);
        }
        #endregion
        #region Asymmetric Normal Distribution
        /// <summary>
        /// next asymmetric normal double
        /// generated using SkewedGeneralizedT distribution, 
        /// there is mean , scale, skew, aand two parameters for curtosis
        /// mean is tacen from interval, 
        /// scale is (max-min)/6.0 calculated from interval
        /// skew is calculated from interval, using formula
        /// lets range = max-min
        /// lets left = (max-mean)
        /// lets right = (min-mean)
        /// so skew is given by (right-left)/range
        /// skew must be in range [-1,1]
        /// 
        /// last two parameters are for curtosis, and first must be 2.0
        /// second is for curtosis, and must be large number, for example 1000.0
        /// tto form bell-shaped curve as result distribution
        /// </summary>
        /// <param name="di">interval</param>
        /// <param name="clamp">clamp or not</param>
        /// <returns>nex double, asymmetrically distributed</returns>
        public double NextAsymmetricNormal(DoubleInterval di, bool clamp = true)
        {
            var loc = di.Value;
            var scale = (di.Max - di.Min) / 6.0;
            var skew = ((di.Max-di.Value)+(di.Min-di.Value))/(di.Max-di.Min);
            var x = SkewedGeneralizedT.Sample(Rnd, loc, scale, skew,2.0,1000.0);
            if (clamp)
            {
                if (x < di.Min) x = di.Min;
                if (x > di.Max) x = di.Max;
            }
            return x;
        }
        #endregion
    }
}
