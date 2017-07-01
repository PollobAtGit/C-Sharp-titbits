using System; 
using System.Numerics;
 
class MyClass 
{
    static void Main(string[] args) 
    {
        try
        {
            var firstLine = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
			
            var q = firstLine[1];
			
            var array = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            var number = 0;
			
            while(--q >= 0)
            {
                var query = Console.ReadLine().Split(' ');
                var queryDeterminent = query[0];
				
                if(queryDeterminent == "1")
                {
                    var flipIndex = Int32.Parse(query[1]) - 1;
                    array[flipIndex] = array[flipIndex] == 1 ? 0 : 1;
                }
                else if(queryDeterminent == "0")
                {
                    var i = Int32.Parse(query[1]) - 1;
                    var j = Int32.Parse(query[2]) - 1;
					 
                    var pos = 0d;
					
                    while(i <= j)
                    {
                        number = (int)(number + (array[i] * Math.Pow(2d, pos)));
                        pos = pos + 1;
                        i = i + 1;
                    }
                }
            }
            Console.WriteLine(number % 2 == 0 ? "EVEN" : "ODD");
        }
        catch(Exception)
        {
        }
    }
}