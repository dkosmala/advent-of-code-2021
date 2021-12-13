using System;
using System.Collections.Generic;
using System.Linq;

public class Day13
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day13/input.txt");
      List<(int,int)> graph = new List<(int, int)>();

      foreach (string line in lines)
      {
         if (!line.StartsWith("fold") && line.Length > 0)
         {
            string[] nums = line.Split(",");
            graph.Add((int.Parse(nums[0]), int.Parse(nums[1])));
         }
      }

      int xFold = 655;

      List<(int,int)> pointsToMove = graph.FindAll(p => p.Item1 > xFold);

      foreach ((int,int) point in pointsToMove)
      {
         int xOffset = (point.Item1 - xFold) * 2;
         (int,int) newPoint = (point.Item1 - xOffset, point.Item2);

         if (!graph.Contains(newPoint))
         {
            graph.Add(newPoint);
         }

         graph.Remove(point);
      }

      return graph.Count.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day13/input.txt");
      List<(int, int)> graph = new List<(int, int)>();
      List<(string, int)> folds = new List<(string, int)>();

      foreach (string line in lines)
      {
         if (line.StartsWith("fold")) 
         {
            string[] vals = line.Split("=");
            folds.Add((vals[0].Substring(vals[0].Length - 1), int.Parse(vals[1])));
         }
         else if (line.Length == 0) {}
         else
         {
            string[] nums = line.Split(",");
            graph.Add((int.Parse(nums[0]), int.Parse(nums[1])));
         }
      }

      foreach ((string,int) fold in folds)
      {
         if (fold.Item1 == "x")
         {
            int xFold = fold.Item2;
            List<(int, int)> pointsToMove = graph.FindAll(p => p.Item1 > xFold);

            foreach ((int, int) point in pointsToMove)
            {
               int xOffset = (point.Item1 - xFold) * 2;
               (int, int) newPoint = (point.Item1 - xOffset, point.Item2);

               if (!graph.Contains(newPoint))
               {
                  graph.Add(newPoint);
               }

               graph.Remove(point);
            }
         }
         else if (fold.Item1 == "y")
         {
            int yFold = fold.Item2;
            List<(int, int)> pointsToMove = graph.FindAll(p => p.Item2 > yFold);

            foreach ((int, int) point in pointsToMove)
            {
               int yOffset = (point.Item2 - yFold) * 2;
               (int, int) newPoint = (point.Item1, point.Item2 - yOffset);

               if (!graph.Contains(newPoint))
               {
                  graph.Add(newPoint);
               }

               graph.Remove(point);
            }
         }
      }

      printGraph(graph);
      return "";
   }

   private void printGraph(List<(int,int)> graph)
   {
      int x = 40, y = 10;

      for (int j = 0; j < y; j++)
      {
         for (int i = 0; i < x; i++)
         {
            if (graph.Contains((i,j)))
            {
               Console.Write("#");
            }
            else
            {
               Console.Write(" ");
            }
         }

         Console.WriteLine();
      }
   }
}