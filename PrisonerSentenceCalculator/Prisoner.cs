using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerSentenceCalculator
{
    public class Prisoner
    {
        public Prisoner(ITactic tactic)
        {
            _tac = tactic;
        }

        //Felter og Egenskaper
        private ITactic _tac;
        public String Name { get; set; }
        public List<Outcome> History { get; set; }
        public void ClearHistory() {History.Clear();}


        public int CalculatePrisonerScore()
        {
            var total = 0;
            foreach (var score in History)
            {
                total += (int)score;
            }
            return total;
        }
        /// <summary>
        /// Oppførselen til denne fangen
        /// </summary>
        /// <returns>Bool som er sann hvis fangen bestemmer seg for å samarbeide</returns>
        private bool CooperateOrNot(){return _tac.CooperateNextMove(History);}


        /// <summary>
        /// Beregner hva utfallet ble, avhengig av hva denne instansen av fange bestemte seg for,
        /// og hva den andre fangen gjorde
        /// </summary>
        /// <param name="otherPrisoner"></param>
        /// <returns></returns>
        public Outcome calculateOutcome(Prisoner otherPrisoner)
        {
            var iCooperate = CooperateOrNot();
            var heCooperates = otherPrisoner.CooperateOrNot();
            if (iCooperate && heCooperates){return Outcome.Cooperated_OtherCooperated;}
            if (iCooperate && !heCooperates) { return Outcome.Cooperated_OtherDefected;}
            if (!iCooperate && heCooperates) { return Outcome.Defected_OtherCooperated;}
            if (!iCooperate && !heCooperates) { return Outcome.Defected_OtherDefected; }
            else { throw new Exception(); }
        }
        /// <summary>
        /// Lagrer utfallet i en utfallslogg (History)
        /// </summary>
        /// <param name="outcome">Utfallet som skal lagres</param>
        public void SaveOutcome(Outcome outcome){History.Add(outcome);}
    }

    public class TitForTat : ITactic
    {
        public bool CooperateNextMove(List<Outcome> history)
        {
            if (history.Count == 0)
                return false;

            switch (history[history.Count - 1])
            {
                case Outcome.Cooperated_OtherDefected:
                    return false;
                case Outcome.Defected_OtherDefected:
                    return false;
                case Outcome.Cooperated_OtherCooperated:
                    return true;
                case Outcome.Defected_OtherCooperated:
                    return true;
                default:
                    return false;
            }
        }

    }

    public class AlwaysCoop : ITactic
    {
        public bool CooperateNextMove(List<Outcome> history)
        {
            return true;
        }

    }


    public interface ITactic
    {
        bool CooperateNextMove(List<Outcome> history);
    }


    public enum Outcome
    {
        Cooperated_OtherDefected = -3,
        Defected_OtherDefected = -2,
        Cooperated_OtherCooperated = -1,
        Defected_OtherCooperated = 0

    }


}
