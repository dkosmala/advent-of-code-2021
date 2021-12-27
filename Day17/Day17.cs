using System;

public class Day17
{
   public void first()
   {
      // did this part manually
   }

   public string second()
   {
      // target area: x=230..283, y=-107..-57
      int minX = 21;
      int maxX = 283;
      int minY = -107;
      int maxY = 107;

      int botX = 230;
      int botY = -57;
      int topX = 283;
      int topY = -107;

      int sum = 0;

      int tempX = 0, tempY = 0;
      for (int x = minX; x <= maxX; x++) {
         for (int y = minY; y <= maxY; y++) {
            Console.WriteLine("x: " + x + ", y: " + y);
            tempX = 0;
            tempY = 0;
            int n = 0;

            while (tempX <= topX && tempY >= topY) {
               tempX += (x - n) < 0 ? 0 : (x - n);
               tempY += (y - n);

               if (tempX >= botX && tempX <= topX && tempY <= botY && tempY >= topY) {
                  sum++;
                  break;
               }

               n++;
            }
         }
      }

      return sum.ToString();
   }
}