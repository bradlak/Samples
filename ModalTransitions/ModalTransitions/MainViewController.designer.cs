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
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton coverVerticalBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton crossDissolveBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton flipHorizontalBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton partialCurlBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (coverVerticalBtn != null) {
                coverVerticalBtn.Dispose ();
                coverVerticalBtn = null;
            }

            if (crossDissolveBtn != null) {
                crossDissolveBtn.Dispose ();
                crossDissolveBtn = null;
            }

            if (flipHorizontalBtn != null) {
                flipHorizontalBtn.Dispose ();
                flipHorizontalBtn = null;
            }

            if (partialCurlBtn != null) {
                partialCurlBtn.Dispose ();
                partialCurlBtn = null;
            }
        }
    }
}