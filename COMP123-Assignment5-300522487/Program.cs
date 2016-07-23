using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * Author: Meer Zaheen
 * Date: July 22, 2016
 * StudentID: 300522487
 * Description: A program that stores student grades in	a text file	and	displays them to
   the console
 * Version: 0.01 
 */

namespace COMP123_Assignment5_300522487
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        /**
        * <summary>
        * This method displays the menu using a while loop
        * </summary>
        * 
        * @static
        * @method DisplayMenu
        * 
        * @returns {void}
        */
        static void DisplayMenu()
        {
            int options = 0;
            while (options != 2)
            {
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+    1. Display Grades    +");
                Console.WriteLine("+    2. Exit              +");
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.Write("Please make your selection: ");

                try
                {
                    options = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception Error)
                {
                    Console.WriteLine(Error.Message);
                    options = 0;
                }
                switch (options)
                {
                    case 1:
                        ShowGrades();
                        break;
                    case 2:
                        options = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        /**
         * <summary>
         * This method displays the menu using a while loop placed in a try and catch.
         * </summary>
         * 
         * @static
         * @method DisplayGrades
         * 
         * @returns {void}
         */
        static void ShowGrades()
        {
            try
            {
                List<student> students = new List<student>();
                const char DELIM = ',';
                const string FILENAME = "..\\..\\grades.txt";

                // opening filestream
                FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                // setup variables to temporariliy hold my data
                string recordString;
                string[] fields;
                // read from file and assign the record to recordIN
                recordString = reader.ReadLine();
                while (recordString != null)
                {
                    student student = new student();
                    fields = recordString.Split(DELIM);
                    student.FirstName = fields[0];
                    student.LastName = fields[1];
                    student.ID = fields[2];
                    student.Grade = fields[3];
                    students.Add(student);

                    Console.WriteLine("{0} {1} {2} {3}",
                        student.FirstName,
                        student.LastName,
                        student.ID,
                        student.Grade);

                    recordString = reader.ReadLine();
                }

                // close streams
                reader.Close();
                inFile.Close();
            }
            catch (Exception exception)
            {

                Console.WriteLine("Error: " + exception.Message);
            }

        }
    }
}
