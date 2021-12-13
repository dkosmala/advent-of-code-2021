using System;
using System.Collections.Generic;
using System.Linq;

public class Day12
{
   public int sum = 0;

   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day12/input.txt");
      List<Cave> graph = new List<Cave>();
      

      foreach (string line in lines)
      {
         string[] caves = line.Split("-");
         Cave cave1 = graph.Find(c => c.name == caves[0]);

         if (cave1 == null) {
            cave1 = new Cave { name = caves[0], neighbors = new List<Cave>() };
            graph.Add(cave1);
         }

         Cave cave2 = graph.Find(c => c.name == caves[1]);

         if (cave2 == null)
         {
            cave2 = new Cave { name = caves[1], neighbors = new List<Cave>() };
            graph.Add(cave2);
         }

         cave1.neighbors.Add(cave2);
         cave2.neighbors.Add(cave1);
      }

      Cave start = graph.Find(c => c.name == "start");
      Cave end = graph.Find(c => c.name == "end");
      List<string> visited = new List<string>();
      List<Cave> path = new List<Cave>();

      path.Add(start);
      findPath(start, end, visited, path);

      return sum.ToString();
   }

   private void findPath(Cave start, Cave end, List<string> visited, List<Cave> path)
   {
      if (start.name == end.name) {
         Console.WriteLine(string.Join(" ", path));
         sum++;
         return;
      }

      if (start.name == start.name.ToLower()) {
         visited.Add(start.name);
      }

      foreach (Cave cave in start.neighbors) {
         if (!visited.Contains(cave.name)) {
            path.Add(cave);
            findPath(cave, end, visited, path);
            path.RemoveAt(path.FindLastIndex(c => c.name == cave.name));
         }
      }

      visited.Remove(start.name);
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day12/input.txt");
      List<Cave> graph = new List<Cave>();


      foreach (string line in lines)
      {
         string[] caves = line.Split("-");
         Cave cave1 = graph.Find(c => c.name == caves[0]);

         if (cave1 == null)
         {
            cave1 = new Cave { name = caves[0], neighbors = new List<Cave>() };
            graph.Add(cave1);
         }

         Cave cave2 = graph.Find(c => c.name == caves[1]);

         if (cave2 == null)
         {
            cave2 = new Cave { name = caves[1], neighbors = new List<Cave>() };
            graph.Add(cave2);
         }

         cave1.neighbors.Add(cave2);
         cave2.neighbors.Add(cave1);
      }

      Cave start = graph.Find(c => c.name == "start");
      Cave end = graph.Find(c => c.name == "end");
      List<string> visited = new List<string>();
      List<Cave> path = new List<Cave>();

      path.Add(start);
      findPath2(start, end, visited, path, false);

      return sum.ToString();      
   }

   private void findPath2(Cave start, Cave end, List<string> visited, List<Cave> path, bool twiceVisit)
   {
      if (start.name == end.name)
      {
         Console.WriteLine(string.Join(" ", path));
         sum++;
         return;
      }

      if (start.name == start.name.ToLower())
      {
         visited.Add(start.name);

         if (visited.Count(c => c == start.name) >= 2) {
            twiceVisit = true;
         }
      }

      foreach (Cave cave in start.neighbors)
      {
         if (!visited.Contains(cave.name) || (twiceVisit == false && cave.name != "start" && cave.name != "end"))
         {
            path.Add(cave);
            findPath2(cave, end, visited, path, twiceVisit);
            path.RemoveAt(path.FindLastIndex(c => c.name == cave.name));
         }
      }

      visited.Remove(start.name);

      if (visited.Count(c => c == start.name) == 1)
      {
         twiceVisit = false;
      }
   }

   public class Cave
   {
      public string name;
      public List<Cave> neighbors;

      public override string ToString()
      {
         return name;
      }
   }
}