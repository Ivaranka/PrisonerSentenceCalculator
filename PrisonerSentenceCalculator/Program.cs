using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerSentenceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Prisoner prisoner1 = new Prisoner(new TitForTat()) { Name = "Ivar", History = new List<Outcome> { } };
            Prisoner prisoner2 = new Prisoner(new AlwaysCoop()) { Name = "Danno", History = new List<Outcome> { } };
            Court court = new Court(prisoner1, prisoner2);
            court.clear();
            court.IterateTrial();
            court.IterateNTrials(3);
            court.IterateNTrials(4);
            Console.ReadLine();
        }
    }
}
