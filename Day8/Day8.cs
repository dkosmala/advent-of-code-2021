using System;
using System.Collections.Generic;

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
      return "";
   }
}