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
    /// <summary>
    /// A student account where you can 
    /// enroll or exit from the class
    /// </summary>
    class StudentAccount
    {
        private static int lastStudentAccountNumber = 0;
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
        public int StudentAccountNumber { get; private set; }
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
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Duration of the class ends
        /// </summary>
        public string Duration { get; private set; }

        /// <summary>
        /// Amount to be paid for the registered class/classes
        /// </summary>
        public double AmountDue { get; set; }
        #endregion
        /// <summary>
        /// This constructor sets a new Account number,
        /// start date and duration for the class
        /// everytime its object is created
        /// </summary>
        public StudentAccount()
        {
            StudentAccountNumber = ++lastStudentAccountNumber;
            StartDate = Convert.ToDateTime("6/9/2019");
            Duration = "12 weeks";
            AmountDue = 350.0;
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
        public void StudentDetails(string StudentFirstName, string StudentLastName, string StudentDateOfBirth)
        {
            
            Console.WriteLine($"FN: {StudentFirstName}, LN: {StudentLastName}, DOB: {StudentDateOfBirth}");
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
