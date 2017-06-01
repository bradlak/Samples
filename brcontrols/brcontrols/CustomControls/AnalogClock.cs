using System;
using System.Timers;
using CoreGraphics;
using UIKit;

namespace brcontrols
{
    public class AnalogClock : UIView
    {
        private int minute;

        private int hour;

        private Timer timer;

        public AnalogClock()
        {
            this.Opaque = false;
            this.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
            timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += (sender, e) =>
            {
                SetDate(DateTime.Now);
            };

            timer.Start();
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
            }
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }

        private void SetDate(DateTime date)
        {
            var currentDate = DateTime.Now;
            Hour = currentDate.Hour;
            Minute = currentDate.Minute;
            InvokeOnMainThread(() =>
            {
                SetNeedsDisplay();
            });

        }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            var radianConversion = Math.PI / 180;
            var offset = 90 * Math.PI / 180;

            Minute = DateTime.Now.Minute;
            Hour = DateTime.Now.Hour;

            var center = new CGPoint(0.5f * rect.Width, 0.5f * rect.Height);
            var borderWidth = 0.07f * rect.Width;

            var radius = center.X - borderWidth;

            var filled = UIBezierPath.FromArc(center, radius, 0, 2 * (nfloat)Math.PI, true);
            filled.LineWidth = borderWidth;
            filled.Stroke();
            filled.AddClip();

            var context = UIGraphics.GetCurrentContext();
            context.SaveState();
            var colors = new CGColor[] { UIColor.FromRGB(31, 80, 31).CGColor, UIColor.FromRGB(110, 196, 84).CGColor };
            var locations = new nfloat[] { 0.0f, 0.6f };
            var space = CGColorSpace.CreateDeviceRGB();
            var gradient = new CGGradient(space, colors, locations);

            context.DrawLinearGradient(gradient,
                                       new CGPoint(rect.Width, rect.Height),
                                       new CGPoint(0, 0),
                                       CGGradientDrawingOptions.None);
            context.RestoreState();

            for (int i = 0; i < 60; i++)
            {
                var line = new UIBezierPath();

                var linesRadius = radius;
                var smallerRadius = 0.9f * linesRadius;

                if (i % 5 == 0)
                {
                    line.LineWidth = 0.2f * borderWidth;
                    linesRadius += 2;
                    smallerRadius -= 2;
                }
                else line.LineWidth = 0.1f * borderWidth;

                var radian = i * 6 * (Math.PI / 180);
                var lineStart = new CGPoint(center.X + linesRadius * (nfloat)Math.Cos(radian),
                                            center.Y + linesRadius * (nfloat)Math.Sin(radian));
                var lineEnd = new CGPoint(center.X + smallerRadius * (nfloat)Math.Cos(radian),
                                          center.Y + smallerRadius * (nfloat)Math.Sin(radian));

                line.MoveTo(lineStart);
                line.AddLineTo(lineEnd);
                UIColor.Black.SetStroke();
                line.Stroke();
            }

            var minuteRadius = 0.8f * radius;
            var minuteRadian = radianConversion * Minute * 6 - offset;
            var minutePath = new UIBezierPath();
            minutePath.MoveTo(center);
            minutePath.AddLineTo(
                new CGPoint(
                    center.X + minuteRadius * (nfloat)Math.Cos(minuteRadian),
                    center.Y + minuteRadius * (nfloat)Math.Sin(minuteRadian)
                ));
            minutePath.LineWidth = 0.5f * borderWidth;
            minutePath.LineCapStyle = CGLineCap.Round;
            minutePath.Stroke();

            var hourRadius = 0.6f * minuteRadius;
            var hourRadian = radianConversion * Hour * 30 - (offset - (0.5f * radianConversion * Minute));
            var hourPath = new UIBezierPath();
            hourPath.MoveTo(center);
            hourPath.AddLineTo(
                new CGPoint(
                    center.X + hourRadius * (nfloat)Math.Cos(hourRadian),
                    center.Y + hourRadius * (nfloat)Math.Sin(hourRadian)
                ));
            hourPath.LineWidth = 0.7f * borderWidth;
            hourPath.LineCapStyle = CGLineCap.Round;
            hourPath.Stroke();
        }
    }
}
