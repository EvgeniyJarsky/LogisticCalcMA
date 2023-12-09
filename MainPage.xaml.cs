using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace LogisticCalcMA
{
    public partial class MainPage : ContentPage
    {
        LogisticCalcLib.MainModel model = new LogisticCalcLib.MainModel("40000", "2000", true);
      

        public MainPage()
        {
            InitializeComponent();

            model.Reserve = 2000;
            reserve.Text = model.Reserve.ToString();

            Bet.Text = model.Price.ToString();
            Commission.Text = model.RollBack.ToString();
            

            #region
            if (int.TryParse(Bet.Text, out var price))
            {
                model.Price = price;
                if (int.TryParse(Commission.Text, out var rollBack))
                    model.RollBack = rollBack;
                else
                {
                    DisplayAlert("Внимание!", "Введите корректную комиссию", "OK");
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
            #endregion
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
        private void OnReserveMinus1000(object sender, EventArgs e)
        {
            model.DecreaseReserve(1000);
            reserve.Text = model.Reserve.ToString();

            NormPriceNDS.Text = model.PriceForATIWithRate.ToString();
            NormPriceNoNDS.Text = model.PricengForATIWithOutRate.ToString();

            MaxPriceNDS.Text = model.MaxPriceWithRate.ToString();
            MaxPriceNoNDS.Text = model.MaxPriceWithOutRate.ToString();
        }
        private void OnReservePlus1000(object sender, EventArgs e)
        {
            model.IncreaseReserve(1000);
            reserve.Text = model.Reserve.ToString();

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
                    DisplayAlert("Внимание!", "Введите корректную комиссию", "OK");
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

    }

}
