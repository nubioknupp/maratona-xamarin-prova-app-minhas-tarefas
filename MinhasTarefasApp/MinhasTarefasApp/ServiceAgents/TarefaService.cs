using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MinhasTarefasApp.ViewModel;

namespace MinhasTarefasApp.ServiceAgents
{
	public class TarefaService : IDisposable
	{
		private readonly MobileServiceClient _client;
		private readonly IMobileServiceTable<Tarefa> _tarefaTable;
		//public List<TarefaViewModel> Tarefas { get; private set; }

		public TarefaService()
		{
			CurrentPlatform.Init();

			// Initialize the Mobile Service client with your URL and key
			//client = new MobileServiceClient (Constants.ApplicationURL, Constants.ApplicationKey, this);

			_client = new MobileServiceClient("http://tarefamanager.azurewebsites.net");

			// Create an MSTable instance to allow us to work with the TodoItem table
			_tarefaTable = _client.GetTable<Tarefa>();

		}

		public async Task<List<Tarefa>> ListarAsync()
		{
			return await _tarefaTable.OrderBy(c => c.Descricao).ToListAsync();
		}

		public async Task GravarAsync(Tarefa tarefa)
		{
			await _tarefaTable.InsertAsync(tarefa);
		}

		public async Task DeleteAsync(Tarefa tarefa)
		{
			await _tarefaTable.DeleteAsync(tarefa);
		}

		public void Dispose()
		{
			_client.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
