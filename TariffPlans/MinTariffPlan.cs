namespace Task_5th_ATE
{
    internal class MinTariffPlan : TariffPlanBase
    {
        public override string Name { get; } = "MinTarif";

        public override decimal PriceOfOneMinute { get; } = 0.28m;

        public override decimal SubscriptionFee { get; } = 10m;
    }
}
