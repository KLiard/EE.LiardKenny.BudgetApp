using EE.LiardKenny.BudgetApp.Resources;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace EE.LiardKenny.BudgetApp.Models
{
    public class CashFlow
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public DateTime DateOfTransaction { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [OneToOne(nameof(CategoryId), CascadeOperations = CascadeOperation.CascadeRead)]
        public Category Category { get; set; }

        [NotNull]
        public bool IsIncome { get; set; }

        [NotNull]
        public decimal Amount { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Ignore]
        public string Image { get; set; } // probably will be another type

        [Ignore]
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
