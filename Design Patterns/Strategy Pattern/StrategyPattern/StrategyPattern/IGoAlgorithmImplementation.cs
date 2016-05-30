using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class DrivingAlgorithm:IGoAlgorithm
    {
        public string Go()
        {
            //throw new NotImplementedException();
            return "I'm driving now!";
        }
    }

    public class DrivingFastAlgorithm : IGoAlgorithm
    {
        public string Go()
        {
            return "I'm driving very fast now!";
        }
    }

    public class FlyingAlgorithm: IGoAlgorithm
    {
        public string Go()
        {
            return "I'm Flying now!";
        }
    }

    public class FlyingVeryFastAlgorithm:IGoAlgorithm
    {
        public string Go()
        {
            return "I'm Flying really fast now!";
        }
    }
}
