using System;
using System.Collections.Generic;
using System.Linq;

public class Day4
{
   public string first() 
   {
      string[] lines = System.IO.File.ReadAllLines(@"Day4/input.txt");
      string[] nums = lines[0].Split(',');
      List<List<string>> boards = new List<List<string>>();

      // create the boards
      int n = 0;
      List<string> board = null;
      foreach(string line in lines) {
         if (line == "") {
            n = 0;
            continue;
         }

         if (n == 0) {
            board = new List<string>();
         }

         board.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
         n++;

         if (n > 4) {
            //Console.WriteLine(string.Join(" ", board));
            boards.Add(board);
         }
      }

      // mark and evaluate
      bool winner;
      foreach (string num in nums) {
         foreach (List<string> chkBoard in boards) {
            int index = chkBoard.FindIndex(s => s.Equals(num));

            if (index != -1) {
               chkBoard[index] = "-1";

               // now evaluate the board to see if it's a winner
               winner = evalBoard(chkBoard, index);

               if (winner) {
                  // Console.WriteLine(string.Join(" ", chkBoard));
                  // Console.WriteLine(num);
                  int sum = 0;
                  foreach (string x in chkBoard) {
                     if (x != "-1") {
                        sum += Convert.ToInt32(x);
                     }
                  }

                  return Convert.ToString(sum * Convert.ToInt32(num));
               }
            }
         }
      }

      return "";
   }

   public string second() {
      string[] lines = System.IO.File.ReadAllLines(@"Day4/input.txt");
      string[] nums = lines[0].Split(',');
      List<List<string>> boards = new List<List<string>>();

      // create the boards
      int n = 0;
      List<string> board = null;
      foreach(string line in lines) {
         if (line == "") {
            n = 0;
            continue;
         }

         if (n == 0) {
            board = new List<string>();
         }

         board.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
         n++;

         if (n > 4) {
            //Console.WriteLine(string.Join(" ", board));
            boards.Add(board);
         }
      }

      // mark and evaluate
      bool winner;
      foreach (string num in nums) {
         for (int i = boards.Count - 1; i >= 0; i--) {
            List<string> chkBoard = boards[i];
            int index = chkBoard.FindIndex(s => s.Equals(num));

            if (index != -1) {
               chkBoard[index] = "-1";

               // now evaluate the board to see if it's a winner
               winner = evalBoard(chkBoard, index);

               if (winner) {
                  // Console.WriteLine(string.Join(" ", chkBoard));
                  // Console.WriteLine(num);
                  if (boards.Count > 1) {
                     boards.RemoveAt(i);
                  } else {
                     int sum = 0;
                     foreach (string x in chkBoard) {
                        if (x != "-1") {
                           sum += Convert.ToInt32(x);
                        }
                     }

                     return Convert.ToString(sum * Convert.ToInt32(num));
                  }
               }
            }
         }
      }

      return "";
   }

   private bool evalBoard(List<string> board, int index) {
      bool winner = true;
      int i = index;
      List<int> begVals = new List<int>(new int[] {0,5,10,15,20});

      // hEval
      while (!begVals.Contains(i)) {
         i -= 1;
      }

      for (int j = i; j < i+5; j++) {
         if (board.ElementAt(j) != "-1") {
            winner = false;
            break;
         }
      }

      if (winner == true) return true;

      i = index;
      // vEval
      while (i >= 0) {
         i -= 5;
      }
      i += 5;

      while (i < 25) {
         if (board.ElementAt(i) != "-1") {
            return false;
         }
         i += 5;
      }

      return true;
   }
}