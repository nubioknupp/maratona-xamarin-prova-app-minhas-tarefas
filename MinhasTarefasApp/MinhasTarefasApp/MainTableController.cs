using System;
using UIKit;

namespace MinhasTarefasApp
{
	public partial class MainTableController : UITableViewController
	{
		protected MainTableController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		//public override nint NumberOfSections(UITableView tableView)
		//{
		//	return nint.Parse("1");
		//}

		//public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		//{
		//	var myCell = (Cell)tableView.DequeueReusableCell("celulaTarefaId");
		//	myCell.SetCell(ListNewses[indexPath.Row].Title.ToString(),
		//						ListNewses[indexPath.Row].Description.ToString());
		//	return myCell;
		//}

		//public override nint RowsInSection(UITableView tableview, nint section)
		//{
		//	return nint.Parse(ListNewses.Count.ToString());
		//}

	}
}
