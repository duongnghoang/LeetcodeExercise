namespace LetterCombination
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter string: ");
                var input1 = Console.ReadLine();
                var result = LetterCombinations(input1);
                Console.WriteLine("Result: ");
                foreach (var i in result)
                {
                    Console.Write(i + "\n");
                }
            }
        }

        private static IList<string> LetterCombinations(string digits)
        {
            string[] map = new string[]
            {
                "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
            };
            List<string> result = new List<string>([""]);
            if (digits.Length == 0)
            {
                return result;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                result = Combine(map[digits[i] - '0'], result);
            }

            return result;
        }

        private static List<string> Combine(string s, List<string> result)
        {
            int length = result.Count * s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (j >= result.Count)
                    {
                        result.Add(result[j - result.Count]);
                    }

                    result[j] += s[i];
                }
            }

            return result;
        }
    }
}