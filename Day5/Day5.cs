using System;
using System.Collections.Generic;

public class Day5
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day5/input.txt");
      int[,] theGrid = new int[1000,1000];
      int start, end;
      int sum = 0;

      foreach (string line in lines) {
         int[] vals = Array.ConvertAll(line.Replace(" -> ", ",").Split(','), s => int.Parse(s));

         // y-diff (vertical)
         if (vals[0] == vals[2]) {
            if (vals[1] < vals[3]) {
               start = vals[1];
               end = vals[3];
            } else {
               start = vals[3];
               end = vals[1];
            }

            for (int y = start; y <= end; y++) {
               if (theGrid[vals[0],y] == 1) sum++;
               theGrid[vals[0],y]++;
            }
         }

         // x-diff (horizontal)
         if (vals[1] == vals[3]) {
            if (vals[0] < vals[2]) {
               start = vals[0];
               end = vals[2];
            } else {
               start = vals[2];
               end = vals[0];
            }

            for (int x = start; x <= end; x++) {
               if (theGrid[x,vals[1]] == 1) sum++;
               theGrid[x,vals[1]]++;
            }
         }

      }

      return Convert.ToString(sum);
   }

   public string second() {
      string[] lines = System.IO.File.ReadAllLines(@"Day5/input.txt");
      int[,] theGrid = new int[1000,1000];
      int start, end;
      (int, int) one, two;
      int sum = 0;

      foreach (string line in lines) {
         int[] vals = Array.ConvertAll(line.Replace(" -> ", ",").Split(','), s => int.Parse(s));

         // y-diff (vertical)
         if (vals[0] == vals[2]) {
            if (vals[1] < vals[3]) {
               start = vals[1];
               end = vals[3];
            } else {
               start = vals[3];
               end = vals[1];
            }

            for (int y = start; y <= end; y++) {
               if (theGrid[vals[0],y] == 1) sum++;
               theGrid[vals[0],y]++;
            }
         } else if (vals[1] == vals[3]) {
            // x-diff (horizontal)
            if (vals[0] < vals[2]) {
               start = vals[0];
               end = vals[2];
            } else {
               start = vals[2];
               end = vals[0];
            }

            for (int x = start; x <= end; x++) {
               if (theGrid[x,vals[1]] == 1) sum++;
               theGrid[x,vals[1]]++;
            }
         } else {
            if (vals[0] < vals[2]) {
               one = (vals[0], vals[1]);
               two = (vals[2], vals[3]);
            } else {
               one = (vals[2], vals[3]);
               two = (vals[0], vals[1]);               
            }

            if (one.Item2 < two.Item2) {
               while (one.Item1 <= two.Item1) {
                  if (theGrid[one.Item1, one.Item2] == 1) sum++;
                  theGrid[one.Item1, one.Item2]++;
                  one.Item1++;
                  one.Item2++;
               }
            } else {
               while (one.Item1 <= two.Item1) {
                  if (theGrid[one.Item1, one.Item2] == 1) sum++;
                  theGrid[one.Item1, one.Item2]++;
                  one.Item1++;
                  one.Item2--;
               }
            }
         }
      }

      return Convert.ToString(sum);      
   }
}