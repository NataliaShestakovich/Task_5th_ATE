namespace Task_5th_ATE
{
    public class Port
    {
        public Port(Guid number)
        {
            Number = number;

            PortStatus = StatusOfPort.Free;

            Free = true;
        }
        
        public Guid Number { get; set; }

        public StatusOfPort PortStatus { get; set; }

        public bool Free { get; set; }
    }
}
