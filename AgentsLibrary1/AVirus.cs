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
    /// базовый экземпляр вируса
    /// <!-- вирус имеет свойства: летальность, инфективность, выздоровление, мутация -->
    /// <!-- летальность - вероятность смерти при заражении -->
    /// <!-- инфективность - вероятность заражения при контакте -->
    /// <!-- выздоровление - вероятность выздоровления после заражения -->
    /// 
    /// </summary>
    public class AVirus
    {
        [DisplayName("Code"),Category("UserData")]
        public int Id { get; set; } = 0;
        [DisplayName("Название вируса"),Category("Virus")]
        public string Name { get; set; } = "COVID-19";
        // название штамма вирруса
        [DisplayName("Штамм"),Category("Virus")]
        public string Strain { get; set; } = "Stamm1";
        [DisplayName("Летальность"),Category("Virus"),Description("Вероятность смерти при заражении")]
        public double Lethality { get; set; } = 0.03;
        [DisplayName("Инфективность"),Category("Virus"),Description("Вероятность заражения при контакте")]
        public double Infectivity { get; set; } = 0.1;
        [DisplayName("Выздоровление"),Category("Virus"),Description("Вероятность выздоровления после заражения")]
        public double Recovery { get; set; } = 0.97;
        [DisplayName("Инкубационный период"),Category("Virus"),Description("Инкубационный период")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval Incubation { get; set; } = new DoubleInterval(16,7,23);
        [DisplayName("Период болезни"),Category("Virus"),Description("Период болезни")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval Duration { get; set; } = new DoubleInterval(14,7,21);
        [DisplayName("Иммунитет"),Category("Virus"),Description("Длительность приобретенного иммунитета")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DoubleInterval Immunity { get; set; } = new DoubleInterval(180,90,240);
        [DisplayName("Мутация"),Category("Virus"),Description("Вероятность мутации")]
        public double Mutation { get; set; } = 0.001;

        public AVirus()
        {
        }

        public AVirus(int id, string name, string strain, double lethality, double infectivity, double recovery, DoubleInterval incubation, DoubleInterval duration, DoubleInterval immunity, double mutation)
        {
            Id = id;
            Name = name;
            Strain = strain;
            Lethality = lethality;
            Infectivity = infectivity;
            Recovery = recovery;
            Incubation = incubation;
            Duration = duration;
            Immunity = immunity;
            Mutation = mutation;
        }

        public AVirus(AVirus virus)
        {
            Id = virus.Id;
            Name = virus.Name;
            Strain = virus.Strain;
            Lethality = virus.Lethality;
            Infectivity = virus.Infectivity;
            Recovery = virus.Recovery;
            Incubation = new DoubleInterval(virus.Incubation);
            Duration = new DoubleInterval(virus.Duration);
            Immunity = new DoubleInterval(virus.Immunity);
            Mutation = virus.Mutation;
        }   

        // clone
        public AVirus Clone()
        {
            return new AVirus(this);
        }

        public override string ToString()
        {
            return Name + " " + Strain;
        }

    }
}

