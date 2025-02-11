namespace MergeSortedArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter array 1: ");
                var input1 = Console.ReadLine().Split(",");
                var nums1 = Array.ConvertAll(input1, int.Parse);
                Console.WriteLine("Enter array 2: ");
                var input2 = Console.ReadLine().Split(",");
                var nums2 = Array.ConvertAll(input2, int.Parse);
                Console.WriteLine("Enter m: ");
                var m = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter n: ");
                var n = int.Parse(Console.ReadLine());
                Merge(nums1, m, nums2, n);
                Console.WriteLine("Result: ");
                foreach (var i in nums1)
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
            {
                return;
            }

            int maxIndex = m + n;
            for (int i = maxIndex; i > 0; i--)
            {
                if (m > 0 && n > 0 && nums1[m - 1] > nums2[n - 1])
                {
                    nums1[maxIndex - 1] = nums1[m - 1];
                    m--;
                }
                else if (n > 0)
                {
                    nums1[maxIndex - 1] = nums2[n - 1];
                    n--;
                }

                maxIndex--;
            }

            while (n > 1)
            {
                nums1[maxIndex - 1] = nums2[n - 1];
                n--;
            }
        }
    }
}