using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Referral.Models;

namespace Referral.Data
{
    public class AccountData
    {
        public static int AccountId { get; private set; }
        public static List<Account> AccountList = new List<Account>()
        {
            new Account() {AccountId = 1, Balance = 125.00M, UserId = 1},
            new Account() {AccountId = 2, Balance = 0.00M, UserId = 2}
        };

        public static List<AccountUser> AccountUserList()
        {
            var query = (from accountData in AccountList
                        join userData in UserData.UserList
                        on accountData.UserId equals userData.UserID
                        select new AccountUser
                        {
                            AccountId = accountData.AccountId,
                            Balance = accountData.Balance,
                            FirstName = userData.FirstName,
                            LastName = userData.LastName
                        }).ToList();

            return query;
        }

        public static void ApplyReferralIncentive(int userId)
        {
            foreach (var account in AccountList.Where(x => x.UserId.Equals(userId)))
            {
                account.Balance += Referrals.ReferralBonus;
                AccountId = account.AccountId;
            }
        }

        public static void ApplyDeposit(int accountId, decimal deposit)
        {
            foreach (var account in AccountList.Where(x => x.AccountId.Equals(accountId)))
            {
                account.Balance += deposit;
            }
        }
    }
}
