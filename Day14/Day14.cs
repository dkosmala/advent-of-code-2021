using System;
using System.Collections.Generic;
using System.Linq;

public class Day14
{
   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day14/input.txt");
      string template = "";
      Dictionary<string, string> rules = new Dictionary<string, string>();

      foreach (string line in lines)
      {
         if (line.Length > 7)
         {
            template = line;
         }
         else if (line.Length == 0) {}
         else
         {
            string[] vals = line.Split(" -> ");
            rules.Add(vals[0], vals[1]);
         }
      }

      for (int step = 1; step <= 10; step++)
      {
         string pair = "";
         string newTemplate = template[0].ToString();
         for (int i = 0; i < template.Length - 1; i++)
         {
            pair = template.Substring(i, 2);
            newTemplate += rules.GetValueOrDefault(pair) + template[i + 1];
         }

         template = newTemplate;
      }

      Dictionary<char, int> chars = new Dictionary<char, int>();

      foreach (char c in template)
      {
         if (chars.ContainsKey(c)) chars[c]++;
         else chars.Add(c, 1);
      }

      List<KeyValuePair<char, int>> list = chars.ToList();
      list.Sort((p1,p2) => p2.Value.CompareTo(p1.Value));

      return Convert.ToString(list[0].Value - list[list.Count-1].Value);
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day14/input.txt");
      string template = "";
      Dictionary<string, string> rules = new Dictionary<string, string>();
      Dictionary<string, long> pairs = new Dictionary<string, long>();
      Dictionary<string, long> newPairs;
      Dictionary<char, double> chars = new Dictionary<char, double>();

      foreach (string line in lines)
      {
         if (line.Length > 7)
         {
            template = line;
         }
         else if (line.Length == 0) { }
         else
         {
            string[] vals = line.Split(" -> ");
            rules.Add(vals[0], vals[1]);
         }
      }

      for (int i = 0; i < template.Length-1; i++)
      {
         string pair = template[i].ToString() + template[i+1].ToString();
         if (!pairs.ContainsKey(pair)) pairs[pair] = 0;
         pairs[pair]++;

         if (!chars.ContainsKey(template[i])) chars[template[i]] = 0;
         chars[template[i]]++;
      }

      // hack
      chars['C']++;
      
      string p1, p2;
      char newChar;
      for (int step = 1; step <= 40; step++)
      {
         newPairs = new Dictionary<string, long>();

         foreach (string pair in pairs.Keys)
         {
            newChar = rules[pair][0];

            p1 = pair[0] + newChar.ToString();
            p2 = newChar.ToString() + pair[1];

            if (!newPairs.ContainsKey(p1)) newPairs[p1] = 0;
            if (!newPairs.ContainsKey(p2)) newPairs[p2] = 0;

            newPairs[p1] += pairs[pair];
            newPairs[p2] += pairs[pair];

            if (!chars.ContainsKey(newChar)) chars[newChar] = 0;
            chars[newChar] += pairs[pair];
         }

         pairs = newPairs;
      }

      List<KeyValuePair<char, double>> list = chars.ToList();
      list.Sort((p1, p2) => p2.Value.CompareTo(p1.Value));

      return Convert.ToString(list[0].Value - list[list.Count - 1].Value);
   }
}