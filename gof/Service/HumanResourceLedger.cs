using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    // CareTaker
    public class HumanResourceLedger
    {
        private static IDictionary<int, EmployeeMomento> Momentos = new Dictionary<int, EmployeeMomento>();

        public static EmployeeMomento PreviousState(int id)
        {
            if (!Momentos.ContainsKey(id)) throw new InvalidOperationException();
            return Momentos[id];
        }

        public static void TrackEmployeeState(EmployeeMomento momento)
        {
            //if (Momentos.ContainsKey(momento.Id)) throw new InvalidOperationException();
            Momentos[momento.Id] = momento;
        }
    }
}
