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

		public TarefaService()
		{
			CurrentPlatform.Init();
			_client = new MobileServiceClient("http://tarefamanager.azurewebsites.net");
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
