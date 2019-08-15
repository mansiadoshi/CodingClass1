using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingClass_7_3_2019;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using System.Data.Odbc;
using Microsoft.AspNetCore.Http;

namespace CodingClassUI.Controllers
{
    [Authorize]
    public class StudentAccountsController : Controller
    {
        // GET: StudentAccounts
        public async Task<IActionResult> Index()
        {
            return View(FactoryClass.GetAccountByEmailAddress(HttpContext.User.Identity.Name));
        }

        // GET: StudentAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccount = FactoryClass.FindAccountByAccountNumber(id.Value);
            if (studentAccount == null)
            {
                return NotFound();
            }

            return View(studentAccount);
        }

        // GET: StudentAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("StudentFirstName,StudentLastName,StudentDateOfBirth,StudentEmailAddress,StudentDifficultyLevel,StudentClassType")]
        StudentAccount studentAccount)
        {
            if (ModelState.IsValid)
            {
                FactoryClass.CreateStudentAccount(studentAccount.StudentFirstName, studentAccount.StudentLastName,
                    studentAccount.StudentEmailAddress, studentAccount.StudentClassType, studentAccount.StudentDifficultyLevel);
                return RedirectToAction(nameof(Index));
            }
            return View(studentAccount);
        }

        // GET: StudentAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccount = FactoryClass.FindAccountByAccountNumber(id.Value);
            if (studentAccount == null)
            {
                return NotFound();
            }
            return View(studentAccount);
        }

        // POST: StudentAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("StudentFirstName,StudentLastName,StudentAccountNumber,StudentEmailAddress,StudentDifficultyLevel,StudentClassType")]
        StudentAccount studentAccount)
        {
            if (id != studentAccount.StudentAccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            { 
                try
                {
                    FactoryClass.EditStudentAccount(studentAccount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAccountExists(studentAccount.StudentAccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentAccount);
        }

        public IActionResult PayFee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = FactoryClass.FindAccountByAccountNumber(id.Value);
            return View(account);
        }

        //[HttpPost]
        //public  IActionResult Deposit(int id,
        //    [Bind("StudentAccountNumber, AmountDue")]StudentAccount studentAccount)
        //{
        //    if (id != studentAccount.StudentAccountNumber)
        //    {
        //        return NotFound();
        //    }
        //    var accountNumber = studentAccount.StudentAccountNumber;
        //    var amount = studentAccount.AmountDue;
        //    FactoryClass.PayFee(accountNumber, amount);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]

        public IActionResult PayFee(IFormCollection data, [Bind("StudentAccountNumber")]StudentAccount studentAccount)
        //public IActionResult Deposit(IFormCollection data)
        {

            var accountNumber = studentAccount.StudentAccountNumber;

            var amount = Convert.ToDecimal(data["Amount"]);

            FactoryClass.PayFee(accountNumber, amount);

            return RedirectToAction(nameof(Index));

        }

        // GET: StudentAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccount = FactoryClass.FindAccountByAccountNumber(id.Value);
            if (studentAccount == null)
            {
                return NotFound();
            }

            return View(studentAccount);
        }

        // POST: StudentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            FactoryClass.DeleteStudentAccount(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAccountExists(int id)
        {
            return (FactoryClass.FindAccountByAccountNumber(id) )!= null ? true : false;
        }
    }
}
