using System;
using System.Collections.Generic;

public class Solution 
{
   
    public int FirstUniqChar(string s) 
    {
        
        if(s == null || s.Trim() == "") return -1;

        for(int i = 0; i < s.Length; i++)
            if(s.LastIndexOf(s[i]) == s.IndexOf(s[i])) 
                return i;
        
        return -1;
    }

    public int FirstUniqChar_1(string s) 
    {
        
        if(s == null || s.Trim() == "") return -1;

        var a = new int[128];
        
        for(int i = 0; i < s.Length; i++) a[s[i]]++;
        
        for(int i = 0; i < s.Length; i++)
            if(a[s[i]] == 1) 
                return i;
        
        return -1;
    }
}


