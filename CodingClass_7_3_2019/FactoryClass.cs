using System;
using System.Collections.Generic;
using System.Text;

namespace CodingClass_7_3_2019
{
    static class FactoryClass
    {
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
                //StudentDifficultyLevel = difficultyLevel,
                //StudentClassType = classType,
                StudentEmailAddress = emailID
            };
            return studentacct;
        }
    }
}
