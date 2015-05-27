using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_of_strings
{
    class BigInteger
    {
        private readonly string _strRepresentation = "";
        private readonly bool _isNegative = false;

        public BigInteger(string str)
        {
            _strRepresentation = str.Trim();
            _isNegative = (_strRepresentation[0] == '-');

            Console.WriteLine(_isNegative);
            if(_isNegative)
            {
                _strRepresentation = _strRepresentation.Remove(0, 1);
            }
            
            Console.WriteLine(_strRepresentation);
            _strRepresentation = _strRepresentation.TrimStart(new char[] { '0' });
        }

        public string GetString()
        {
            return _strRepresentation;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            var bgInt = new BigInteger(str);
            Console.WriteLine(bgInt.GetString());
        }
    }
}
