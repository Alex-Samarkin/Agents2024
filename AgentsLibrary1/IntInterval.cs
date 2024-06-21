using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace AgentsLibrary1
    {
        public class TInterval<T> where T : struct, IComparable<T>
        {
            [DisplayName("Ограничение"),Description("Включить ограничение")]
            public bool Clamp { get; set; } = true;
            [DisplayName("Минимум"),Description("Минимальное значение"),Category("Interval")]
            public T Min { get; set; } = default;
            [DisplayName("Максимум"),Description("Максимальное значение"),Category("Interval")]
            public T Max { get; set; } = default;
            protected T _value = default;
            [DisplayName("Значение"),Description("Текущее значение"),Category("Interval")]
            public T Value
            {
                get => _value;
                set
                {
                    if (Clamp)
                    {
                        if (value.CompareTo(Min) < 0) value = Min;
                        if (value.CompareTo(Max) > 0) value = Max;
                        _value = value;
                    }
                    else
                    {
                        _value = value;
                    }
                }
            }
            public TInterval()
            {
            }
            public TInterval(T value, T min = default, T max = default)
            {
                Value = value;
                Min = min;
                Max = max;
            }
            public TInterval(TInterval<T> interval)
            {
                Value = interval.Value;
                Min = interval.Min;
                Max = interval.Max;
            }
            public TInterval<T> Clone()
            {
                return new TInterval<T>(this);
            }
            public override string ToString()
            {
                return $"Value = {Value} [{Min}; {Max}]";
            }
            public static implicit operator T(TInterval<T> interval)
            {
                return interval.Value;
            }
            public static implicit operator TInterval<T>(T value)
            {
                return new TInterval<T>(value);
            }
        }

        public class IntInterval : TInterval<int>
        {
            public IntInterval()
            {
            }
            public IntInterval(int value, int min = 0, int max = 100) : base(value, min, max)
            {
            }
            public IntInterval(IntInterval interval) : base(interval)
            {
            }
            public new IntInterval Clone()
            {
                return new IntInterval(this);
            }
        }

        public class DoubleInterval : TInterval<double>
        {
            public DoubleInterval()
            {
            }
            public DoubleInterval(double value, double min = 0, double max = 100) : base(value, min, max)
            {
            }
            public DoubleInterval(DoubleInterval interval) : base(interval)
            {
            }
            public new DoubleInterval Clone()
            {
                return new DoubleInterval(this);
            }
        }

        public class DecimalInterval : TInterval<decimal>
        {
            public DecimalInterval()
            {
            }
            public DecimalInterval(decimal value, decimal min = 0, decimal max = 100) : base(value, min, max)
            {
            }
            public DecimalInterval(DecimalInterval interval) : base(interval)
            {
            }
            public new DecimalInterval Clone()
            {
                return new DecimalInterval(this);
            }
        }
    }
}
