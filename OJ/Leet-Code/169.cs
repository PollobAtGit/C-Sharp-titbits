public class Solution 
{
    public int MajorityElement(int[] nums) 
    {    
        var l = Math.Floor((double)(nums.Length / 2));
        
        var ns = nums.OrderBy(x => x).ToArray();
        
        for(int i = 0; i < ns.Length; i++)
        {
            var c = ns[i];
            var count = 1;
            
            while((i < ns.Length - 1) && ns[i + 1] == c)
            {
                count = count + 1;
                i = i + 1;
            }
            
            if(count > l) return c;
        }
        
        return -1;
    }
}
