namespace BeautifulIndices
{
    internal class Program
    {
        //Problem 3008: Beautiful Indices
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter string: ");
                var input1 = Console.ReadLine();
                Console.WriteLine("Enter string a: ");
                var input2 = Console.ReadLine();
                Console.WriteLine("Enter string b: ");
                var input3 = Console.ReadLine();
                Console.WriteLine("Enter k: ");
                var input4 = Console.ReadLine();
                var result = BeautifulIndices(input1, input2, input3, int.Parse(input4));
                Console.WriteLine("Result: ");
                foreach (var i in result)
                {
                    Console.Write(i + "\n");
                }
            }
        }

        public static IList<int> BeautifulIndices(string s, string a, string b, int k)
        {
            // 1. Find all the indices of a in s
            // 2. Find all the indices of b in s
            // 3. Find the indices of a and b that are k indices apart
            // 4. Return the indices/
            IList<int> result = new List<int>();
            IList<int> aIndices = ReturnIndexWithCondition(s, a);
            IList<int> bIndices = ReturnIndexWithCondition(s, b);
            foreach (var aIndex in aIndices)
            {
                if (CheckCondition(bIndices, aIndex, k))
                {
                    result.Add(aIndex);
                    continue;
                }
            }

            return result;
        }

        private static IList<int> ReturnIndexWithCondition(string s, string key)
        {
            List<int> result = new List<int>();
            for (int index = 0; index < s.Length; index++)
            {
                if (index > s.Length - key.Length) return result;
                if (key.Equals(s.Substring(index, key.Length)))
                {
                    result.Add(index);
                }
            }

            return result;
        }

        private static bool CheckCondition(IList<int> list, int index, int k)
        {
            foreach (int i in list)
            {
                if (Math.Abs(i - index) <= k)
                {
                    return true;
                }
            }

            return false;
        }
    }
}