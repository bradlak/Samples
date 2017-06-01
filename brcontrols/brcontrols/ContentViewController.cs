using System;
using UIKit;
using brcontrols.CustomControls;

namespace brcontrols
{
    public partial class ContentViewController : UIViewController
    {
        public int Index { get; set; }

        public ControlInfo Info { get; set; }

        public ContentViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            titleLabel.Text = Info.Name;

            var width = 80;
            var height = 80;
            var x = (containerView.Bounds.Width / 2) - (width / 2);
            var y = (containerView.Bounds.Height / 2) - (height / 2);
            var controlFrame = new CoreGraphics.CGRect(x, y, width, height);

            switch (Info.Type)
            {
                case ControlType.SpotifyButton:
                    var spotifyButton = new SpotifyButton();
                    spotifyButton.Frame = controlFrame;
                    containerView.AddSubview(spotifyButton);
                    break;

                case ControlType.CircularProgress:
                    var circularProgress = new CircularProgress();
                    circularProgress.Frame = controlFrame;
                    containerView.AddSubview(circularProgress);

                    var slider = new UISlider();

                    slider.MinValue = 0;
                    slider.MaxValue = 100;
                    slider.ValueChanged += (sender, e) =>
                    {
                        circularProgress.Progress = (int)slider.Value;
                    };

                    slider.Frame = new CoreGraphics.CGRect((this.View.Frame.Width / 2) - (slider.Frame.Width / 2),
                                                           this.View.Frame.Height - slider.Frame.Height - 50,
                                                           slider.Frame.Width,
                                                           slider.Frame.Height);
                    View.AddSubview(slider);
                    break;
                case ControlType.AnalogClock:
                    var analogClock = new AnalogClock();
                    analogClock.Frame = controlFrame;
                    containerView.AddSubview(analogClock);
                    break;
                default:
                    break;
            }
        }
    }
}