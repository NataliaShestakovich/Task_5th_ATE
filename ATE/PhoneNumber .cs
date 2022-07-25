namespace Task_5th_ATE
{
    public class PhoneNumber
    {
        public PhoneNumber(Guid number)
        {
            Number = number;

            Free = true;
        }
        public Guid Number { get; }

        public bool Free { get; set; }
    }
}
