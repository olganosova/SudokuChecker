using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudukuvalidityCsharp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //if for some reason this path is not working in local env, change for the full path to the file on local machine
            string fileName = SudokuChecker.getPathToFile(); // @"C:\Users\Administrator\Desktop\input_sudoku.txt";

            bool result = false;

            result = SudokuChecker.validateFileFormat(fileName);
        }
    }
}
