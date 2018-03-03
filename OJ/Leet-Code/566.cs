public class Solution 
{
    public int[,] MatrixReshape(int[,] nums, int r, int c) 
    {
        if(nums.Length != (r * c)) return nums;
        
        var a = new int[r, c];
        
        var lr = 0;
        var lc = 0;
        
        // 0 => Row 
        for(int i = 0; i < nums.GetLength(0); i++)
        {
            // 1 => Column
            for(int j = 0; j < nums.GetLength(1); j++)
            {
                a[lr, lc] = nums[i, j];
                
                lc++;
                
                if(lc == c)  { lc = 0; lr++; }
            }

            if(lc == c)  { lc = 0; lr++; }
        }
        
        return a;
    }
}
