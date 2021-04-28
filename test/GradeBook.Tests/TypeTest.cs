using System;
using Xunit;

namespace GradeBook.Tests
{
    public class Person
    {

    }
    public struct Point
    {

    }
    public class TypeTests
    {
        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Scott";
            name = MakeUpperCase(name);

            Assert.Equal("SCOTT", name);
        }

        // private void MakeUpperCase(string name)
        // {
        //     name.ToUpper();
        // }
        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void ValueTypeCanPassByReference()
        {
            // arrange
            var x = GetInt();
            // act
            SetInt(ref x);
            // assert
            Assert.Equal(42, 42);

        }
        private void SetInt(ref int z)
        {
           z = 42;
        }
        [Fact]
        public void ValueTypeAsloPassByValue()
        {
            // arrange
            var x = GetInt();
            // act
            SetInt(x);

            // assert
            Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
           z = 42;
        }

        private int GetInt()
        {
           return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {

            // arrange
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New Name");
            //GetBookSetName(out book1, "New Name");
            
            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        void GetBookSetName(ref Book book, string name)
        //void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {

            // arrange
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");
            
            // act

            // assert
            Assert.Equal("Book1", book1.Name);
        }

        void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {

            // arrange
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");
            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        void SetName(Book book, string name)
        {
           book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {

            // arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            // act

            // assert
            // Assert.Equal("Book1", book1.Name);
            // Assert.Equal("Book2", book2.Name);
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {

            // arrange
            var book1 = GetBook("Book1");
            var book2 = book1;

            // act

            // assert
            // Assert.Equal("Book1", book1.Name);
            // Assert.Equal("Book1", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
