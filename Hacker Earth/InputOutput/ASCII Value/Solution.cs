using System; 
//using System.Text;
using System.Numerics;

class MyClass {
    
    static void Main(string[] args) 
    {
        var str = Console.ReadLine().Trim();
        
        //byte[] bytes = new byte[1];
        //ASCIIEncoding.GetBytes(str, 0, str.Length, bytes, 0);

        System.Console.WriteLine((int)str[0]);
    }
}
