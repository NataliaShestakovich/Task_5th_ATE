namespace Task_5th_ATE
{
    public delegate void CallHendler(Subscriber subscriber,CallEventArgs callEventArgs);

    public class Subscriber
    {
        public event CallHendler Notify;

        public Subscriber(
            Guid idSubscriber,
            string firstName,
            string secondName,
            string lastName,
            Contract contract,
            PhoneNumber phoneNumber,
            Port portForConnection,
            TariffPlanBase tariffPlanBase)
        {
            Id = idSubscriber;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Contract = contract;
            PhoneNumber = phoneNumber;
            Port = portForConnection;
            TariffPlan = tariffPlanBase;

            DateOfLastChangeTariffPlan = Contract.ContractDate;
            CanChangeTariffPlan = false;
            AccountBalance = 0;
            CallLogs = new List<CallDetails>();
        }

        public Guid Id { get; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? LastName { get; set; }

        public Contract? Contract { get; }

        public TariffPlanBase TariffPlan { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public Port Port { get; set; }

        public DateTime DateOfLastChangeTariffPlan { get; set; }

        public bool CanChangeTariffPlan { get; set; }

        public decimal AccountBalance { get; set; }

        public List<CallDetails> CallLogs { get; set; }

        public void Call(Guid phoneNumber)
        {
            Notify?.Invoke(this, new CallEventArgs(phoneNumber));
        }

        public void ChangeStatusPort(bool activation)
        {

            if (!activation && Port.PortStatus == StatusOfPort.Free)
            {
                Port.PortStatus = StatusOfPort.Off;
                Console.WriteLine("Port was diactiveted.");
            }
            if (activation && Port.PortStatus == StatusOfPort.Off)
            {
                Port.PortStatus = StatusOfPort.Off;
                Console.WriteLine("Port was activeted.");
            }
        }

        public void ChangeTariffPlan(TariffPlanBase tariffPlan)
        {
            if (DateTime.Now.Month != DateOfLastChangeTariffPlan.Month)
            {
                TariffPlan = tariffPlan;
                Console.WriteLine("Tariff plan was changed.");
            }
            else
            {
                Console.WriteLine("Tariff plan can not be changed. You can do it on the next month.");
            }

        }

        public void PrintSortedCallLogs(SortBy sortBy = SortBy.Date)
        {
            List<CallDetails> callLogs = new List<CallDetails>();

            switch (sortBy)
            {
                case SortBy.Cost:
                    callLogs = CallLogs.OrderBy(c => c.Cost).ToList();
                    break;
                case SortBy.Number:
                    callLogs = CallLogs.OrderBy(c => c.Number).ToList();
                    break;
                case SortBy.Date:
                    callLogs = CallLogs.OrderBy(c => c.Date).ToList();
                    break;
                default:
                    break;
            }

            foreach (var item in callLogs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
