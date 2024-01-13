namespace LogisticCalcMA
{
    public partial class MainPage : ContentPage
    {

        LogisticCalcLib.MainModel model = new LogisticCalcLib.MainModel("40000", "2000", true);


        public MainPage()
        {
            InitializeComponent();
            #region Binding
            Binding bindingBet = new Binding { Source = model, Path = "Price" };
            Bet.SetBinding(Entry.TextProperty, bindingBet);

            Binding bindingComission = new Binding { Source = model, Path = "RollBack" };
            Commission.SetBinding(Entry.TextProperty, bindingComission);

            Binding bindingReserv = new Binding { Source = model, Path = "Reserve" };
            reserve.SetBinding(Entry.TextProperty, bindingReserv);

            Binding bindingPriceForATIWithRate = new Binding { Source = model, Path = "PriceForATIWithRate" };
            NormPriceNDS.SetBinding(Label.TextProperty, bindingPriceForATIWithRate);

            Binding bindingPricengForATIWithOutRate = new Binding { Source = model, Path = "PricengForATIWithOutRate" };
            NormPriceNoNDS.SetBinding(Label.TextProperty, bindingPricengForATIWithOutRate);

            Binding bindingMaxPriceWithRate = new Binding { Source = model, Path = "MaxPriceWithRate" };
            MaxPriceNDS.SetBinding(Label.TextProperty, bindingMaxPriceWithRate);

            Binding bindingMaxPriceNoNDS = new Binding { Source = model, Path = "MaxPriceWithOutRate" };
            MaxPriceNoNDS.SetBinding(Label.TextProperty, bindingMaxPriceNoNDS);
            #endregion

            model.Price = Preferences.Default.Get("price", 40000);
            model.RollBack = Preferences.Default.Get("rollBack", 2000);
            model.Reserve = Preferences.Default.Get("reserv", 2000);
            model.RoundUp = Preferences.Default.Get("roundUp", false);

            TapGestureRecognizer tapNormPriceNDS = new TapGestureRecognizer();
            TapGestureRecognizer tapNormPriceNoNDS = new TapGestureRecognizer();
            TapGestureRecognizer tapMaxPriceNDS = new TapGestureRecognizer();
            TapGestureRecognizer tapMaxPriceNoNDS = new TapGestureRecognizer();
            tapNormPriceNDS.NumberOfTapsRequired = 1;

            NormPriceNDS.GestureRecognizers.Add(tapNormPriceNDS);
            tapNormPriceNDS.Tapped += TapNormPriceNDS_Tapped;

            NormPriceNoNDS.GestureRecognizers.Add(tapNormPriceNoNDS);
            tapNormPriceNoNDS.Tapped += TapNormPriceNoNDS_Tapped;

            MaxPriceNDS.GestureRecognizers.Add(tapMaxPriceNDS);
            tapMaxPriceNDS.Tapped += TapMaxPriceNDS_Tapped;

            MaxPriceNoNDS.GestureRecognizers.Add(tapMaxPriceNoNDS);
            tapMaxPriceNoNDS.Tapped += TapMaxPriceNoNDS_Tapped;
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

            #endregion
        }
        /// <summary>
        /// Вычисляем прибыль
        /// </summary>
        /// <param name="bet">Ставка заказчика</param>
        /// <param name="comission">Комиссия</param>
        /// <param name="betToTruck">Ставка для перевозчика</param>
        /// <param name="withNDS">С НДС или без</param>
        /// <returns></returns>
        private string ProfitWithNDS(int betToTruck, bool withNDS)
        {
            string profitStr = String.Empty;
            double profit = 0;

            if (withNDS) 
            {
                profit = (model.Price - betToTruck)*0.2;
                profitStr = Math.Round(profit, 0).ToString();
            }
            else
            {
                profit = ((model.Price / 1.2) - betToTruck) * 0.2;
                profitStr = Math.Round(profit, 0).ToString();

            }
            return profitStr;
        }

        private void TapMaxPriceNoNDS_Tapped(object? sender, TappedEventArgs e)
        {
            DisplayAlert("Доход!", ProfitWithNDS(model.MaxPriceWithOutRate, false), "OK");
            //throw new NotImplementedException();
        }

        private void TapMaxPriceNDS_Tapped(object? sender, TappedEventArgs e)
        {
            DisplayAlert("Доход!", ProfitWithNDS(model.MaxPriceWithRate, true), "OK");
            //throw new NotImplementedException();
        }

        private void TapNormPriceNoNDS_Tapped(object? sender, TappedEventArgs e)
        {
            DisplayAlert("Доход!", ProfitWithNDS(model.PricengForATIWithOutRate, false), "OK");
            //throw new NotImplementedException();
        }

        private void TapNormPriceNDS_Tapped(object? sender, TappedEventArgs e)
        {
            DisplayAlert("Доход!", ProfitWithNDS(model.PriceForATIWithRate, true), "OK");
            //throw new NotImplementedException();
        }

        private void OnBetMinus1000(object sender, EventArgs e)
        {
            model.DecreaseBid(1000);
            Preferences.Default.Set("price", model.Price);


            model.Price = Preferences.Default.Get("price", 40000);
            model.RollBack = Preferences.Default.Get("rollBack", 2000);
            model.Reserve = Preferences.Default.Get("reserv", 2000);
            model.RoundUp = Preferences.Default.Get("roundUp", false);
        }
        private void OnBetPlus1000(object sender, EventArgs e)
        {
            model.IncreaseBid(1000);
            Preferences.Default.Set("price", model.Price);
        }
        private void OnCommissionMinus100(object sender, EventArgs e)
        {
            model.DecreaseRollBack(1000);
            Preferences.Default.Set("rollBack", model.RollBack);
        }
        private void OnCommissionPlus100(object sender, EventArgs e)
        {
            model.IncreaseRollBack(1000);
            Preferences.Default.Set("rollBack", model.RollBack);
        }
        private void OnReserveMinus1000(object sender, EventArgs e)
        {
            model.DecreaseReserve(1000);
            Preferences.Default.Set("reserv", model.Reserve);
        }
        private void OnReservePlus1000(object sender, EventArgs e)
        {
            model.IncreaseReserve(1000);
            Preferences.Default.Set("reserv", model.Reserve);
        }

        private void OnCheckChange(object sender, CheckedChangedEventArgs e)
        {
            model.ChangeRoundUp();
            Preferences.Default.Set("roundUp", model.RoundUp);
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
            Preferences.Default.Set("price", model.Price);
            Preferences.Default.Set("rollBack", model.RollBack);
            Preferences.Default.Set("reserv", model.Reserve);
            Preferences.Default.Set("roundUp", model.RoundUp);
        }


        
    }

}
