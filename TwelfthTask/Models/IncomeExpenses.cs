﻿namespace TwelfthTask.Models
{
    public class IncomeExpenses
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsIncome { get; set; } = true;
    }
}
