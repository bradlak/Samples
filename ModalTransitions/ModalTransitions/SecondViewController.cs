using System;

using UIKit;

namespace ModalTransitions
{
    public partial class SecondViewController : UIViewController
    {
        public SecondViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            closeBtn.TouchUpInside += (sender, e) =>
            {
                DismissModalViewController(animateSwitch.On);
            };
        }
    }
}

