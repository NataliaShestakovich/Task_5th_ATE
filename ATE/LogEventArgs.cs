namespace Task_5th_ATE
{
    public  class LogEventArgs
    {
        public LogEventArgs(Guid callingSubscriber, CallDetails callDetails)
        {
            CallingNumber = callingSubscriber;

            CallDetails = callDetails;
        }

        public Guid CallingNumber { get; }

        public CallDetails CallDetails { get; }
    }
}
