namespace Task_5th_ATE
{
    public partial class ATE
    {
        private void InitializePhoneNumberCollection()
        {
            PhoneNumbers = new List<PhoneNumber>();

            for (int i = 0; i < 20; i++)
            {
                var phoneNumber = new PhoneNumber(Guid.NewGuid());

                PhoneNumbers.Add(phoneNumber);
            }
        }

        private void InitializePortCollection()
        {
            for (int i = 0; i < 20; i++)
            {
                var port = new Port(Guid.NewGuid());

                Ports.Add(port);
            }
        }

        private void InitializeTariffPlans()
        {
            Tariffs.Add(new MaxTariffPlan());

            Tariffs.Add(new MinTariffPlan());

            Tariffs.Add(new MediumTariffPlan());
        }
    }
}
