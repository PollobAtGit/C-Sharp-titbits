using System; 
using System.Numerics;
 
class MyClass 
{
    static void Main(string[] args) 
    {
        try
        {
            var firstLine = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
 
            var q = firstLine[1];
 
            var array = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);
            var isEven = false;
 
            while(--q >= 0)
            {
                var query = Console.ReadLine().Trim().Split(' ');
 
                var queryDeterminent = query[0];
 
                if(queryDeterminent == "1")
                {
                    var flipIndex = Int32.Parse(query[1]) - 1;
 
                    if(flipIndex < array.Length)
                    {
                        array[flipIndex] = array[flipIndex] == 1 ? 0 : 1;
                    }
 
                }
                else if(queryDeterminent == "0")
                {
                    var i = Int32.Parse(query[2]) - 1;
                    var k = array[i];
 
                    if(k == 0)
                    {
                        isEven = true;
                    }
                }
            }
 
            Console.WriteLine(isEven ? "EVEN" : "ODD");
        }
        catch(Exception)
        {
 
        }
    }
}