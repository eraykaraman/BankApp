﻿namespace BankApp.Web.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }

    public class AccountListModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserId { get; set; }
    }
}
