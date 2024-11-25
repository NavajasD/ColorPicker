using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorPicker.Maui
{
    public partial class MainPage : ContentPage
    {
        private bool isRandom;
        private string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sliderRed.Value;
                var green = sliderGreen.Value;
                var blue = sliderBlue.Value;

                Color color = Color.FromRgb(
                    red,
                    green,
                    blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            Debug.WriteLine($"Color set to: {color.ToString()}");

            buttonRandom.BackgroundColor = color;
            container.BackgroundColor = color;
            hexValue = color.ToHex();
            labelHex.Text = hexValue;
        }

        private void buttonRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;

            var random = new Random();

            Color color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            sliderRed.Value = color.Red;
            sliderGreen.Value = color.Green;
            sliderBlue.Value = color.Blue;

            SetColor(color);

            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);

            var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
    }

}
