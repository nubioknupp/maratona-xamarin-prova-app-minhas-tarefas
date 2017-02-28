using System;
using UIKit;
using System.Linq;
using System.Collections;
using Foundation;

namespace MinhasTarefasApp
{
	public partial class MainTableController : UITableViewController
	{
		private ArrayList lstTarefa = new ArrayList();

		protected MainTableController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			lstTarefa.Add("Teste 1");
			lstTarefa.Add("Teste 2");
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete)
			{
				Console.WriteLine("Teste Delete");
			}
		}

		//

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "AdicionarTarefaSegue")
			{
				//var detail = segue.DestinationViewController as DetailViewController;

				//if (detail != null)
				//{
				//	var sourceNews = tableNews.Source as TableSourceNews;
				//	var rowPathNews = tableNews.IndexPathForSelectedRow;
				//	var news = sourceNews.GetNews(rowPathNews.Row);
				//	detail.SetNews(news);
				//	newsNav.BackBarButtonItem.Title = "";
				//}

				Console.WriteLine("AdicionarTarefaSegue");
			} 
			else if (segue.Identifier == "EditarTarefaSegue") 
			{ 
			    Console.WriteLine("EditarTarefaSegue");
			}

			base.PrepareForSegue(segue, sender);
		}


		public override nint NumberOfSections(UITableView tableView)
		{
			return nint.Parse("1");
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var celula = tableView.DequeueReusableCell("celulaTarefaId");
			celula.TextLabel.Text = lstTarefa[indexPath.Row].ToString();
			return celula;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return nint.Parse(lstTarefa.Count.ToString());
		}

	}
}
