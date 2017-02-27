// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MinhasTarefasApp
{
	[Register ("AdicionarViewController")]
	partial class AdicionarViewController
	{
		[Outlet]
		UIKit.UIButton AdicionarButton { get; set; }

		[Outlet]
		UIKit.UITextField TarefaTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TarefaTextField != null) {
				TarefaTextField.Dispose ();
				TarefaTextField = null;
			}

			if (AdicionarButton != null) {
				AdicionarButton.Dispose ();
				AdicionarButton = null;
			}
		}
	}
}
