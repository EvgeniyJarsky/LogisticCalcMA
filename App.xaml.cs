namespace LogisticCalcMA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            const int newWidth = 380;
            const int newHeight = 650;

            window.X = 10;
            window.Y = 10;

            window.Width = newWidth;
            window.Height = newHeight;

            window.MinimumHeight = newHeight;
            window.MinimumWidth = newWidth;
            //window.MaximumHeight = newHeight;
            //window.MaximumWidth = newWidth;

            return window;
        }
    }
}
