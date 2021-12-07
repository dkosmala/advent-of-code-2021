using System;

public class Day7
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day7/input.txt");
      int[] vals = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));

      // find the median
      int half = (vals.Length / 2) - 1;
      Array.Sort(vals);

      int median = 0;
      if (vals.Length % 2 == 0) {
         median = (vals[half] + vals[half + 1]) / 2;
      } else {
         // doesn't apply (yet)
      }

      int sum = 0;

      foreach (int v in vals) {
         sum += Math.Abs(v - median);
      }

      return Convert.ToString(sum);
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day7/input.txt");
      int[] vals = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));

      // find the mean?
      int mean = 0;
      int sum = 0;
      foreach (int v in vals)
      {
         sum += v;
      }
      mean = sum / vals.Length;

      sum = 0;
      foreach (int v in vals)
      {
         sum += fuelSpent(Math.Abs(v - mean));
      }

      return Convert.ToString(sum);
   }

   private int fuelSpent(int d) {
      int sum = 0;
      for (int i = d; i > 0; i--) {
         sum += i;
      }

      return sum;
   }
}