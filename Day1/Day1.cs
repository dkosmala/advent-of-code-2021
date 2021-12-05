using System;

public class Day1 
{
   public string first() {
      int incCount = 0;
      int prevNum = -1;

      string[] lines = System.IO.File.ReadAllLines(@"Day1-1 input.txt");

      foreach (string line in lines) {
         int num = Convert.ToInt32(line);

         if (prevNum == -1) {
            prevNum = num;
            continue;
         }

         if (num > prevNum) {
            incCount++;
         }

         prevNum = num;
      }

      return Convert.ToString(incCount);
   }

   public string second() {
      int incCount = 0;
      int prevSum = 9999;
      int currSum = 0;

      string[] lines = System.IO.File.ReadAllLines(@"Day1/Day1-1 input.txt");
      int[] numLines = Array.ConvertAll(lines, line => Convert.ToInt32(line));

      for (int n = 2; n < lines.Length; n++) {
         currSum = numLines[n] + numLines[n-1] + numLines[n-2];

         if (currSum > prevSum) {
            incCount++;
         }

         prevSum = currSum;
      }

      return Convert.ToString(incCount);
   }
}