﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsLibrary1
{
    public class APoint : IUpdatable<APoint>,ICloneable
    {
        [DisplayName("Код"),Category("Point")]
        public long Id { get; set; } =0;
        [DisplayName("X"), Category("Point")]
        public double X { get; set; } = 0;
        [DisplayName("Y"), Category("Point")]
        public double Y { get; set; } = 0;
        [DisplayName("Скорость"), Category("Point")]
        public double Vel { get; set; } = 0;
        [DisplayName("Угол"), Category("Point")]
        public double Angle { get; set; } = 0;
        [DisplayName("Угловая скорость"), Category("Point")]
        public double AngleVel { get; set; } = 0;
        [DisplayName("Ускорение"), Category("Point")]
        public double Accel { get; set; } = 0;

        public APoint()
        {
        }
        public APoint(long id, double x, double y, double vel, double angle, double angleVel, double accel)
        {
            Id = id;
            X = x;
            Y = y;
            Vel = vel;
            Angle = angle;
            AngleVel = angleVel;
            Accel = accel;
        }
        public APoint(APoint p)
        {
            Id = p.Id;
            X = p.X;
            Y = p.Y;
            Vel = p.Vel;
            Angle = p.Angle;
            AngleVel = p.AngleVel;
            Accel = p.Accel;
        }
        public APoint Clone()
        {
            return new APoint(this);
        }
        public override string ToString()
        {
            return $"Id={Id}, X={X}, Y={Y}, Vel={Vel}, Angle={Angle}, AngleVel={AngleVel}, Accel={Accel}";
        }

        public void Update()
        {
            // throw new NotImplementedException();
            Angle += AngleVel;
            Vel += Accel;
            Y += Vel * Math.Sin(Angle);
            X += Vel * Math.Cos(Angle);
            //
            Accel = 0;
            AngleVel = 0;
        }
        public void Update(double dAngleVel, double dAccel)
        {
            // throw new NotImplementedException();
            AngleVel += dAngleVel;
            Accel += dAccel;
            Update();
        }

        public APoint DeepCopy()
        {
            // make a new object and copy all fields
            return new APoint(this);
        }

        public void CopyFrom(APoint copyObject)
        {
            // throw new NotImplementedException();
            Id = copyObject.Id;
            X = copyObject.X;
            Y = copyObject.Y;
            Vel = copyObject.Vel;
            Angle = copyObject.Angle;
            AngleVel = copyObject.AngleVel;
            Accel = copyObject.Accel;
        }

        object ICloneable.Clone()
        {
            // make a new object and copy all fields
            return new APoint(this);
        }
    }
}
