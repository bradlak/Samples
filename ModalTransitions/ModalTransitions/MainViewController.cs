using System;

using UIKit;

namespace ModalTransitions
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            coverVerticalBtn.TouchUpInside += (sender, e) => ShowViewController(UIModalTransitionStyle.CoverVertical);
            partialCurlBtn.TouchUpInside += (sender, e) => ShowViewController(UIModalTransitionStyle.PartialCurl);
            flipHorizontalBtn.TouchUpInside += (sender, e) => ShowViewController(UIModalTransitionStyle.FlipHorizontal);
            crossDissolveBtn.TouchUpInside += (sender, e) => ShowViewController(UIModalTransitionStyle.CrossDissolve);
        }

        public async void ShowViewController(UIModalTransitionStyle style)
        {
            var controller = this.Storyboard.InstantiateViewController("SecondViewController");
            controller.ModalTransitionStyle = style;

            await PresentViewControllerAsync(controller, true);
        }
    }
}

