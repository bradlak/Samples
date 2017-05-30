using System;
using System.Collections.Generic;
using UIKit;

namespace brcontrols
{
    public partial class ViewController : UIViewController
    {
        private UIPageViewController pageViewController;

        private List<ControlInfo> pages;

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            pages = new List<ControlInfo>();

            foreach (ControlType item in Enum.GetValues(typeof(ControlType)))
            {
                pages.Add(new ControlInfo() {Type = item});
            }


            pageViewController = this.Storyboard.InstantiateViewController("PageViewController") as PageViewController;
            var start = GetViewController(0);
            var viewControllers = new UIViewController[] { start };

            pageViewController.DataSource = new PageViewControllerDataSource(pages, this);
            pageViewController.SetViewControllers(viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);
            pageViewController.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);
			AddChildViewController(pageViewController);
            View.AddSubview(pageViewController.View);
            pageViewController.DidMoveToParentViewController(this);
        }

        public UIViewController GetViewController(int index){
			var vc = this.Storyboard.InstantiateViewController("ContentViewController") as ContentViewController;
            vc.Info = pages[index];
            vc.Index = index;
            return vc;
		}


        public class PageViewControllerDataSource : UIPageViewControllerDataSource
        {
            private List<ControlInfo> pages;

            private ViewController parent;

            public PageViewControllerDataSource(List<ControlInfo> pages, ViewController parent)
            {
                this.pages = pages;
                this.parent = parent;
            }

            public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as ContentViewController;

                var index = vc.Index;

                if (++index == pages.Count) return null;
                else return parent.GetViewController(index);
            }

            public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as ContentViewController;

                var index = vc.Index;

                if (index-- == 0) return null;
                else return parent.GetViewController(index);
            }

            public override nint GetPresentationCount(UIPageViewController pageViewController)
            {
                return pages.Count;
            }

            public override nint GetPresentationIndex(UIPageViewController pageViewController)
            {
                return 0;
            }
        }
    }
}
