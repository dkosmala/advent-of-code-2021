using System;

public class Day6
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day6/input.txt");
      int[] vals = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));
      int[] fishes = new int[9];

      // make the starter fishies
      foreach (int v in vals) {
         fishes[v]++;
      }

      int newFish = 0;
      for (int d = 0; d < 80; d++) {
         for (int f = 0; f < fishes.Length - 1; f++) {
            if (f == 0) {
               newFish = fishes[f];
            }

            fishes[f] = fishes[f+1];
         }

         fishes[8] = newFish;
         fishes[6] += newFish;
      }

      int sum = 0;
      Array.ForEach(fishes, f => sum += f);

      return Convert.ToString(sum);
   }

   public string second () {
      string[] lines = System.IO.File.ReadAllLines(@"Day6/input.txt");
      int[] vals = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));
      long[] fishes = new long[9];

      // make the starter fishies
      foreach (int v in vals)
      {
         fishes[v]++;
      }

      long newFish = 0;
      for (int d = 0; d < 256; d++)
      {
         for (int f = 0; f < fishes.Length - 1; f++)
         {
            if (f == 0)
            {
               newFish = fishes[f];
            }

            fishes[f] = fishes[f + 1];
         }

         fishes[8] = newFish;
         fishes[6] += newFish;
      }

      long sum = 0;
      Array.ForEach(fishes, f => sum += f);

      return Convert.ToString(sum); 
   }
}