using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingJan28
{
    abstract class Account
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Balance { get; set; }
        public Account(int id, string name, double balance)
        {
            Id = id; Name = name; Balance = balance;
        }
        public abstract void Withdraw(double amount);
    }
    class Savings : Account
    {
        public Savings(int id, string name, double balance) : base(id, name, balance)
        {
        }
        public override void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
    class Current : Account
    {
        public Current(int id, string name, double balance) : base(id, name, balance)
        {
        }
        public override void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
    internal class Pattern
    {
    }
}
