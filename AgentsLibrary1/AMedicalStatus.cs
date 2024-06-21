using AgentsLibrary1.AgentsLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentsLibrary1
{
    /// <summary>
    /// Medical status of a person
    /// Медицинский статус человека
    /// </summary>
    public class AMedicalStatus
    {
        /// <summary>
        /// код
        /// </summary>
        // Id with a default value of 0
        [DisplayName("Идентификатор"), Category("UserData")]
        public int Id { get; set; } = 0;
        /// <summary>
        /// возраст
        /// </summary>
        // Age with a default value of 0 and from diapason from 5 to 120 with checking value
        [DisplayName("Возраст"), Category("PersonalData")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IntInterval Age { get; set; } = new IntInterval { Min = 5, Max = 120, Value = 41 };

        /// <summary>
        /// рост
        /// </summary>
        // Height with a default value of 0 and from diapason from 50 to 250 with checking value
        [DisplayName("Рост"), Category("PersonalData")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IntInterval Height { get; set; } = new IntInterval { Min = 50, Max = 250, Value = 182 };

        /// <summary>
        /// индекс массы тела
        /// </summary>
        // double body mass index with a default value of 24 and from diapason from 18 to 32 with checking value
        [DisplayName("Индекс массы тела"), Category("MedicalData")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval BMI { get; set; } = new DoubleInterval { Min = 18, Max = 32, Value = 24.1 };

        /// <summary>
        /// вес, рассчитываемый по индексу массы тела и росту
        /// </summary>
        // double Weight based on BMI and Height
        [DisplayName("Вес"), Category("MedicalData")]
        public double Weight => BMI.Value * Height.Value * Height.Value / 10000;

        /// <summary>
        /// температура тела
        /// </summary>
        // double Temperature with a default value of 36.6 and from diapason from 35 to 42 with checking value
        [DisplayName("Температура тела"), Category("MedicalData")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval Temperature { get; set; } = new DoubleInterval { Min = 35, Max = 42, Value = 36.6 };

        /// <summary>
        /// индекс здоровья, показывающий здоровье человека и общую способность к заживлению, мертв или получил решения
        /// </summary>
        // double HealthIndex with a default value of 1.0 and from diapason from 0.1 to 10.0 with checking value
        // HealthIndex is a value that shows the health of a person and overall ability to heal, dead or got desisions
        [DisplayName("Индекс здоровья"), Category("MedicalData"),Description("индекс здоровья, показывающий здоровье человека и общую способность к заживлению")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval HealthIndex { get; set; } = new DoubleInterval { Min = 0.1, Max = 10.0, Value = 1.0 };
    }
}
