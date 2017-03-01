using System;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhasTarefasApp.ViewModel;

namespace MinhasTarefasApp.ServiceAgents
{
    public class TarefaApiClient : IDisposable
    {
        private readonly RestClient _client;
        private const string Resource = "Tables/Tarefas";

        public TarefaApiClient()
        {
            _client = new RestClient("http://tarefamanager.azurewebsites.net");
        }

        public string Gravar(TarefaViewModel tarefa)
        {
            var request = new RestRequest(Resource, Method.POST) {RequestFormat = DataFormat.Json};

            request.AddBody(tarefa);
            request.AddHeader("ZUMO-API-VERSION", "2.0.0");
            request.AddHeader("Content-Type", "application/json");

            var response = _client.Execute(request);
            var statusCode = response.StatusCode;


            if (statusCode == HttpStatusCode.Created) return "";

            return "Ocorreu um erro ao realizar operação! Por favor, tente novamente mais tarde!";
        }

        public string Delete(string id)
        {
            var request = new RestRequest($"{Resource}/{id}", Method.DELETE);

            request.AddHeader("ZUMO-API-VERSION", "2.0.0");
            request.AddHeader("Content-Type", "application/json");

            var response = _client.Execute(request);

            var statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.OK) return "";

            return "Ocorreu um erro ao realizar operação! Por favor, tente novamente mais tarde!";
        }

        public List<TarefaViewModel> Listar()
        {
            var request = new RestRequest(Resource, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("ZUMO-API-VERSION", "2.0.0");
            request.AddHeader("Content-Type", "application/json");
            var response = _client.Execute(request);

            var statusCode = response.StatusCode;

            if (statusCode != HttpStatusCode.OK) return new List<TarefaViewModel>();

            var deserial = new JsonDeserializer();

            return deserial.Deserialize<List<TarefaViewModel>>(response) as List<TarefaViewModel>;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}