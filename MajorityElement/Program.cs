// See https://aka.ms/new-console-template for more information
// Find the majority element in the n-size array (more than n/2 appearances), assuming it always exists

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] nums = Array.ConvertAll(input, int.Parse);
Dictionary<int, int> dict = new Dictionary<int, int>();

for (int i = 0; i < nums.Length; i++)
{
    if (dict.ContainsKey(nums[i]))
        dict[nums[i]]++;
    else
        dict.Add(nums[i], 1);
}

foreach (KeyValuePair<int, int> pair in dict)
{
    if (pair.Value > nums.Length / 2)
    {
        Console.WriteLine(pair.Key);
    }
}