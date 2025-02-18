// See https://aka.ms/new-console-template for more information
// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
// Input: prices = [7,1,5,3,6,4]
// Output: 5
// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

string[] input = Console.ReadLine()?.Split(" ") ?? throw new InvalidOperationException();
int[] prices = Array.ConvertAll(input, int.Parse);

int maxPrice = prices[0];
int maxIndex = 0;
int minIndex = 0;
int minPrice = prices[0];
for (int i = 0; i < prices.Length; i++)
{
}