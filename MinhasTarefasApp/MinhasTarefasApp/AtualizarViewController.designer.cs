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
	[Register ("AtualizarViewController")]
	partial class AtualizarViewController
	{
		[Outlet]
		UIKit.UIButton AtualizarButton { get; set; }

		[Outlet]
		UIKit.UITextField TarefaTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AtualizarButton != null) {
				AtualizarButton.Dispose ();
				AtualizarButton = null;
			}

			if (TarefaTextField != null) {
				TarefaTextField.Dispose ();
				TarefaTextField = null;
			}
		}
	}
}
