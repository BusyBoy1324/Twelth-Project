using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class LongTermReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }
        public List<FinancialOperation> Operations { get; set; }

        public LongTermReport(DateTime startDate, DateTime endDate, int income, int expenses, List<FinancialOperation> operations)
        {
            StartDate = startDate;
            EndDate = endDate;
            Income = income;
            Expenses = expenses;
            Operations = operations;
        }

        public LongTermReport()
        {
            
        }
    }
}
