using System;

namespace CodingClass_7_3_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Object Initialization when creating the instance of an object
            //var MyStudentAccount = new StudentAccount()
            //{
            //    StudentFirstName = "FN",
            //    StudentLastName = "LN",
            //    StudentDateOfBirth = Convert.ToString("11/01/1995"),
            //    StudentEmailAddress = "testID_1@test.com",
            //    StudentClassType="Online",
            //    StudentDifficultyLevel= "Intermediate"
            //};
            //Console.WriteLine($"FirstName: {MyStudentAccount.StudentFirstName},LastName: {MyStudentAccount.StudentLastName}, EmailID: {MyStudentAccount.StudentEmailAddress}, StudentID: {MyStudentAccount.StudentAccountNumber}, Start: {MyStudentAccount.StartDate}, Duration: {MyStudentAccount.Duration}");
            //var MyStudentAccount1 = new StudentAccount()
            //{
            //    StudentFirstName = "Tom",
            //    StudentLastName = "Harry",
            //    StudentDateOfBirth = Convert.ToString("11/01/1995"),
            //    StudentEmailAddress = "testID_2@test.com",
            //    StudentClassType = "Online"
            //    StudentDifficultyLevel = "Beginner"
            //};
            //Console.WriteLine($"FirstName: {MyStudentAccount1.StudentFirstName},LastName: {MyStudentAccount1.StudentLastName}, EmailID: {MyStudentAccount1.StudentEmailAddress}, StudentID: {MyStudentAccount1.StudentAccountNumber}, Start: {MyStudentAccount1.StartDate}, Duration: {MyStudentAccount1.Duration}");
            Console.WriteLine("*****Welcome to Coding Class*****");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Student Account");
            Console.WriteLine("2. Select difficulty level");
            Console.WriteLine("3. Withdraw from the class");
            Console.WriteLine("4. Print Student Details");

        }
    }
}
