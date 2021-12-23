using System;
using System.Collections.Generic;
using System.Linq;

public class Day16
{
   public int sum = 0;

   public string first()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day16/input.txt");
      string hexLine = lines[0];
      string binaryLine = "";

      foreach (char c in hexLine)
      {
         binaryLine += Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
      }

      int iter = 0;
      analyzePacketFirst(binaryLine, ref iter);

      return sum.ToString();
   }

   private void analyzePacketFirst(string line, ref int iter)
   {
      string version = line.Substring(iter, 3);
      iter += 3;
      sum += Convert.ToInt32(version, 2);

      string type = line.Substring(iter, 3);
      iter += 3;

      if (type == "100")
      {
         // literal
         string num = "";
         do
         {
            iter++;
            num += line.Substring(iter, 4);
            iter += 4;
         }
         while (line[iter-5] == '1');
      }
      else
      {
         char lengthType = line[iter];
         if (lengthType == '0')
         {
            iter++;
            string length = line.Substring(iter, 15);
            iter += 15;
            int bitLength = Convert.ToInt32(length, 2);
            int fullLength = iter + bitLength;

            while (iter < fullLength)
            {
               analyzePacketFirst(line, ref iter);
            }
         }
         else
         {
            iter++;
            string length = line.Substring(iter, 11);
            iter += 11;
            int numPackets = Convert.ToInt32(length, 2);

            for (int i = 0; i < numPackets; i++)
            {
               analyzePacketFirst(line, ref iter);
            }
         }
      }

      return;
   }

   public string second()
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day16/input.txt");
      string hexLine = lines[0];
      string binaryLine = "";

      foreach (char c in hexLine)
      {
         binaryLine += Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
      }

      int iter = 0;
   
      return analyzePacketSecond(binaryLine, ref iter).ToString();
   }

   private long analyzePacketSecond(string line, ref int iter)
   {
      string version = line.Substring(iter, 3);
      iter += 3;

      string type = line.Substring(iter, 3);
      iter += 3;
      int numType = Convert.ToInt32(type, 2);

      if (numType == 4)
      {
         // literal
         string num = "";
         do
         {
            iter++;
            num += line.Substring(iter, 4);
            iter += 4;
         }
         while (line[iter - 5] == '1');

         return Convert.ToInt64(num, 2);
      }
      else
      {
         List<long> values = new List<long>();
         char lengthType = line[iter];
         if (lengthType == '0')
         {
            iter++;
            string length = line.Substring(iter, 15);
            iter += 15;
            int bitLength = Convert.ToInt32(length, 2);
            int fullLength = iter + bitLength;

            while (iter < fullLength)
            {
               values.Add(analyzePacketSecond(line, ref iter));
            }
         }
         else
         {
            iter++;
            string length = line.Substring(iter, 11);
            iter += 11;
            int numPackets = Convert.ToInt32(length, 2);

            for (int i = 0; i < numPackets; i++)
            {
               values.Add(analyzePacketSecond(line, ref iter));
            }
         }

         long sum = 0;
         switch (numType)
         {
            case 0:
               foreach (long value in values) sum += value;
               break;

            case 1:
               sum = 1;
               foreach (long value in values) sum *= value;
               break;

            case 2:
               sum = values.Min();
               break;

            case 3:
               sum = values.Max();
               break;

            case 5:
               sum = values[0] > values[1] ? 1 : 0;
               break;

            case 6:
               sum = values[0] < values[1] ? 1 : 0;
               break;

            case 7:
               sum = values[0] == values[1] ? 1 : 0;
               break;
         }

         return sum;
      }
   }
}