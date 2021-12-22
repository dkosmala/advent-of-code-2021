using System;
using System.Collections.Generic;
using System.Linq;

public class Day15
{
   public class Node
   {
      public int x { get; set; }
      public int y { get; set; }
      public int risk {get; set; }

      public Node(int x, int y, int risk)
      {
         this.x = x;
         this.y = y;
         this.risk = risk;
      }
   }

   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day15/input.txt");
      List<Node> map = new List<Node>();

      for(int y = 0; y < lines.Length; y++)
      {
         for(int x = 0; x < lines[y].Length; x++)
         {
            map.Add(new Node(x, y, (int)Char.GetNumericValue(lines[y][x])));
         }
      }

      PriorityQueue<Node, int> frontier = new PriorityQueue<Node, int>();
      Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
      Dictionary<Node, int> riskSoFar = new Dictionary<Node, int>();
      Node current, endNode;
      int newRisk = 0;

      current = map.Single(n => n.x == 0 && n.y == 0);
      frontier.Enqueue(current, 0);
      cameFrom[current] = null;
      riskSoFar[current] = 0;

      endNode = map.Single(n => n.x == 99 && n.y == 99);

      while (frontier.Count > 0)
      {
         current = frontier.Dequeue();

         if (current == endNode)
         {
            break;
         }

         List<Node> neighbors = GetNeighbors(map, current);
         foreach(Node next in neighbors)
         {
            newRisk = riskSoFar[current] + next.risk;
            if (!riskSoFar.ContainsKey(next) || newRisk < riskSoFar[next])
            {
               riskSoFar[next] = newRisk;
               frontier.Enqueue(next, newRisk);
               cameFrom[next] = current;
            }
         }
      }

      return riskSoFar[current].ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day15/input.txt");
      List<Node> map = new List<Node>();
      int addFactor, risk;

      for (int y = 0; y < (lines.Length * 5); y++)
      {
         for (int x = 0; x < (lines[y % 100].Length * 5); x++)
         {
            addFactor = (x / 100) + (y / 100);
            risk = (int)Char.GetNumericValue(lines[y % 100][x % 100]) + addFactor;
            if (risk > 9) risk -= 9;

            map.Add(new Node(x, y, risk));
         }
      }

      PriorityQueue<Node, int> frontier = new PriorityQueue<Node, int>();
      Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
      Dictionary<Node, int> riskSoFar = new Dictionary<Node, int>();
      Node current, endNode;
      int newRisk = 0;

      current = map.Single(n => n.x == 0 && n.y == 0);
      frontier.Enqueue(current, 0);
      cameFrom[current] = null;
      riskSoFar[current] = 0;

      endNode = map.Single(n => n.x == 499 && n.y == 499);

      int analyzed = 0;
      while (frontier.Count > 0)
      {
         current = frontier.Dequeue();
         analyzed++;

         if (analyzed % 10 == 0) Console.WriteLine(analyzed);

         if (current == endNode)
         {
            break;
         }

         List<Node> neighbors = GetNeighbors(map, current);
         foreach (Node next in neighbors)
         {
            newRisk = riskSoFar[current] + next.risk;
            if (!riskSoFar.ContainsKey(next) || newRisk < riskSoFar[next])
            {
               riskSoFar[next] = newRisk;
               frontier.Enqueue(next, newRisk);
               cameFrom[next] = current;
            }
         }
      }

      return riskSoFar[current].ToString();      
   }

   private List<Node> GetNeighbors(List<Node> map, Node current)
   {
      return map.FindAll(n => (n.x == current.x - 1 && n.y == current.y) ||
         (n.x == current.x + 1 && n.y == current.y) ||
         (n.y == current.y - 1 && n.x == current.x) ||
         (n.y == current.y + 1 && n.x == current.x) );
   }
}
