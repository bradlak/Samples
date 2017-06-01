using System;
using Foundation;
using CoreGraphics;
using UIKit;
using CoreText;

namespace brcontrols
{
    public class CircularProgress : UIView
    {
        private int progress;

        private string text = "0";

        public int Progress
        {
            get { return progress; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    progress = value;
                    text = progress.ToString();
                    SetNeedsDisplay();
                }
            }
        }

        public CircularProgress()
        {
            this.Opaque = false;
            this.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var center = new CGPoint(0.5f * rect.Width, 0.5f *  rect.Height);

            var barWidth = 0.15f * rect.Width;

            var valueAngle = (1.5f * (nfloat)Math.PI) * ( 0.01f * (nfloat)Progress);
            var min = 0.75f * (nfloat)Math.PI;
            var max = 0.25f * (nfloat)Math.PI;

            // firstArc
            var firstArcStart = min;
            var firstArcEnd = min + valueAngle;
            // secondArc
            var secondArcStart = firstArcEnd;
            var secondArcEnd = max;

            var radius = center.X - barWidth;

            var filled = UIBezierPath.FromArc(center, radius, firstArcStart, firstArcEnd, true);
            UIColor.Green.SetStroke();
            filled.LineWidth = barWidth;
            filled.Stroke();

            var empty = UIBezierPath.FromArc(center, radius, secondArcStart, secondArcEnd, true);
            UIColor.Red.SetStroke();
            empty.LineWidth = barWidth;
            empty.Stroke();

            using (var font = new CTFont("Verdana", 0.25f * rect.Width))
            using (var context = UIGraphics.GetCurrentContext())
            {
                CTParagraphStyle alignStyle = new CTParagraphStyle(new CTParagraphStyleSettings
                {
                    Alignment = CTTextAlignment.Center
                });

                var newRect = new CGRect(0, 0, rect.Width, rect.Height);
                using (var path = new CGPath())
                using (var attrString = new NSMutableAttributedString(text))
                {
                    NSRange stringRange = new NSRange(0, attrString.Length);

                    attrString.AddAttributes(new CTStringAttributes
                    {
                        Font = font,
                        ParagraphStyle = alignStyle,
                        ForegroundColor = UIColor.Black.CGColor
                    }, stringRange);

                    using (var framesetter = new CTFramesetter(attrString))
                    {
                        path.AddRect(newRect);
                        using (var frame = framesetter.GetFrame(stringRange, path, null))
                        {
                            context.SaveState();
                            context.TranslateCTM(0, 1.33f * rect.Height);
                            context.ScaleCTM(1, -1);
                            frame.Draw(context);
                            context.RestoreState();
                        }
                    }
                }
            }
        }
    }
}
