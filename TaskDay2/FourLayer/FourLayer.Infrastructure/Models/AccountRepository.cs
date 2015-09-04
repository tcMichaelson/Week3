using FourLayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Infrastructure.Models {
    class AccountRepository {

        DataContext _db;
        public AccountRepository(DataContext db) {
            _db = db;
        }

        public void AdjustBalance(Account account, decimal dollarAmount) {

        }
    }
}
