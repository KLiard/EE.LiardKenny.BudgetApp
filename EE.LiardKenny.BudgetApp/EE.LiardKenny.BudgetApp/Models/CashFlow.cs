using EE.LiardKenny.BudgetApp.Resources;
using System;

namespace EE.LiardKenny.BudgetApp.Models
{
    public class CashFlow
    {
        public int ID { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public Category Category { get; set; }

        public bool IsIncome { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string Image { get; set; } // probably will be another type

        public string CashFlowDirection { get { return DisplayCashFlowDirection(); } }

        public decimal IsAllowedForSum(bool isIncome)
        {
            if (IsIncome == isIncome)
            {
                return Amount;
            }
            return 0m;
        }

        private string DisplayCashFlowDirection()
        {
            if (IsIncome)
            {
                return Texts.Incoming;
            }
            return Texts.Outcoming;
        }
    }
}
