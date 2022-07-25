namespace Task_5th_ATE
{
    public class MaxTariffPlan : TariffPlanBase
    {
        public override string Name { get; } = "MaxTarif";

        public override decimal PriceOfOneMinute { get; } = 0.2m;

        public override decimal SubscriptionFee { get; } = 20m;
    }
}
