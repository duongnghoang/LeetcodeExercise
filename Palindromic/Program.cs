public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter a string: ");
            var input = Console.ReadLine();
            if (input.Equals("0")) return;
            Console.WriteLine(LongestPalindrome(input));
        }
    }


    /// <summary>
    /// Return the longest palindromic substring in the given string s
    /// Example: s = "babad"
    /// Output: "bab" or "aba"
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LongestPalindrome(string s)
    {
        if (s.Length <= 1) return s;
        var longest = s.Substring(0, 1);
        for (int i = 0; i < s.Length - 1; i++)
        {
            var p1 = ExpandFromCenter(s, i, i);
            if (p1.Length > longest.Length)
            {
                longest = p1;
            }

            var p2 = ExpandFromCenter(s, i, i + 1);
            if (p2.Length > longest.Length)
            {
                longest = p2;
            }
        }

        return longest;
    }

    private static string ExpandFromCenter(string s, int left, int right)
    {
        var result = string.Empty;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            result = s.Substring(left, right - left + 1);
            left--;
            right++;
        }

        return result;
    }

    public static bool CheckPalindrome(string s)
    {
        var n = s.Length;
        for (int i = 0; i < n / 2; i++)
        {
            if (s[i] != s[n - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}