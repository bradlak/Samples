using Foundation;
using System;
using UIKit;
using brcontrols.CustomControls;

namespace brcontrols
{
    public partial class ContentViewController : UIViewController
    {
        public int Index { get; set; }

        public ControlInfo Info { get; set; }

        public SpotifyButton spotifyButton;

        public ContentViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            titleLabel.Text = Info.Name;

            switch (Info.Type){
                case ControlType.SpotifyButton:
                    spotifyButton = new SpotifyButton();
                    spotifyButton.TouchUpInside += (sender, e) => {
                        var action = UIAlertController.Create("Alert", "SpotifyButton clicked!", UIAlertControllerStyle.ActionSheet);
                        action.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Destructive, null));
                        PresentViewController(action, true, null);
                    };
                    containerView.AddSubview(spotifyButton);
                    break;
                default:
                    break;
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            if (spotifyButton != null)
            {
                var width = 80;
                var height = 80;
                var x = (containerView.Bounds.Width / 2) - (width / 2);
                var y = (containerView.Bounds.Height / 2) - (height / 2);

                spotifyButton.Frame = new CoreGraphics.CGRect(x, y, width, height);
            }
        }
    }
}