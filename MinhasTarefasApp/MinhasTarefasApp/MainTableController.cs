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
        private List<Tarefa> _tarefas;
        private bool _isStarted;

        protected MainTableController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            _isStarted = false;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad(); // Perform any additional setup after loading the view, typically from a nib.

            using (var client = new TarefaService())
            {
                _tarefas = await client.ListarAsync();
            }

            if (_tarefas != null && _tarefas?.Count > 0) TableView.ReloadData();
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var isUpdatedApi = NSUserDefaults.StandardUserDefaults.BoolForKey("UpdatedApi");

            if (!_isStarted || !isUpdatedApi) return;

            using (var client = new TarefaService())
            {
                _tarefas = await client.ListarAsync();
            }

            TableView.ReloadData();
            NSUserDefaults.StandardUserDefaults.SetBool(false, "UpdatedApi");
        }


        public override nint NumberOfSections(UITableView tableView)
        {
            return nint.Parse("1");
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (_tarefas == null) return base.GetCell(tableView, indexPath);

            var celula = tableView.DequeueReusableCell("celulaTarefaId");
            celula.TextLabel.Text = _tarefas[indexPath.Row].Descricao;

            return celula;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tarefas == null ? nint.Parse("0") : nint.Parse(_tarefas.Count.ToString());
        }

        public override async void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle,
            NSIndexPath indexPath)
        {
            if (editingStyle != UITableViewCellEditingStyle.Delete) return;

            using (var client = new TarefaService())
            {
                try
                {
                    await client.DeleteAsync(_tarefas[indexPath.Row]);
                }
                catch (Exception)
                {
                    const string retorno = "Ocorreu um erro ao realizar operação! Por favor, tente novamente mais tarde!";
                    new UIAlertView("Deletar Tarefa", retorno, null, "OK", null).Show();
                    return;
                }
            }

            using (var client = new TarefaService())
            {
                _tarefas = await client.ListarAsync();
            }

            if (_tarefas != null && _tarefas?.Count > 0) TableView.ReloadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "AdicionarTarefaSegue") _isStarted = true;

            base.PrepareForSegue(segue, sender);
        }
    }
}
