using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

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
                Console.WriteLine("2. Pay Fee");
                Console.WriteLine("3. Print Student Details");

                /// Reads the choice the user entered
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for stopping by!");
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Enter Email Address: ");
                            var emailAddress = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(emailAddress))
                            {
                                throw new ArgumentException("Email address not valid");
                            }
                            Console.Write("Enter First Name: ");
                            var firstName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(firstName))
                            {
                                throw new ArgumentException("Enter a valid First name");
                            }
                            Console.Write("Enter Last Name: ");
                            var lastName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(lastName))
                            {
                                throw new ArgumentException("Enter a valid Last name");
                            }

                            Console.WriteLine("Class types: ");
                            var classTypes = Enum.GetNames(typeof(ClassType));
                            for (var j = 0; j < classTypes.Length; j++)
                            {
                                Console.WriteLine($"{j}.{classTypes[j]}");
                            }
                            Console.WriteLine("Select class type: ");
                            var classType = Convert.ToInt32(Console.ReadLine());
                            switch (classType)
                            {
                                case 0:
                                    Console.WriteLine("Class selected: CSharp");
                                    break;
                                case 1:
                                    Console.WriteLine("Class selected: Python");
                                    break;
                                case 2:
                                    Console.WriteLine("Class selected: Java");
                                    break;
                                default:
                                    throw new InvalidEnumArgumentException();
                            }

                            Console.WriteLine("Difficulty levels: ");
                            var difficultyLevels = Enum.GetNames(typeof(ClassDifficultyLevel));
                            for (var i = 0; i < difficultyLevels.Length; i++)
                            {
                                Console.WriteLine($"{i}.{difficultyLevels[i]}");
                            }
                            Console.WriteLine("Select difficulty level: ");
                            var difficultyLevel = Convert.ToInt32(Console.ReadLine());
                            switch (difficultyLevel)
                            {
                                case 0:
                                    Console.WriteLine("Level: Beginner");
                                    break;
                                case 1:
                                    Console.WriteLine("Level: Intermediate");
                                    break;
                                case 2:
                                    Console.WriteLine("Level: Advance");
                                    break;
                                default:
                                    throw new InvalidEnumArgumentException();
                            }
                            var account = FactoryClass.CreateStudentAccount(firstName, lastName, emailAddress, (ClassType)classType, (ClassDifficultyLevel)difficultyLevel);
                            Console.WriteLine($"AN: {account.StudentAccountNumber}, ClassType: {account.StudentClassType}, Level: {account.StudentDifficultyLevel}, " +
                                $" Email:{account.StudentEmailAddress}, SD:{account.StartDate}, Span:{account.Duration}");
                        }
                        catch (InvalidEnumArgumentException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                     
                        break;
                    
                    case "2":

                        try
                        {
                            PrintAllAccounts();
                            // Console.Write("Pay $350 ");
                            decimal amount = 350;

                            Console.WriteLine("Select payment method: ");
                            var paymentMethods = Enum.GetNames(typeof(PaymentMethod));
                            for (var k = 0; k < paymentMethods.Length; k++)
                            {
                                Console.WriteLine($"{k}.{paymentMethods[k]}");
                            }
                            var paymentMethod = Convert.ToInt32(Console.ReadLine());
                            switch (paymentMethod)
                            {
                                case 0:
                                    Console.WriteLine("Payment method selected is Credit");
                                    break;
                                case 1:
                                    Console.WriteLine("Payment method selected is Debit");
                                    break;
                                default:
                                    throw new InvalidEnumArgumentException();
                            }
                            //if (paymentMethod >= paymentMethods.Length)
                            //{
                            //    throw new ArgumentException("Selected option does not exist. Select from the given options.");
                            //}
                            Console.Write("Enter account number:");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());

                            //Console.WriteLine("Payment Methods: ");
                            //var paymentMethods = Enum.GetNames(typeof(PaymentMethod));
                            //for (var k = 0; k < paymentMethods.Length; k++)
                            //{
                            //    Console.WriteLine($"{k}.{paymentMethods[k]}");
                            //}
                            //Console.WriteLine("Select payment type: ");
                            //var paymentMethod = Convert.ToInt32(Console.ReadLine());
                            //Console.Write("Enter account number:");
                            //var accountNumber = Convert.ToInt32(Console.ReadLine());

                            FactoryClass.PayFee(accountNumber, amount);
                        }

                        catch (InvalidEnumArgumentException)
                        {
                            Console.WriteLine("Option number does not exist. Select from available options.");
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case "3":
                        try
                        {
                            PrintAllAccounts();
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception)
                        {
                        }

                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Refactoring to reuse PrintAllAccounts method across different case statements
        /// </summary>
        private static void PrintAllAccounts()
        {
           
                Console.Write("Enter Email Address:");
                var emailAddress = Console.ReadLine();
                
                var accounts = FactoryClass.GetAccountByEmailAddress(emailAddress);
                foreach (var acct in accounts)
                {
                    Console.WriteLine($"AN: {acct.StudentAccountNumber}, ClassType: {acct.StudentClassType}, Level: {acct.StudentDifficultyLevel}, " +
                                                $" Email:{acct.StudentEmailAddress}, SD:{acct.StartDate}, Span:{acct.Duration}");
                }
            
           
        }
    }
}
