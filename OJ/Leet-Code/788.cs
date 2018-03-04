public class Solution 
{
    public int RotatedDigits(int N) 
    {
        var c = 0;
        
        for(int i = 1; i <= N; i++)
        {
            var s = i.ToString();

            if(!s.Contains("3") && !s.Contains("4") && !s.Contains("7"))
                if(Transform(s) != s) 
                    c++;
        }
        
        return c;
    }
    
    string Transform(string s)
    {
        var k = "";
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '0' || s[i] == '1' || s[i] == '8') k = k + s[i];
            if(s[i] == '2') k = k + '5';
            if(s[i] == '5') k = k + '2';
            if(s[i] == '6') k = k + '9';
            if(s[i] == '9') k = k + '6';
        }
        
        return k;
    }
}
