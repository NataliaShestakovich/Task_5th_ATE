namespace Task_5th_ATE
{
    public class CallDetails
    {
        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public Guid Number { get; set; }

        public double CallDuration { get; set; }

        public override string ToString()
        {
            return (String.Format("Date:{0}, Number:{1}, CallDuration:{2} minutes, Cost:{3} ",
                   Date, Number, CallDuration, Cost));
        }
    }
}
