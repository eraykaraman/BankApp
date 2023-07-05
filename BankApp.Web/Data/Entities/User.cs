﻿namespace BankApp.Web.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
