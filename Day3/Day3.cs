using System;
using System.Collections.Generic;
using System.Linq;

public class Day3
{
   public string first() 
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day3/input.txt");
      int[] sums = new int[lines[0].Length];

      foreach (string line in lines) {
         for (int i = 0; i < line.Length; i++) {
            if (line[i] == '1') {
               sums[i]++;
            }
         }
      }

      string gamma = "", epsilon = "";
      foreach (int sum in sums) {
         if (sum > (lines.Length / 2)) {
            gamma += "1";
            epsilon += "0";
         } else {
            gamma += "0";
            epsilon += "1";
         }
      }

      int intGam = Convert.ToInt32(gamma, 2);
      int intEps = Convert.ToInt32(epsilon, 2);

      return Convert.ToString(intGam * intEps);
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day3/input.txt");
      List<string> list = lines.ToList();

      int oxyGen = Convert.ToInt32(parseLines(list, 0, "oxygen"), 2);
      int co2 = Convert.ToInt32(parseLines(list, 0, "co2"), 2);

      return Convert.ToString(oxyGen * co2);
   }

   private string parseLines(List<string> lines, int pos, string type) {
      if (lines.Count <= 1) {
         return lines[0];
      }

      int sum = 0;

      foreach (string line in lines) {
         if (line[pos] == '1') {
            sum++;
         }
      }

      char winner;
      if (type == "oxygen") {
         if ((sum * 2) >= lines.Count) {
            winner = '1';
         } else {
            winner = '0';
         }
      } else {
         if ((sum * 2) >=  lines.Count) {
            winner = '0';
         } else {
            winner = '1';
         }
      }

      List<string> newLines = lines.FindAll(s => s[pos].Equals(winner));

      return parseLines(newLines, ++pos, type);
   }

}