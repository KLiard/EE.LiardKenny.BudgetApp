using SQLite;

namespace EE.LiardKenny.BudgetApp.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull, MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [NotNull]
        public bool IsIncome { get; set; }
    }
}
