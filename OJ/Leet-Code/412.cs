public class Solution 
{
    public IList<string> FizzBuzz(int n) 
    {
        
        var l = new List<string>();
        for(int i = 1; i <= n; i++)
            l.Add(FindStrToDisplay(i));
        
        return l;
    }
    
    bool IsFizz(int n) => n % 3 == 0;
    bool IsBuzz(int n) => n % 5 == 0;
    
    string FindStrToDisplay(int n)
    {
        if(IsFizz(n) && IsBuzz(n)) return "FizzBuzz";
        if(IsFizz(n)) return "Fizz";
        if(IsBuzz(n))return "Buzz";
           
        return n.ToString();
    }
}
