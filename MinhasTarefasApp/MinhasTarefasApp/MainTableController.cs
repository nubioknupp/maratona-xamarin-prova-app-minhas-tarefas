using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using MinhasTarefasApp.ServiceAgents;
using MinhasTarefasApp.ViewModel;


namespace MinhasTarefasApp
{
    public partial class MainTableController : UITableViewController
    {
        private List<TarefaViewModel> _tarefas;
        private bool _isStarted;

        protected MainTableController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            _isStarted = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad(); // Perform any additional setup after loading the view, typically from a nib.

            ListarTarefas();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (!_isStarted) return;

            ListarTarefas();
            TableView.ReloadData();
        }

        private void ListarTarefas()
        {
            using (var client = new TarefaApiClient())
            {
                _tarefas = client.Listar();
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return nint.Parse("1");
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var celula = tableView.DequeueReusableCell("celulaTarefaId");
            celula.TextLabel.Text = _tarefas[indexPath.Row].Tarefa;

            return celula;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return nint.Parse(_tarefas.Count.ToString());
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            if (editingStyle != UITableViewCellEditingStyle.Delete) return;

            string retorno;

            using (var client = new TarefaApiClient())
            {
                retorno = client.Delete(_tarefas[indexPath.Row].Id);
            }

            if(retorno != "") new UIAlertView("Erro", retorno, null, "OK", null).Show();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "AdicionarTarefaSegue") _isStarted = true;

            base.PrepareForSegue(segue, sender);
        }

    }
}
