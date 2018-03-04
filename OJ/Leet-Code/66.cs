public class Solution 
{
    public static void Main()
    {
        // [6,1,4,5,3,9,0,1,9,5,1,8,6,7,0,5,5,4,3]
        Console.WriteLine(string.Join(", ", PlusOne(
            new int[] 
            {
                6, 1, 4, 5, 3, 9, 0, 1, 9, 5, 1, 8, 6, 7, 0, 5, 5, 4, 3
            })));
    }

    static int[] PlusOne(int[] digits)
    {
        if(digits[digits.Length - 1] < 9)
        {
            digits[digits.Length - 1] = digits[digits.Length - 1] + 1;
            return digits;
        }

        digits[digits.Length - 1] = 0;
        var c = true;
        
        for(int i = digits.Length - 2; i >= 0; i--)
        {
            if(c && digits[i] < 9)
            {
                digits[i] = digits[i] + 1;
                return digits;
            }

            if(c && digits[i] = 9) digits[i] = 0;
        }
        
        var l = new List<int> { 1 };
        l.AddRange(digits);
        
        return l.ToArray();
    }
}

