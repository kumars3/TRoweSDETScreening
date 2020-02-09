using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Configuration;
using System.IO;

namespace TRowePriceSDETScreening
{
    [TestClass]
    public class BusinessBuilder
    {
        //Variable declaration. File path read from App.config
        private static readonly string FilePath = ConfigurationManager.AppSettings["FilePath"];
        private static readonly List<string> FileContentList = BusinessBuilder.GetFileContent().Split(' ').ToList();
        private static readonly List<string> ExpectedShortestWordList = new List<string>() { "The", "cow" };
        private static readonly List<string> ExpectedLongestWordList = new List<string>() { "jumped" };
        private static string _fileContent = "";

        //Test or method one to get get longest word from a given string
        [TestMethod]
        public void GetLongestLengthWordList()
        {
            var arrayLongestWords = FileContentList.OrderByDescending(item => item.Length).ToArray();
            GetShortestLengthWords(arrayLongestWords, false);
        }
        //Test or method two to get get shortest word from a given string
        [TestMethod]
        public void GetShortestLengthWordList()
        {
            var arrayShortestWords = FileContentList.OrderBy(item => item.Length).ToArray();
            GetShortestLengthWords(arrayShortestWords, true);
        }
        /*Function to read the given text from a file located in a folder path specified in App.config
         If file is not at the given folder throw FileNotFoundException*/
        private static string GetFileContent()
        {
            try
            {
                _fileContent = File.ReadAllText(FilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return _fileContent;
        }
        //Actual method to apply logic to find longest and shortest word(s) in a string and print only DISTINCT word ignoring its case
        public void GetShortestLengthWords(string[] actualCollection, bool isShortest)
        {
            var collectionList = new List<string>() { };
            string prev = actualCollection[0];
            foreach (var item in actualCollection)
            {
                if (item.Length == prev.Length)
                {
                    prev = item;
                    collectionList.Add(item);
                }
                else
                    break;
            }
            if (isShortest == true)
            {
                for (int i = 0; i < ExpectedShortestWordList.Count; i++)
                {
                    Assert.AreEqual(ExpectedShortestWordList.OrderBy(x => x).ToList()[i], collectionList.Distinct(StringComparer.CurrentCultureIgnoreCase).OrderBy(x => x).ToList()[i]);
                    Console.WriteLine("The shortest word is(are): " + ExpectedShortestWordList.OrderBy(x => x).ToList()[i]);
                } 
                Console.WriteLine("The lenght of the shortest word(s) is: " + ExpectedShortestWordList.First().Length);
            }
            else
            {
                for (int i = 0; i < ExpectedLongestWordList.Count; i++)
                {
                    Assert.AreEqual(ExpectedLongestWordList.OrderByDescending(x => x).ToList()[i], collectionList.Distinct(StringComparer.CurrentCultureIgnoreCase).OrderByDescending(x => x).ToList()[i]);
                    Console.WriteLine("The longest word(s) is(are): " + ExpectedLongestWordList.OrderBy(x => x).ToList()[i]);
                }
                Console.WriteLine("The length of longest word(s) is: " + ExpectedLongestWordList.First().Length);
            }
        }
    }
}
