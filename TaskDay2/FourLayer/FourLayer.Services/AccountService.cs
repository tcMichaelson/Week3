using AutoMapper;
using FourLayer.Domain.Models;
using FourLayer.Infrastructure.Models;
using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Services {
    /* Bulk of the work goes in services. */
    /* User actions. */

    public class AccountService {
        IRepository _repo;

        //Transfer money between accounts
        //Get account balance
        //open an account
        //close an account

        public AccountService(IRepository repo) {
            _repo = repo;
        }

        private string GenerateAccountNumber() {
            /* 10 digits between 1000000000 and 9999999999 */
            Random rand = new Random();
            long accountNumber = (long)(rand.NextDouble() * 9000000000L + 1000000000L);
            return accountNumber.ToString();
        }

        public AccountDTO OpenAccount(string username, string accountType, decimal startingBalance) {
            Account newAccount = new Account {
                AccountType = accountType,
                Balance = startingBalance,
                Name = username,
                AccountNumber = GenerateAccountNumber()
            };
            _repo.Add<Account>(newAccount);
            _repo.SaveChanges();

            return Mapper.Map<AccountDTO>(newAccount);
        }

        public decimal GetAccountBalance(int id) {
            Account account = _repo.Find<Account>(id);
            return account.Balance;
        }

        public void CloseAccount(int id) {
            _repo.Delete<Account>(id);
            _repo.SaveChanges();
        }

        public IList <AccountDTO> ListAccounts() {
            var dtoList = new List<AccountDTO>();
            foreach (Account a in _repo.Query<Account>().ToList()){
                dtoList.Add(Mapper.Map<AccountDTO>(a));
            }
            return dtoList;
        }

        public IList<AccountDTO> ListAccounts(string username) {
            var dtoList = new List<AccountDTO>();
            foreach (Account a in (from account in _repo.Query<Account>() where account.Name == username select account).ToList()) {
                dtoList.Add(Mapper.Map<AccountDTO>(a));
            }
            return dtoList;
        }

        public bool TransferMoney(string accountNumberFrom, string accountNumberTo, decimal dollarAmount) {
            Account accountDeduct = (from a in _repo.Query<Account>() where a.AccountNumber == accountNumberFrom select a).FirstOrDefault();
            Account accountAdd = (from a in _repo.Query<Account>() where a.AccountNumber == accountNumberTo select a).FirstOrDefault();
            if (accountDeduct == null || accountDeduct.Balance < dollarAmount) {
                return false;
            } else {
                accountDeduct.Balance -= dollarAmount;
                accountAdd.Balance += dollarAmount;
                _repo.SaveChanges();
                return true;
            }
        }

    }
}
