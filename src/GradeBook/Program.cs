using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new Book("Scott's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);

            // var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            // grades.Add(56.1); 

            // var result = 0.0;
            // foreach(var number in grades)
            // {
                
            //     result += number;
            // } 
            // result /= grades.Count;
            // Console.WriteLine($"The average grade is {result:N1}");


            var book = new Book("Scott's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            //The event 'Book.GradeAdded' can only appear on the left hand side of += or -= 
            //(except when used from within the type 'Book') [GradeBook]csharp(CS0070)
            //book.GradeAdded = null;

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
            var stats = book.GetStatistics();         
            
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Added Grade.");
        }
    }
}
