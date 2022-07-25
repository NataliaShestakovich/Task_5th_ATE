namespace Task_5th_ATE
{
    public class CallEventArgs
    {
        public Guid ReceivingPhoneNumber { get; }

        public CallEventArgs(Guid receivingPhoneNumber)
        {
            ReceivingPhoneNumber = receivingPhoneNumber;
        }
    }
}
