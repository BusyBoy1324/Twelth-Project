namespace TwelfthTask.Models
{
    public class DailyReport
    {
        public DateTime Date { get; set; }
        public int TotalIncome { get; set; }
        public int TotalExpenses { get; set; }
        public List<FinancialOperation> Operations { get; set; }

        public DailyReport(DateTime date, int income, int expenses, List<FinancialOperation> financialOperations)
        {
            Date = date;
            TotalIncome = income;
            TotalExpenses = expenses;
            Operations = financialOperations;
        }
    }
}
