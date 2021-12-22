using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private Program() { }

        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> unsortedList = new List<int>();
            for(int i = 0; i < 50; i++)
            {
                unsortedList.Add(rand.Next(2000));
            }

            PrintList(unsortedList);
            List<int> sortedList = MergeSort(unsortedList);
            PrintList(sortedList);
        }

        public static List<int> MergeSort(List<int> unsortedList)
        {
            if (unsortedList.Count == 1)
            {
                return unsortedList;
            }

            int rangeA = unsortedList.Count / 2;
            List<int> unsortedSublistA = unsortedList.GetRange(0, unsortedList.Count / 2);
            List<int> sortedSublistA = MergeSort(unsortedSublistA);

            int rangeB = unsortedList.Count % 2 == 0 ? rangeA : rangeA + 1;
            List<int> unsortedSublistB = unsortedList.GetRange(unsortedList.Count / 2, rangeB);
            List<int> sortedSublistB = MergeSort(unsortedSublistB);

            List<int> sortedList = MergeOperation(sortedSublistA, sortedSublistB);
            return sortedList;
        }

        private static List<int> MergeOperation(List<int> sortedSublistA, List<int> sortedSublistB)
        {
            List<int> sortedList = new List<int>();
            while (sortedSublistA.Count > 0 && sortedSublistB.Count > 0)
            {
                int elementA = sortedSublistA[0];
                int elementB = sortedSublistB[0];
                MoveSmallerElementToSortedList(sortedSublistA, sortedSublistB, sortedList, elementA, elementB);
            }

            sortedList.AddRange(sortedSublistB.Count > 0 ? sortedSublistB : sortedSublistA);
            return sortedList;
        }

        private static void MoveSmallerElementToSortedList(List<int> sortedSublistA, List<int> sortedSublistB, List<int> sortedList, int elementA, int elementB)
        {
            if (elementA > elementB)
            {
                sortedList.Add(elementB);
                sortedSublistB.RemoveAt(0);
            }
            else
            {
                sortedList.Add(elementA);
                sortedSublistA.RemoveAt(0);
            }
        }

        public static void PrintList(List<int> listToPrint)
        {
            string listString = CreateListString(listToPrint);
            string borderString = CreateBorderString(listString);

            Console.WriteLine("------------------");
            Console.WriteLine($"Size of List: '{listToPrint.Count}'");
            Console.WriteLine(borderString);
            Console.WriteLine(listString);
            Console.WriteLine(borderString);
        }

        private static string CreateListString(List<int> listToPrint)
        {
            string listString = "";
            foreach (int element in listToPrint)
            {
                listString = $"{listString}| {element} ";
            }
            listString += "|";
            return listString;
        }

        private static string CreateBorderString(string listString)
        {
            string borderString = "";
            foreach (char c in listString)
            {
                borderString = $"{borderString}-";
            }
            return borderString;
        }
    }
}
