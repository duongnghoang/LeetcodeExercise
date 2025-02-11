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
            //IList<int> aIndices = ReturnIndexWithCondition(s, a);
            //IList<int> bIndices = ReturnIndexWithCondition(s, b);

            //KMP Algorithm
            IList<int> aIndices = KMPSearch(a, s);
            IList<int> bIndices = KMPSearch(b, s);
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

        static void ConstructLps(string pat, int[] lps)
        {
            // len stores the length of longest prefix which 
            // is also a suffix for the previous index
            int len = 0;

            // lps[0] is always 0
            lps[0] = 0;

            int i = 1;
            while (i < pat.Length)
            {
                // If characters match, increment the size of lps
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }

                // If there is a mismatch
                else
                {
                    if (len != 0)
                    {
                        // Update len to the previous lps value 
                        // to avoid redundant comparisons
                        len = lps[len - 1];
                    }
                    else
                    {
                        // If no matching prefix found, set lps[i] to 0
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }

        static List<int> KMPSearch(string pat, string txt)
        {
            int n = txt.Length;
            int m = pat.Length;

            int[] lps = new int[m];
            List<int> res = new List<int>();

            ConstructLps(pat, lps);

            // Pointers i and j, for traversing 
            // the text and pattern
            int i = 0;
            int j = 0;

            while (i < n)
            {
                // If characters match, move both pointers forward
                if (txt[i] == pat[j])
                {
                    i++;
                    j++;

                    // If the entire pattern is matched 
                    // store the start index in result
                    if (j == m)
                    {
                        res.Add(i - j);

                        // Use LPS of previous index to 
                        // skip unnecessary comparisons
                        j = lps[j - 1];
                    }
                }

                // If there is a mismatch
                else
                {
                    // Use lps value of previous index
                    // to avoid redundant comparisons
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return res;
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