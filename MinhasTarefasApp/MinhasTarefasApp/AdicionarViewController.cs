using System;

using UIKit;

namespace MinhasTarefasApp
{
	public partial class AdicionarViewController : UIViewController
	{
		protected AdicionarViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			AdicionarButton.TouchUpInside += AdicionarButton_TouchUpInside;
		
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		protected void AdicionarButton_TouchUpInside(object sender, EventArgs e)
		{
			new UIAlertView("Touch3", "TouchUpInside handled", null, "OK", null).Show();
		}
	}
}

