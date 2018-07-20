public class Solution 
{
    public bool IsValid(string s) 
    {
        var st = new Stack<char>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '(' || s[i] == '{' || s[i] == '[')
                st.Push(s[i]);
            else
            {
                if(IsEmpty(st)) return false;
                    
                var k = st.Pop();
                
                if(s[i] == ')' && k == '(') continue;
                if(s[i] == '}' && k == '{') continue;
                if(s[i] == ']' && k == '[') continue;

                return false;
            }
        }
        
        return IsEmpty(st); 
    }
    
    bool IsEmpty(Stack<char> s) => s.Count == 0;
}
