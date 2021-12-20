using System;
using System.Collections.Generic;
using System.Linq;

public class Day8
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day8/input.txt");
      int sum = 0;
      List<int> lengths = new List<int>(new int[] {2,3,4,7});
      
      foreach (string line in lines) {
         string output = line.Split(" | ")[1];
         string[] nums = output.Split(" ");

         foreach (string num in nums) {
            if (lengths.Contains(num.Length)) {
               sum++;
            }
         }
      }

      return Convert.ToString(sum);
   }

   public string second() 
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day8/input.txt");
      string zero, one, two, three, four, five, six, seven, eight, nine;
      string output;
      int sum = 0;
      
      foreach (string line in lines) {
         string[] nums = line.Split(" | ")[0].Split(" ");

         one = nums.Single(s => s.Length == 2);
         four = nums.Single(s => s.Length == 4);
         seven = nums.Single(s => s.Length == 3);
         eight = nums.Single(s => s.Length == 7);

         nine = nums.Single(s => s.Length == 6 && ContainsWithin(s, four));
         zero = nums.Single(s => s.Length == 6 && ContainsWithin(s, seven) && s != nine);
         six = nums.Single(s => s.Length == 6 && s != nine && s != zero);

         three = nums.Single(s => s.Length == 5 && ContainsWithin(s, one));
         five = nums.Single(s => s.Length == 5 && ContainsWithin(six, s));
         two = nums.Single(s => s.Length == 5 && s != three && s != five);

         nums = line.Split(" | ")[1].Split(" ");
         output = "";
         foreach (string num in nums)
         {
            if (num.Length == one.Length && ContainsWithin(num, one)) output += "1";
            if (num.Length == two.Length && ContainsWithin(num, two)) output += "2";
            if (num.Length == three.Length && ContainsWithin(num, three)) output += "3";
            if (num.Length == four.Length && ContainsWithin(num, four)) output += "4";
            if (num.Length == five.Length && ContainsWithin(num, five)) output += "5";
            if (num.Length == six.Length && ContainsWithin(num, six)) output += "6";
            if (num.Length == seven.Length && ContainsWithin(num, seven)) output += "7";
            if (num.Length == eight.Length && ContainsWithin(num, eight)) output += "8";
            if (num.Length == nine.Length && ContainsWithin(num, nine)) output += "9";
            if (num.Length == zero.Length && ContainsWithin(num, zero)) output += "0";
         }

         sum += int.Parse(output);
      }

      return sum.ToString();
   }

   private bool ContainsWithin(string main, string check)
   {
      foreach (char c in check)
      {
         if (!main.Contains(c))
         {
            return false;
         }
      }

      return true;
   }
}