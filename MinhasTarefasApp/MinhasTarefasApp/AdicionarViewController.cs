using System;
using Foundation;
using MinhasTarefasApp.ServiceAgents;
using MinhasTarefasApp.ViewModel;
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

        private async void AdicionarButton_TouchUpInside(object sender, EventArgs e)
        {
            AdicionarButton.Enabled = false;

            using (var client = new TarefaService())
            {
                try
                {
                    await client.GravarAsync(new Tarefa {Descricao = TarefaTextField.Text});
                }
                catch (Exception)
                {
                    const string retorno =
                        "Ocorreu um erro ao realizar operação! Por favor, tente novamente mais tarde!";
                    new UIAlertView("Adicionar Tarefa", retorno, null, "OK", null).Show();
                    AdicionarButton.Enabled = true;
                    return;
                }
            }

            NSUserDefaults.StandardUserDefaults.SetBool(true, "UpdatedApi");
            NavigationController.PopToRootViewController(true);
            //
        }
    }
}

