using CoreGraphics;
using Foundation;
using UIKit;

namespace brcontrols.CustomControls
{
    public partial class SpotifyButton : UIButton
    {
        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            var baseWidth = rect.Width;
            var baseHeight = rect.Height;

            var centerPoint = new CGPoint(rect.Width * 0.5f, rect.Height * 0.5f);
            var firstArcLeft = new CGPoint(centerPoint.X * 0.32f, centerPoint.Y * 0.7f);
            var firstArcControl = new CGPoint(centerPoint.X * 1.05f, centerPoint.Y * 0.55f);
            var firstArcRight = new CGPoint(centerPoint.X * 1.67f, centerPoint.Y * 0.8f);

            var secondArcLeft = new CGPoint(centerPoint.X * 0.45f, centerPoint.Y * 0.95f);
            var secondArcControl = new CGPoint(centerPoint.X * 1.05f, centerPoint.Y * 0.85f);
            var secondArcRight = new CGPoint(centerPoint.X * 1.55f, centerPoint.Y * 1.05f);

            var thirdArcLeft = new CGPoint(centerPoint.X * 0.57f, centerPoint.Y * 1.2f);
            var thirdArcControl = new CGPoint(centerPoint.X, centerPoint.Y * 1.1f);
            var thirdArcRight = new CGPoint(centerPoint.X * 1.42f, centerPoint.Y * 1.3f);

            this.SetTitle(string.Empty, UIControlState.Normal);
            this.SetTitle(string.Empty, UIControlState.Highlighted);

            using (var context = UIGraphics.GetCurrentContext())
            {
                var path = UIBezierPath.FromOval(rect);
                context.SetStrokeColor(UIColor.Black.CGColor);

                if (this.State == UIControlState.Highlighted) GetColor(22, 101, 48).SetFill();
                else GetColor(47, 213, 102).SetFill();
                path.Fill();
                path.LineWidth = 0.2f;
                path.Stroke();

                var waves = new UIBezierPath();
                waves.LineCapStyle = CGLineCap.Round;
                waves.LineWidth = baseWidth * 0.06f;
                waves.MoveTo(firstArcLeft);
                waves.AddCurveToPoint(firstArcRight, firstArcControl, firstArcControl);
                waves.Stroke();

                var waves2 = new UIBezierPath();
                waves2.LineCapStyle = CGLineCap.Round;
                waves2.LineWidth = baseWidth * 0.05f;
                waves2.MoveTo(secondArcLeft);
                waves2.AddCurveToPoint(secondArcRight, secondArcControl, secondArcControl);
                waves2.Stroke();

                var waves3 = new UIBezierPath();
                waves3.LineCapStyle = CGLineCap.Round;
                waves3.LineWidth = baseWidth * 0.04f;
                waves3.MoveTo(thirdArcLeft);
                waves3.AddCurveToPoint(thirdArcRight, thirdArcControl, thirdArcControl);
                waves3.Stroke();
            }
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
