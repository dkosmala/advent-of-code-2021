using System;

public class Day2
{
   public string first() 
   {
      int hPos = 0;
      int dPos = 0;
      
      string[] lines = System.IO.File.ReadAllLines(@"Day2/input.txt");

      string[] vals;
      foreach (string line in lines) {
         vals = line.Split(" ");

         switch (vals[0]) {
            case "forward":
               hPos += Convert.ToInt32(vals[1]);
               break;
            case "down":
               dPos += Convert.ToInt32(vals[1]);
               break;
            case "up":
               dPos -= Convert.ToInt32(vals[1]);
               break;
         }
      }

      return Convert.ToString(hPos * dPos);
   }

   public string second()
   {
      int hPos = 0;
      int dPos = 0;
      int aim = 0;
      
      string[] lines = System.IO.File.ReadAllLines(@"Day2/input.txt");

      string[] vals;
      foreach (string line in lines) {
         vals = line.Split(" ");

         switch (vals[0]) {
            case "forward":
               hPos += int.Parse(vals[1]);
               dPos += aim * int.Parse(vals[1]);
               break;
            case "down":
               aim += int.Parse(vals[1]);
               break;
            case "up":
               aim -= int.Parse(vals[1]);
               break;
         }
      }

      return Convert.ToString(hPos * dPos);
   }
}