namespace LogisticCalcMA
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        LogisticCalcLib.MainModel model = new LogisticCalcLib.MainModel("36000", "1000", true);


        public MainPage()
        {
            InitializeComponent();

            Bet.Text = model.Price.ToString();
            Commission.Text = model.RollBack.ToString();
            //this.WidthRequest = 600;
        }

        private void OnBetMinus1000(object sender, EventArgs e)
        {
            model.DecreaseBid(1000);
            Bet.Text = model.Price.ToString();

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnBetPlus1000(object sender, EventArgs e)
        {
            model.IncreaseBid(1000);
            Bet.Text = model.Price.ToString();

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnCommissionMinus100(object sender, EventArgs e)
        {
            model.DecreaseRollBack(1000);
            Commission.Text = model.RollBack.ToString() ;

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnCommissionPlus100(object sender, EventArgs e)
        {
            model.IncreaseRollBack(1000);
            Commission.Text = model.RollBack.ToString();

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnCheckChange(object sender, CheckedChangedEventArgs e)
        {
            model.ChangeRoundUp();

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (int.TryParse(Bet.Text, out var price))
            {
                model.Price = price;
                if (int.TryParse(Commission.Text, out var rollBack))
                    model.RollBack = rollBack;
                else
                {
                    DisplayAlert("Внимание!", "Введите корректный откат", "OK");
                    return;
                }
            }
            else
            {
                DisplayAlert("Внимание!", "Введите корректную ставку", "OK");
                return;
            }

            model.DecreaseBid(0);

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }

}
