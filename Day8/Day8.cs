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
      
      foreach (string line in lines) {
         string[] nums = line.Split(" | ")[0].Split(" ");

         one = nums.Single(s => s.Length == 2);
         four = nums.Single(s => s.Length == 4);
         seven = nums.Single(s => s.Length == 3);
         eight = nums.Single(s => s.Length == 7);

         nine = nums.Single(s => s.Length == 6 && s.Contains(four));
         zero = nums.Single(s => s.Length == 6 && s.Contains(seven) && s != nine);
         six = nums.Single(s => s.Length == 6 && s != nine && s != zero);

         three = nums.Single(s => s.Length == 5 && s.Contains(one));
         five = nums.Single(s => s.Length == 5 && six.Contains(s));
         two = nums.Single(s => s.Length == 5 && s != three && s != five);

         //one.Contains()
      }

      return "";
   }
}