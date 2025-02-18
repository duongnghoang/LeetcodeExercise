// See https://aka.ms/new-console-template for more information
// Rotate an array k steps to the right

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] nums = Array.ConvertAll(input, int.Parse);
int k = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

// Solution 1: Creates an array of the same size as the input array for rotation
int[] result = new int[nums.Length];
for (int i = 0; i < nums.Length; i++)
{
    result[(i + k) % nums.Length] = nums[i];
}

// Solution 2: 
// Reverse the whole array
// Reverse the first k elements
// Reverse the rest of the elements
for (int i = 0; i < k; i++)
{
    int temp = nums[nums.Length - 1];
    for (int j = nums.Length - 1; j > 0; j--)
    {
        nums[j] = nums[j - 1];
    }

    nums[0] = temp;
}

for (int i = 0; i < nums.Length; i++)
{
    Console.Write(nums[i] + " ");
}