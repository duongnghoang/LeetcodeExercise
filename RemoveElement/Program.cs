// See https://aka.ms/new-console-template for more information

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] nums = Array.ConvertAll(input, int.Parse);
int val = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

int length = nums.Length;
int i = 0;
while (i < length)
{
    if (nums[i] == val)
    {
        for (int j = i; j < length - 1; j++)
            nums[j] = nums[j + 1];
        length--;
    }
    else i++;
}

foreach (int num in nums)
    Console.Write(num + " ");
Console.WriteLine();
Console.WriteLine(length);
return length;