using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerSentenceCalculator
{
    public class Court
    {
        public Court(Prisoner prisoner1, Prisoner prisoner2)
        { _pri1 = prisoner1;
          _pri2 = prisoner2;
        }
        private Prisoner _pri1;
        private Prisoner _pri2;

        public void clear()
        {
            _pri1.ClearHistory();
            _pri2.ClearHistory();
        }

        public void IterateTrial()
        {
            Outcome op1= _pri1.calculateOutcome(_pri2);
            Outcome op2= _pri2.calculateOutcome(_pri1);
            _pri1.SaveOutcome(op1);
            _pri2.SaveOutcome(op2);
            PrintLastOutcome();
            PrintPrisonerScores();
            Console.WriteLine("--------------------------");

        }
        public void IterateNTrials(int n)
        {
            for (int i=0; i<n; i++){ IterateTrial();}
        }

        public void PrintLastOutcome()
        {
            Console.WriteLine($"Fange 1 :{_pri1.History[_pri1.History.Count-1]} | Fange 2: {_pri2.History[_pri2.History.Count - 1]} ");
        }
        public void PrintPrisonerScores()
        {
            Console.WriteLine($"Fange1: {_pri1.CalculatePrisonerScore()}  |  Fange1: { _pri2.CalculatePrisonerScore()} " );
        }

    }
}
