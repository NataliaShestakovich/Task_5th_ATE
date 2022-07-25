namespace Task_5th_ATE
{
    public class MediumTariffPlan : TariffPlanBase
    {
        public override string Name { get; } = "MediumTarif";

        public override decimal PriceOfOneMinute { get; } = 0.25m;

        public override decimal SubscriptionFee { get; } = 15m;
    }
}
