namespace TwelfthTask.Models
{
    public class FinancialOperation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Price { get; set; } = 0;
        public int IncomeExpensesTypeId { get; set; }
        public string IncomeExpensesName { get; set; } = String.Empty;
    }
}
