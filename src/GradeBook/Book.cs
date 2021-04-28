using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            category = "";
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);                
            }
            else
            {
                //Console.WriteLine("Invalid Value");
                throw new ArgumentException($"Invalid {nameof(grade)} ({grade.GetType()})");
            }
        }
        
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;            
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            } 

            // for (var index = 0; index < grades.Count; index += 1)
            // {
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Average += grades[index];
            // }

            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        // public string Name 
        // {
        //     get
        //     {
        //         return name.ToUpper();
        //     }
        //     set 
        //     {
        //         //if (value != null)
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //         else 
        //         {

        //         }
        //     }
        // }
        public string Name 
        {
            get;
            private set;
        }
        private string name;
        private List<double> grades;

        readonly string category = "Science";
        public const string VERSION ="1.0";
    }
}