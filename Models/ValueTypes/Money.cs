using System;
using TestWeb1.Models.Enums;

namespace TestWeb1.Models.ValueTypes
{
    public class Money
    {
        public Money() : this(Currency.EUR, 0.00m){}

        public Money(Currency currency, decimal amount){
            Amount = amount;
            Currency = currency;
        }

        private decimal amount = 0;

        public decimal Amount{
            get{
                return amount;
            }
            set{
                if(value<0){
                    throw new System.InvalidOperationException("The amount cannot be negative");
                }
                amount = value;
            }
        }

        public Currency Currency {get;set;}

        public override bool Equals(object obj){
            var money = obj as Money;
            return money != null &&
                Amount == money.Amount &&
                Currency == money.Currency;
        }

        public override int GetHashCode(){
            return HashCode.Combine(Amount,Currency);
        }
        public override string ToString(){
            return $"{Currency} {Amount:#.00}";
        }
    }
}