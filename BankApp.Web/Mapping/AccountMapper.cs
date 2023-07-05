using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class AccountMapper: IAccountMapper
    {
        public Account MapToAccount(AccountCreateModel accountCreateModel)
        {
            return new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                UserId = accountCreateModel.UserId,
                Balance = accountCreateModel.Balance,

            };
        }
    }
}
