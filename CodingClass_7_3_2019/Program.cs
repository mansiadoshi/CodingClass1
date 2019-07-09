using System;

namespace CodingClass_7_3_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OldCode using Object Initialization and inline formatting
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
            #endregion
            Console.WriteLine("*****Welcome to Coding Class*****");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create Student Account");
                Console.WriteLine("2. Select difficulty level");
                Console.WriteLine("3. Withdraw from the class");
                Console.WriteLine("4. Print Student Details");

                /// Reads the choice the user entered
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for stopping by!");
                        return;
                    case "1":
                        Console.Write("Enter Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Enter First Name: ");
                        var firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        var lastName = Console.ReadLine();
        
                        Console.WriteLine("Class types: ");
                        var classTypes = Enum.GetNames(typeof(ClassType));
                        for (var j = 0; j < classTypes.Length; j++)
                        {
                            Console.WriteLine($"{j}.{classTypes[j]}");
                        }
                        Console.WriteLine("Select class type: ");
                        var classType = Convert.ToInt32(Console.ReadLine());

                        //I am not sure how to ask the user to enter difficulty level
                        Console.WriteLine("Difficulty levels: ");
                        var difficultyLevels = Enum.GetNames(typeof(ClassDifficultyLevel));
                        for (var i = 0; i < difficultyLevels.Length; i++)
                        {
                            Console.WriteLine($"{i}.{difficultyLevels[i]}");
                        }
                        Console.WriteLine("Select difficulty level: ");
                        var difficultyLevel = Convert.ToInt32(Console.ReadLine());

                        var account = FactoryClass.CreateStudentAccount(firstName, lastName, emailAddress,(ClassType)classType, (ClassDifficultyLevel)difficultyLevel);
                        Console.WriteLine($"AN: {account.StudentAccountNumber}, ClassType: {account.StudentClassType}, Level: {account.StudentDifficultyLevel}, " +
                            $" Email:{account.StudentEmailAddress}, SD:{account.StartDate}, Span:{account.Duration}");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
