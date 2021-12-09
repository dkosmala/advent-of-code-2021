using System;
using System.Collections.Generic;

public class Day9
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day9/input.txt");
      int sum = 0;
      int num;
      
      for (int y = 0; y < lines.Length; y++) {
         for (int x = 0; x < lines[y].Length; x++) {
            num = Int32.Parse(lines[y][x].ToString());
            if (num == 0) {
               sum++;
               continue;
            }

            if (num >= (y == 0 ? 999 : Int32.Parse(lines[y-1][x].ToString())) || 
                num >= (x == 0 ? 999 : Int32.Parse(lines[y][x-1].ToString())) || 
                num >= (y >= 99 ? 999 : Int32.Parse(lines[y+1][x].ToString())) || 
                num >= (x >= 99 ? 999 : Int32.Parse(lines[y][x+1].ToString()))) {
               continue;
            } else {
               sum += num + 1;
            }
         }
      }

      return Convert.ToString(sum);
   }

   public string second() 
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day9/input.txt");
      int sum = 0;
      int num;
      List<(int,int)> lows = new List<(int,int)>();

      for (int y = 0; y < lines.Length; y++)
      {
         for (int x = 0; x < lines[y].Length; x++)
         {
            num = Int32.Parse(lines[y][x].ToString());
            if (num == 0)
            {
               sum++;
               continue;
            }

            if (num >= (y == 0 ? 999 : Int32.Parse(lines[y - 1][x].ToString())) ||
                num >= (x == 0 ? 999 : Int32.Parse(lines[y][x - 1].ToString())) ||
                num >= (y >= 99 ? 999 : Int32.Parse(lines[y + 1][x].ToString())) ||
                num >= (x >= 99 ? 999 : Int32.Parse(lines[y][x + 1].ToString())))
            {
               continue;
            }
            else
            {
               lows.Add((x,y));
            }
         }
      }
      

      return Convert.ToString(sum);
   }
}