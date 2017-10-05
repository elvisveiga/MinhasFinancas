using System;

namespace MinhasFinancas.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }

        public DateTime Due_Date { get; set; }
        public DateTime Record_Date { get; set; }


        public int Record_Type { get; set; }
        public double Value { get; set; }
    }
}