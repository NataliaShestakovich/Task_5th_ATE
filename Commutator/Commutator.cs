namespace Task_5th_ATE
{
    public static class Commutator
    {
        public static (DateTime date,int callDuration) Connect(Port callingPort, Port receivingPort)
        {
            _ = callingPort ?? throw new ArgumentNullException("CallingPort was null");
            _ = receivingPort ?? throw new ArgumentNullException("ReceivingPort was null");

            var date = DateTime.Now;

            if (callingPort.PortStatus == StatusOfPort.Free)
            {
                callingPort.PortStatus = StatusOfPort.Busy;

                if (receivingPort.PortStatus == StatusOfPort.Free)
                {
                    receivingPort.PortStatus = StatusOfPort.Busy;

                    Console.WriteLine("Call started");
                    
                    int callDuration = new Random().Next(1, 60);

                    Console.WriteLine("Call finishted\n");

                    callingPort.PortStatus = StatusOfPort.Free;
                    receivingPort.PortStatus = StatusOfPort.Free;

                    return (date,callDuration);
                }
                else
                {
                    switch (callingPort.PortStatus)
                    {
                        case StatusOfPort.Busy:
                            Console.WriteLine("The subscriber is busy\n");
                            break;
                        case StatusOfPort.Off:
                            Console.WriteLine("The subscriber is unavailable\n");
                            break;
                        case StatusOfPort.Blocked:
                            Console.WriteLine("The subscriber is blocked\n");
                            break;
                        default:
                            break;

                    }
                    return (date,0);
                }
            }
            else
            {
                Console.WriteLine("Call cannot be made\n");

                return (date, 0);
            }
        }
    }
}
