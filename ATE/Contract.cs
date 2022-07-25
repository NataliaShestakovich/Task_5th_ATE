namespace Task_5th_ATE
{
    public class Contract
    {
        private static int ContractsNumber = 0;

        public Contract()
        {
            ContractsNumber++;

            ContractDate = DateTime.Now;

            Number = $"{ContractDate:dd/mm/yyyy}-{ContractsNumber}";
        }
        
        public DateTime ContractDate { get; set; }

        public string? Number { get; set; }
    }
}
