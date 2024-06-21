using AgentsLibrary1.AgentsLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "COVID-19";
        public double Lethality { get; set; } = 0.03;
        public double Infectivity { get; set; } = 0.1;
        public double Recovery { get; set; } = 0.97;
        public DoubleInterval Incubation { get; set; } = new DoubleInterval(16,7,23);
        public DoubleInterval Duration { get; set; } = new DoubleInterval(14,7,21);
        public DoubleInterval Immunity { get; set; } = new DoubleInterval(180,90,240);
        public double Mutation { get; set; } = 0.001;
    }
}
