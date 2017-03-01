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

        private void AdicionarButton_TouchUpInside(object sender, EventArgs e)
        {
            string retorno;

            using (var client = new TarefaApiClient())
            {
                retorno = client.Gravar(new TarefaViewModel {Tarefa = TarefaTextField.Text});
            }

            if (retorno != "")
            {
                new UIAlertView("Adicionar Tarefa", retorno, null, "OK", null).Show();
            } else {
                NSUserDefaults.StandardUserDefaults.SetBool(true, "UpdatedApi");
            }

            NavigationController.PopToRootViewController(true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

