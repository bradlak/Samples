using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace brcontrols.CustomControls
{
	[Register("SpotifyButton"), DesignTimeVisible(true)]
    public partial class SpotifyButton : UIButton
    {
		public SpotifyButton(IntPtr handle) : base(handle)
        {

		}

        public SpotifyButton()
        {

        }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            var centerPoint = new CGPoint(rect.Width / 2, rect.Height / 2);
            var firstArcLeft = new CGPoint(centerPoint.X - 27,  centerPoint.Y - 12);
            var firstArcControl = new CGPoint(centerPoint.X + 2, centerPoint.Y - 18);
            var firstArcRight = new CGPoint(centerPoint.X + 27, centerPoint.Y - 8);

			var secondArcLeft = new CGPoint(centerPoint.X - 22, centerPoint.Y - 2);
			var secondArcControl = new CGPoint(centerPoint.X + 2, centerPoint.Y - 6);
			var secondArcRight = new CGPoint(centerPoint.X + 22, centerPoint.Y + 2);

			var thirdArcLeft = new CGPoint(centerPoint.X - 17, centerPoint.Y + 8);
			var thirdArcControl = new CGPoint(centerPoint.X, centerPoint.Y +4);
			var thirdArcRight = new CGPoint(centerPoint.X + 17, centerPoint.Y + 12);

            this.SetTitle(string.Empty, UIControlState.Normal);
            this.SetTitle(string.Empty, UIControlState.Highlighted);

            var context = UIGraphics.GetCurrentContext();

            var path = UIBezierPath.FromOval(rect);

            if (this.State == UIControlState.Highlighted) GetColor(22, 101, 48).SetFill();
                else GetColor(47, 213, 102).SetFill();
            UIColor.Black.SetStroke();
            path.Fill();
            path.LineWidth = 0.2f;
            path.Stroke();

            var waves = new UIBezierPath();
            waves.LineCapStyle = CGLineCap.Round;
            waves.LineWidth = 5.0f;
            UIColor.Black.SetStroke();
            waves.MoveTo(firstArcLeft);
            waves.AddCurveToPoint(firstArcRight, firstArcControl, firstArcControl);
            waves.Stroke();

			var waves2 = new UIBezierPath();
			waves2.LineCapStyle = CGLineCap.Round;
            waves2.LineWidth = 4.4f;
			UIColor.Black.SetStroke();
            waves2.MoveTo(secondArcLeft);
            waves2.AddCurveToPoint(secondArcRight, secondArcControl, secondArcControl);
			waves2.Stroke();

			var waves3 = new UIBezierPath();
			waves3.LineCapStyle = CGLineCap.Round;
			waves3.LineWidth = 3.8f;
			UIColor.Black.SetStroke();
			waves3.MoveTo(thirdArcLeft);
			waves3.AddCurveToPoint(thirdArcRight, thirdArcControl, thirdArcControl);
			waves3.Stroke();
		}

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.SetNeedsDisplay();
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            this.SetNeedsDisplay();
        }

        private UIColor GetColor(int red, int green, int blue)
        {
            var max = 255f;
            return UIColor.FromRGB((float)red / max, (float)green / max, (float)blue / max);
        }
    }
}
