using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsLibrary1
{
    /// <summary>
    /// обощенный класс агента, содержит информацию о
    /// координатах 
    /// характеристиках
    /// здоровье
    /// </summary>
    public class AAgent
    {
        /// <summary>
        /// код агента
        /// </summary>
        [DisplayName("Идентификатор"), Category("UserData")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// координаты агента и прочая пространственная информация
        /// </summary>
        [DisplayName("Точка"), Category("Spatial"), Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public APoint Point { get; set; } = new APoint();

        /// <summary>
        /// характеристики агента, например возраст, пол, имя
        /// </summary>
        [DisplayName("Персона"), Category("PersonalData"),Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public APerson Person { get; set; } = new APerson();

        /// <summary>
        /// здоровье агента, включая медицинский статус
        /// </summary>
        [DisplayName("Медицинский статус"),Category("MedicalData"),Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AMedicalStatus MedicalStatus { get; set; } = new AMedicalStatus();

        /// <summary>
        /// вирус, которым заражен агент (если заражен) с учетом возможных мутаций
        /// заражение происходит "стандартным" вирусом, а вирус агента может мутировать
        /// и иметь отличающиеся параметрыв
        /// </summary>
        [DisplayName("Вирус"),Category("Virus"),Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AVirus Virus { get; set; } = new AVirus();
    }
}
