using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        //[Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // // arrange
            // var book = new Book("");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);

            // // act

            // // assert
            // //Assert.Equal(acutal, expected);

            // arrange
            var book = new Book("Scott's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.3);
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);            
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
