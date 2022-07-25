namespace Task_5th_ATE
{
    public abstract class TariffPlanBase
    {
        public abstract string Name { get; }

        public abstract decimal PriceOfOneMinute { get;}

        public abstract decimal SubscriptionFee { get; }
    }
}
