using System;

internal static class ValidIndianPhnNumber
{
    internal static void Main()
    {
        var t = System.Int32.Parse(Console.ReadLine());

        while (--t >= 0)
        {
            var phoneNumber = Console.ReadLine();
            Console.WriteLine(IsValidIndianPhoneNumber(phoneNumber) ? "Valid" : "Invalid");
        }
    }

    internal static bool IsValidIndianPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length < 10 && phoneNumber.Length > 12) return false;
        if (phoneNumber.Length == 10 && FirstOfTenInBetweenSevenToNine(phoneNumber[0])) return true;
        if (phoneNumber.Length == 11 && GetIntForChar(phoneNumber[0]) == 0 && FirstOfTenInBetweenSevenToNine(phoneNumber[1])) return true;
        return phoneNumber.Length == 12 && GetIntForChar(phoneNumber[0]) == 9 && GetIntForChar(phoneNumber[1]) == 1 && FirstOfTenInBetweenSevenToNine(phoneNumber[2]);
    }

    internal static int GetIntForChar(char ch) => ch - 48;

    internal static bool FirstOfTenInBetweenSevenToNine(char ch) => GetIntForChar(ch) >= 7 && GetIntForChar(ch) <= 9;
}
