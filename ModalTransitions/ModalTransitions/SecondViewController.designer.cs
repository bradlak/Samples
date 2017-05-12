// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ModalTransitions
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch animateSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton closeBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (animateSwitch != null) {
                animateSwitch.Dispose ();
                animateSwitch = null;
            }

            if (closeBtn != null) {
                closeBtn.Dispose ();
                closeBtn = null;
            }
        }
    }
}