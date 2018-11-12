using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayneEnterprises.OnlineBanking.WebApi.Models;

namespace WayneEnterprises.OnlineBanking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static string[] TransactionDescriptions = {
            "Bank charges",
            "Cheque card purchase",
            "Outstanding card authorisation",
            "Autobank cash withdrawal at",
            "Ib payment",
            "Ib transfer",
            "Account payment",
            "Service agreement",
            "Overdraft service fee",
            "Pre-paid payment",
            "Electronic trf - credit card",
            "Medical aid contribution",
            "Insurance premium",
            "Loan repayment"
        };

        [HttpGet("[action]")]
        [Authorize("enrolled:personal_account")]
        public ActionResult<AccountModel> Personal()
        {
            var transactions = GetTransactionsDesc(25000);

            var account = new AccountModel
            {
                Name = "Cheque Account",
                Number = "061-282-369",
                Transactions = transactions
            };

            return Ok(account);
        }

        [HttpGet("[action]")]
        [Authorize("enrolled:personal_account")]
        public ActionResult<AccountModel> Savings()
        {
            var transactions = GetTransactionsAsc(45000);

            var account = new AccountModel
            {
                Name = "Savings Account",
                Number = "055-637-813",
                Transactions = transactions
            };

            return Ok(account);
        }

        [HttpGet("[action]")]
        [Authorize("enrolled:business_account")]
        public ActionResult<AccountModel> Business()
        {
            var transactions = GetTransactionsAsc(112000);

            var account = new AccountModel
            {
                Name = "Business Cheque Account",
                Number = "088-517-012",
                Transactions = transactions
            };

            return Ok(account);
        }

        [HttpGet("[action]")]
        [Authorize("enrolled:credit_card")]
        public ActionResult<AccountModel> Credit()
        {
            var transactions = GetTransactionsDesc(100000);

            var account = new AccountModel
            {
                Name = "Platinum Credit Card",
                Number = "777-654-131",
                Transactions = transactions
            };

            return Ok(account);
        }

        private static List<TransactionModel> GetTransactionsDesc(int balance)
        {
            var random = new Random();
            var transactions = Enumerable.Range(1, 20).Select(index => new TransactionModel
            {
                Date = DateTime.Now.AddDays(index).ToString("d"),
                Description = TransactionDescriptions[random.Next(TransactionDescriptions.Length)],
                Amount = random.Next(-1000, -100)
            }).ToList();

            foreach (var item in transactions)
            {
                balance += item.Amount;
                item.Balance = balance;
            }

            return transactions;
        }

        private static IList<TransactionModel> GetTransactionsAsc(int balance)
        {
            var random = new Random();
            var transactions = Enumerable.Range(1, 20).Select(index => new TransactionModel
            {
                Date = DateTime.Now.AddDays(index).ToString("d"),
                Description = TransactionDescriptions[random.Next(TransactionDescriptions.Length)],
                Amount = random.Next(1000, 10000)
            }).ToList();

            foreach (var item in transactions)
            {
                balance += item.Amount;
                item.Balance = balance;
            }

            return transactions;
        }
    }
}
