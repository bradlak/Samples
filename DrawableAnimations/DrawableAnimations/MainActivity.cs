using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Views;

namespace DrawableAnimations
{
    [Activity(Label = "DrawableAnimations", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ImageView animationsView;

        private Button startButton;

        private Button stopButton;

        private AnimationDrawable animation;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            animationsView = FindViewById<ImageView>(Resource.Id.animationView);
            startButton = FindViewById<Button>(Resource.Id.startButton);
            stopButton = FindViewById<Button>(Resource.Id.stopButton);

            animation = (AnimationDrawable)GetDrawable(Resource.Drawable.coin_animation);
            animationsView.SetImageDrawable(animation);

            startButton.Click += (sender, args) =>
            {
                animation.Start();
            };

            stopButton.Click += (sender, args) =>
            {
                animation.Stop();
            };
        }
    }
}

