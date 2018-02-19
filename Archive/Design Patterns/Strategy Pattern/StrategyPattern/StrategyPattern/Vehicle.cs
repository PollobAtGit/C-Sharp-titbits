using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public abstract class Vehicle
    {
        protected IGoAlgorithm goAlgorithm;

        public void ChangeMovingStrategy(IGoAlgorithm goAlgo)
        {
            goAlgorithm = goAlgo;
        }

        public string GetMovingStrategy()
        {
            if (goAlgorithm == null)
                return "Moving Strategy Is Yet To Specify";
            return goAlgorithm.Go();
        }
    }
}
