using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace CodingClass_7_3_2019
{
    static class FactoryClass
    {
        /// Commented out the List as it only provided temporary storage
        /// and replaced with database that is a permanent storage
        //private static List<StudentAccount> studentaccounts = new List<StudentAccount>();
        //private static List<StudentCourseHistory> studenttransactions = new List<StudentCourseHistory>();
        private static CodingClassContext db = new CodingClassContext();
        /// <summary>
        /// Creates a new student account
        /// </summary>
        /// <param name="firstName">Adds the first name to the account</param>
        /// <param name="lastName">Adds the last name to the account</param>
        /// <param name="difficultyLevel">Level of coding enrolled for</param>
        /// <param name="classType">Online, Inperson or combo type of class</param>
        /// <returns>a newly created student account</returns>
        public static StudentAccount CreateStudentAccount(string firstName, string lastName, string emailID, 
            ClassType classType, ClassDifficultyLevel difficultyLevel)
        {
            var studentacct = new StudentAccount
            {
                StudentFirstName = firstName,
                StudentLastName = lastName,
                StudentDifficultyLevel = difficultyLevel,
                StudentClassType = classType,
                StudentEmailAddress = emailID
            };
          
            db.StudentAccounts.Add(studentacct);
            db.SaveChanges();
            return studentacct;
        }

        //public static IEnumerable<StudentAccount>
        //    GetAccountByEmailAddress(string emailAddress)
        //{
        //    return db.StudentAccounts.Where(a => a.StudentEmailAddress == emailAddress);
        //}

        public static List<StudentAccount>
        GetAccountByEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Email Address","Enter a valid email address.");
            }
            return db.StudentAccounts.Where(a => a.StudentEmailAddress == emailAddress).ToList<StudentAccount>();
        }

        public static void PayFee(int accountNumber, decimal amt)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.Deposit(amt);

            var history = new StudentCourseHistory
            {
                PaymentMadeDateAndTime = DateTime.Now,
                Description = "Tuition payment!",
                Amount = amt
            };
            db.StudentHistory.Add(history);
            db.SaveChanges();
        }
        public static void Withdraw(int accountNumber, decimal amt)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.Withdraw(amt);
        }


        /// <summary>
        /// Refactoring method to get the matching account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        private static StudentAccount FindAccountByAccountNumber(int accountNumber)
        {
            var account = db.StudentAccounts.SingleOrDefault(a => a.StudentAccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Account number not valid!", "Account Number");
            }
           
            return account;
        }
    }
}
