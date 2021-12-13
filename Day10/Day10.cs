using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Day10
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day10/input.txt");
      string line;
      int sum = 0;
      Regex regex = new Regex("[\\]})>]");
      Dictionary<char,int> score = new Dictionary<char, int>(){{')', 3}, {']', 57}, {'}', 1197}, {'>', 25137}};

      foreach (string l in lines) {
         line = l;

         while (line.Contains("[]") || line.Contains("{}") || line.Contains("()") || line.Contains("<>"))
         {
            line = line.Replace("[]", "");
            line = line.Replace("{}", "");
            line = line.Replace("()", "");
            line = line.Replace("<>", "");
         }

         if (!regex.IsMatch(line)) {
            // valid line, continue
            continue;
         } else {
            int index = line.IndexOf(regex.Match(line).Value);
            sum += score.GetValueOrDefault(line[index]);
         }
      }

      return sum.ToString();
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day10/input.txt");
      string line, complete;
      Regex regex = new Regex("[\\]})>]");
      Dictionary<char, char> chunkChars = new Dictionary<char, char>() { { '[', ']' }, { '{', '}' }, { '(', ')' }, { '<', '>' } };
      List<double> scores = new List<double>();

      foreach (string l in lines)
      {
         line = l;

         while (line.Contains("[]") || line.Contains("{}") || line.Contains("()") || line.Contains("<>"))
         {
            line = line.Replace("[]", "");
            line = line.Replace("{}", "");
            line = line.Replace("()", "");
            line = line.Replace("<>", "");
         }

         if (!regex.IsMatch(line))
         {
            complete = "";
            foreach (char c in line.ToCharArray()) {
               complete += chunkChars.GetValueOrDefault(c);
            }

            char[] charArray = complete.ToCharArray();
            Array.Reverse(charArray);
            complete = new string(charArray);
            scores.Add(calcScore(complete));
         }
      }

      scores.Sort();
      return scores[scores.Count/2].ToString();
   }

   private double calcScore(string line)
   {
      Dictionary<char, int> score = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
      double sum = 0;

      foreach (char c in line.ToCharArray()) {
         sum = (sum * 5) + score.GetValueOrDefault(c);
      }

      return sum;
   }
}