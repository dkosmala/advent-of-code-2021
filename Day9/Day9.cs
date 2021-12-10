using System;
using System.Collections.Generic;
using System.Linq;

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
      List<(int,int)[]> basins = new List<(int, int)[]>();

      for (int y = 0; y < lines.Length; y++)
      {
         for (int x = 0; x < lines[y].Length; x++)
         {
            num = Int32.Parse(lines[y][x].ToString());

            if (num >= (y == 0 ? 999 : Int32.Parse(lines[y - 1][x].ToString())) ||
                num >= (x == 0 ? 999 : Int32.Parse(lines[y][x - 1].ToString())) ||
                num >= (y >= lines.Length-1 ? 999 : Int32.Parse(lines[y + 1][x].ToString())) ||
                num >= (x >= lines[0].Length-1 ? 999 : Int32.Parse(lines[y][x + 1].ToString())))
            {
               continue;
            }
            else
            {
               lows.Add((x,y));
            }
         }
      }

      Queue<(int,int)> check = new Queue<(int, int)>();
      List<(int,int)> visited = new List<(int, int)>();
      (int,int) point;

      foreach((int,int) low in lows) {
         check.Clear();
         visited.Clear();

         check.Enqueue(low);

         while(check.Count > 0) {
            point = check.Dequeue();
            if (visited.Contains(point)) {
               continue;
            }
            visited.Add(point);

            // north
            if (point.Item2 - 1 >= 0 && !visited.Contains((point.Item1, point.Item2 - 1))) {
               if (!lines[point.Item2 - 1][point.Item1].Equals('9')) {
                  check.Enqueue((point.Item1, point.Item2 - 1));
               }
            }

            // south
            if (point.Item2 + 1 <= lines.Length - 1 && !visited.Contains((point.Item1, point.Item2 + 1))) {
               if (!lines[point.Item2 + 1][point.Item1].Equals('9')) {
                  check.Enqueue((point.Item1, point.Item2 + 1));
               }
            }

            // west
            if (point.Item1 - 1 >= 0 && !visited.Contains((point.Item1 - 1, point.Item2))) {
               if (!lines[point.Item2][point.Item1 - 1].Equals('9')) {
                  check.Enqueue((point.Item1 - 1, point.Item2));
               }
            }

            // east
            if (point.Item1 + 1 <= lines[0].Length - 1 && !visited.Contains((point.Item1 + 1, point.Item2))) {
               if (!lines[point.Item2][point.Item1 + 1].Equals('9')) {
                  check.Enqueue((point.Item1 + 1, point.Item2));
               }
            }            
         }

         basins.Add(visited.ToArray());
      }

      //List<(int, int)[]> ordBasin = basins.OrderBy(s => s.Length).ToList();
      basins = basins.OrderByDescending(s => s.Length).ToList();


      return Convert.ToString(basins[0].Length * basins[1].Length * basins[2].Length);
   }
}