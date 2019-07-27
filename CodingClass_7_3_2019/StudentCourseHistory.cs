using System;
using System.Collections.Generic;
using System.Text;

namespace CodingClass_7_3_2019
{
    enum PaymentType
    {
        Credit,
        Debit
    }
    class StudentCourseHistory
    {
        public int CourseHistoryID { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
        public PaymentType PaymentType { get; set; }
        public string ClassesEnrolledFor { get; set; }

        public int AccountNumber { get; set; }

        public DateTime PaymentMadeDateAndTime { get; set; }

        /// <summary>
        /// virtual means not physically present but a relationship.
        /// This declaration officially means declaring a relationship to StudentAccount table,
        /// stating that a course history is related to one account.
        /// </summary>
        public virtual StudentAccount account { get; set; }
    }
}
