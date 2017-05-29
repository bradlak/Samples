using Android.App;
using Android.Widget;
using Android.OS;
using Com.Example.Javacalculator;

namespace AndroidNativeCalculator
{
    [Activity(Label = "AndroidNativeCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ICalculator calc;

        protected override void OnCreate(Bundle bundle)

        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            calc = new Calculator();

            var firstNP = FindViewById<NumberPicker>(Resource.Id.firstNumber);
            var secondNP = FindViewById<NumberPicker>(Resource.Id.secondNumber);

            firstNP.MinValue = secondNP.MinValue = 0;
            firstNP.MaxValue = secondNP.MaxValue = 100;

            var result = FindViewById<TextView>(Resource.Id.result);

            FindViewById<Button>(Resource.Id.add).Click += (sender, args) => result.Text = calc.Add(firstNP.Value, secondNP.Value).ToString();
            FindViewById<Button>(Resource.Id.subtract).Click += (sender, args) => result.Text = calc.Subtract(firstNP.Value, secondNP.Value).ToString();
            FindViewById<Button>(Resource.Id.multiply).Click += (sender, args) => result.Text = calc.Multiply(firstNP.Value, secondNP.Value).ToString();
            FindViewById<Button>(Resource.Id.divide).Click += (sender, args) => result.Text = calc.Divide(firstNP.Value, secondNP.Value).ToString();
        }
    }
}

