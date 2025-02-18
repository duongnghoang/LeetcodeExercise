// See https://aka.ms/new-console-template for more information

// Non-decreasing order array

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] nums = Array.ConvertAll(input, int.Parse);

// Remove duplicates from the array so that each element appears at most 2
int j = 2;
for (int i = 2; i < nums.Length; i++)
{
    if (nums[i] != nums[j - 2])
    {
        nums[j] = nums[i];
        j++;
    }
}

for (int k = 0; k < j; k++)
    Console.Write(nums[k] + " ");
// 1 1 1 2 2 3
// j2 i3
// j3 i4
// 0 1 1 2 2 3 3 4 4 4