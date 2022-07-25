namespace Task_5th_ATE
{
    public partial class ATE
    {
        delegate void NitifyCallLogger(LogEventArgs callEventArgs);

        public ATE()
        {
            Subscribers = new List<Subscriber>();

            Ports = new List<Port>();

            PhoneNumbers = new List<PhoneNumber>();

            Tariffs = new List<TariffPlanBase>();

            _callLogger = new CallLogger();

            LogEvent += _callLogger.CallLogging;

            //Pre-initialize available ports, phone numbers and tariff plans for ATE operation
            InitializePhoneNumberCollection();
            InitializePortCollection();
            InitializeTariffPlans();
        }

        event NitifyCallLogger LogEvent;

        private readonly CallLogger _callLogger;

        private List<PhoneNumber> PhoneNumbers { get; set; }

        private List<Port> Ports { get; set; }

        private List<TariffPlanBase> Tariffs { get; set; }

        public List<Subscriber> Subscribers { get; set; }

        public void CreateSubscriber(string firstName, string secondName, string lastName)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) || string.IsNullOrEmpty(lastName))
                {
                    throw new ArgumentNullException("Incorrect personal data.");
                }

                var idSubscriber = Guid.NewGuid();
                var contract = new Contract();
                var tariff = Tariffs[new Random().Next(0, Tariffs.Count - 1)];
                var phoneNumber = PhoneNumbers.Where(p => p.Free == true).FirstOrDefault();
                var port = Ports.Where(p => p.Free == true).FirstOrDefault();

                phoneNumber!.Free = false;
                port!.Free = false;
                
                Subscriber subscriber = new Subscriber(
                    idSubscriber,
                    firstName,
                    secondName,
                    lastName,
                    contract,
                    phoneNumber,
                    port,
                    tariff);

                subscriber.Notify += Connect;

                Subscribers.Add(subscriber);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect personal data.\n");
            }
        }

        public void Connect(Subscriber callingSubscriber, CallEventArgs callEventArgs)
        {
            _ = callingSubscriber ?? throw new ArgumentNullException("CallingSubscriber was null.");
            _ = callEventArgs ?? throw new ArgumentNullException("CallEventArgs was null.");

            var receivingSubscriber = Subscribers.Where(c => c.PhoneNumber.Number == callEventArgs.ReceivingPhoneNumber).FirstOrDefault();

            if (receivingSubscriber == null)
            {
                Console.WriteLine("Wrong number\n");
            }
            else
            {
                var (date, callDuration) = Commutator.Connect(callingSubscriber.Port, receivingSubscriber.Port);

                if (callDuration > 0)
                {
                    TarifyCall(callingSubscriber, callDuration);

                    var callDetails = new CallDetails()
                    {
                        Date = date,
                        Number = receivingSubscriber.PhoneNumber.Number,
                        Cost = callDuration * callingSubscriber.TariffPlan.PriceOfOneMinute,
                        CallDuration = callDuration

                    };

                    callingSubscriber.CallLogs.Add(callDetails);

                    LogEvent?.Invoke( new LogEventArgs(
                        callingSubscriber.PhoneNumber.Number,
                        callDetails));
                }
            }
        }
        
        private static void TarifyCall(Subscriber subscriber, int conversationDuration)
        {
            decimal oneMinuteCost = subscriber.TariffPlan.PriceOfOneMinute;

            subscriber.AccountBalance = -oneMinuteCost * conversationDuration;
        }
    }
}
