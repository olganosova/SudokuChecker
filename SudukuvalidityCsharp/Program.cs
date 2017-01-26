using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudukuvalidityCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test is started");

            bool isValid = ProcessFile();

            Console.WriteLine("The file is valid Sudoku pattern? {0}", isValid.ToString());
            Console.WriteLine(SudokuChecker.ErrorMessage);
            System.Console.ReadKey();
        }

        public static bool ProcessFile()
        {
           

            //if for some reason this path is not working in local env, change for the full path to the file on local machine
            string fileName = SudokuChecker.getPathToFile(); // @"C:\Users\Administrator\Desktop\input_sudoku.txt";

            return SudokuChecker.validateFileFormat(fileName);

        }
    }
}
