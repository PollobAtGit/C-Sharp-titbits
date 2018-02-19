using System; 

class MyClass {
    
    static void Main(string[] args) 
    {
        var str = Console.ReadLine().Trim();
        
        //POI: Mid relation working means dividing by 2 & performing subtraction
        var midIndex = (str.Length / 2) - 1;

        //POI: Multiple declaration is not allowed for implicitly typed variable
        int i = 0, j = str.Length - 1;
        bool isPalindrome = true;

        while(i <= midIndex && j > midIndex)
        {

            if(str[i] != str[j]) 
            {
                isPalindrome = false;
                break;
            }

            i = i + 1;
            j = j - 1;
        }


        System.Console.WriteLine(isPalindrome ? "YES" : "NO");
    }
}
