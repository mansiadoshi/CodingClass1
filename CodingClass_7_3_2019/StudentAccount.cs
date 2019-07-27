using System;
using System.Collections.Generic;
using System.Text;

namespace CodingClass_7_3_2019
{
    enum ClassDifficultyLevel
    {
        Beginner,
        Intermediate,
        Advance
    }
    enum ClassType
    {
        CSharp,
        Python,
        Java
    }

    enum PaymentMethod
    {
        Credit,
        Debit
    }
    /// <summary>
    /// A student account where you can 
    /// enroll or exit from the class
    /// </summary>
    class StudentAccount
    {
        /// <summary>
        /// database (codingclasscontext) does this for you,
        /// so commented out the lastStudentAccountNumber variable
        /// </summary>
        //private static int lastStudentAccountNumber = 0;
        #region Properties
        /// <summary>
        /// Student's First name
        /// </summary>
        public string StudentFirstName { get; set; }
        /// <summary>
        /// Student's Last name
        /// </summary>
        public string StudentLastName { get; set; }
        /// <summary>
        /// Student's DOB
        /// </summary>
        public string StudentDateOfBirth { get; set; }
        /// <summary>
        /// Unique number that identifies the student
        /// </summary>
        public int StudentAccountNumber { get; set; }
        /// <summary>
        /// Student's Email Address
        /// </summary>
        public string StudentEmailAddress { get; set; }

        /// <summary>
        /// Beginner, Intermediate or Advance class
        /// </summary>
        public ClassDifficultyLevel StudentDifficultyLevel { get; set; }
        /// <summary>
        /// Online, Inperson or combo class
        /// </summary>
        public ClassType StudentClassType { get; set; }
        /// <summary>
        /// Total number of classes enrolled for
        /// </summary>
        public int TotalClassesEnrolled { get; set; }

        /// <summary>
        /// Date the class starts
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Duration of the class ends
        /// </summary>
        public string Duration { get; private set; }

        /// <summary>
        /// Amount to be paid for the registered class/classes
        /// </summary>
        public decimal AmountDue { get; private set; }
        #endregion
        /// <summary>
        /// This constructor sets a new Account number,
        /// start date and duration for the class
        /// everytime its object is created
        /// </summary>
        public StudentAccount()
        {
            //StudentAccountNumber = ++lastStudentAccountNumber;
            StartDate = Convert.ToDateTime("6/9/2019");
            Duration = "12 weeks";
            AmountDue = 350;
        }
        #region Methods
        /// <summary>
        /// Displays student details
        /// </summary>
        /// <param name="Typeofclass">Class selected</param>

        /*public void StudentDetails(string firstName, string lastName, string dateOfBirth )
        {
            StudentFirstName = firstName;
            StudentLastName = lastName;
            StudentDateOfBirth = dateOfBirth;
            Console.WriteLine($"FN: {StudentFirstName}, LN: {StudentLastName}, DOB: {StudentDateOfBirth}");
        }*/
        //public void StudentDetails(string StudentFirstName, string StudentLastName, string StudentDateOfBirth)
        //{

        //    Console.WriteLine($"FN: {StudentFirstName}, LN: {StudentLastName}, DOB: {StudentDateOfBirth}");
        //}

        /// <summary>

        /// Pay tuition for the enrolled classes

        /// </summary>

        /// <param name="amount">Amount to be deposited</param>

        /// <returns>Text displaying tuition is paid or not</returns>

        public void Deposit(decimal amount)

        {
            if (amount == AmountDue)
            {
                //Console.WriteLine("Tuition paid in full.");
                return;
            }
            else
            {
                throw new ArgumentException("Amount has to be paid in full!");
            }
            

        }
        public void Withdraw(decimal amount)
        {
            if (AmountDue == amount)
            {
                AmountDue = 0;
                return;
            }
            else
            {
                Console.WriteLine("Withdraw incomplete!");
                return;
            }
        }
        /// <summary>
        /// Associates the selected class type to student's account Number
        /// </summary>
        /// <param name="StudentAccountNumber"></param>
        /// <param name="ClassType"></param>
        public void ClassEnrolled(int StudentAccountNumber, string ClassType)
        {
            
        }
        /* public void ClassEnrolled(string emailID, string typeOfClass)
        {
            StudentEmailAddress = emailID;
            ClassType = typeOfClass;
        }*/
        #endregion
    }
}
