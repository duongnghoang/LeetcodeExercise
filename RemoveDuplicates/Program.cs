// See https://aka.ms/new-console-template for more information

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] nums = Array.ConvertAll(input, int.Parse);

// Remove duplicates from the array
int i = 0;
int j = 1;

while (j < nums.Length)
{
    if (nums[i] != nums[j])
    {
        nums[i++] = nums[j];
    }

    j++;
}

GC.Collect();
foreach (int num in nums)
    Console.Write(num + " ");
Console.WriteLine();
Console.WriteLine(i + 1);
return i + 1;