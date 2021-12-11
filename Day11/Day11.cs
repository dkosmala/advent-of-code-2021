using System;
using System.Collections.Generic;
using System.Linq;

public class Day11
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day11/input.txt");
      List<Octopus> grid = new List<Octopus>();
      Queue<Octopus> flash = new Queue<Octopus>();
      int flashes = 0;

      for (int i = 0; i < lines.Length; i++) {
         for (int j = 0; j < lines[i].Length; j++) {
            grid.Add(new Octopus(j,i,(int)Char.GetNumericValue(lines[i][j])));
         }
      }

      for (int step = 1; step <= 100; step++) {
         foreach (Octopus octo in grid)
         {
            octo.v++;
            if (octo.v > 9)
            {
               flash.Enqueue(octo);
            }
         }

         while (flash.Count > 0)
         {
            Octopus octo = flash.Dequeue();
            octo.v = 0;
            flashes++;

            int[] xNext = new int[] { octo.x - 1, octo.x, octo.x + 1 };
            int[] yNext = new int[] { octo.y - 1, octo.y, octo.y + 1 };
            List<Octopus> neighbors = grid.FindAll(o => xNext.Contains(o.x) && yNext.Contains(o.y));

            foreach(Octopus neighbor in neighbors) {
               if (neighbor.v != 0) neighbor.v++;
               if (neighbor.v > 9 && !flash.Contains(neighbor)) {
                  flash.Enqueue(neighbor);
               }
            }
         }
      }

      return flashes.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day11/input.txt");
      List<Octopus> grid = new List<Octopus>();
      Queue<Octopus> flash = new Queue<Octopus>();
      int flashes = 0;

      for (int i = 0; i < lines.Length; i++)
      {
         for (int j = 0; j < lines[i].Length; j++)
         {
            grid.Add(new Octopus(j, i, (int)Char.GetNumericValue(lines[i][j])));
         }
      }

      int step = 0;
      while (true)
      {
         step++;
         foreach (Octopus octo in grid)
         {
            octo.v++;
            if (octo.v > 9)
            {
               flash.Enqueue(octo);
            }
         }

         while (flash.Count > 0)
         {
            Octopus octo = flash.Dequeue();
            octo.v = 0;
            flashes++;

            int[] xNext = new int[] { octo.x - 1, octo.x, octo.x + 1 };
            int[] yNext = new int[] { octo.y - 1, octo.y, octo.y + 1 };
            List<Octopus> neighbors = grid.FindAll(o => xNext.Contains(o.x) && yNext.Contains(o.y));

            foreach (Octopus neighbor in neighbors)
            {
               if (neighbor.v != 0) neighbor.v++;
               if (neighbor.v > 9 && !flash.Contains(neighbor))
               {
                  flash.Enqueue(neighbor);
               }
            }
         }

         if (grid.Any(o => o.v != 0) == false) {
            break;
         }
      }

      return step.ToString();     
   }

   public class Octopus
   {
      public int x, y, v;

      public Octopus(int x, int y, int v) {
         this.x = x;
         this.y = y;
         this.v = v;
      }
   }
}