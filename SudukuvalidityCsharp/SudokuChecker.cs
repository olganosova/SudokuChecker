using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukuvalidityCsharp
{
    public static class SudokuChecker
    {
       public static string ErrorMessage
       {
           get;
           private set;
       }

       public static string getPathToFile()
       {
           string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.ToString();
           path = path.Replace("file:///", "");
           try
           {
               int length = path.IndexOf("/bin");
               path = path.Substring(0, length) + "/input_sudoku.txt";
           }
           catch (Exception ex)
           {
               path = "";
           }

           return path;
       }
                
        public static bool validateFileFormat(string filename)
        {
            ErrorMessage = "";
            bool result = false;

            string[] lines = new string[]{};
            try
            {
                lines = System.IO.File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return result;
            }

            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //check number of lines
            if (lines.Length < 9)
            {
                ErrorMessage = "Files does not contain 9 lines";
                return result;
            }
            //check number of columns and if all numbers
            foreach(string line in lines){
                if (line.Length != 9)
                {
                    ErrorMessage = "Line does not contain 9 characters";
                    break;
                }
               char[] letters = line.ToCharArray();
               foreach(char c in letters){
                   if (!Char.IsNumber(c))
                   {
                       ErrorMessage = "File contains non-numeric characters";
                       break;
                   }
               }
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return result;
            }
            //now we are good, we have have 9 X 9 numbers so no more try-catch blocks
            List<string> sets = makeSets(lines);

            return checkSets(sets);
        }

        private static List<string> makeSets(string[] lines)  //must return 27 sets
        {
            List<string> sets = new List<string>();
            List<string> verticals = new List<string>();
            List<string> boxes = new List<string>();

            //add horizontal sets
            sets.AddRange(lines);

            //add vertical and boxes sets
             for (int ix = 0; ix < 9; ix++)
             {
                verticals.Add("");
                boxes.Add("");
             }

             int countLines = 0;
             int boxIndexExt = 0;
            
            foreach (string line in lines){

                int boxIndex = 0;

             for (int x = 0; x < 9; x++)
             {
                verticals[x] += line[x].ToString();
                
                 if (x % 3 == 0 && x != 0)
                 {
                     boxIndex++;
                 }
                 boxes[boxIndex + boxIndexExt] += line[x].ToString();

             }
             countLines++;
            
             if (countLines % 3 == 0 && countLines != 0)
             {
                 boxIndexExt = boxIndexExt + 3;
             }
           
            
            }
            sets.AddRange(verticals);
            sets.AddRange(boxes);

            return sets;

        }

        private static bool checkSets(List<string> sets) 
        {
            bool result = true;
            //we will compare each set to our etalon array
            int[] etalon = new int[] { 1,2,3,4,5,6,7,8,9 };

            foreach(string set in sets){
                int[] nums = new int[9];

                for (int x = 0; x < 9; x++)
                {
                    nums[x] =  (int)Char.GetNumericValue(set[x]);
                   
                }
                Array.Sort(nums);
                bool isValid = nums.SequenceEqual(etalon);
                if (!isValid)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

      
        
    }
}
