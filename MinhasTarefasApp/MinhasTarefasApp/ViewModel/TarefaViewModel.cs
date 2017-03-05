using Newtonsoft.Json;

namespace MinhasTarefasApp.ViewModel
{
    public class Tarefa
    {
        public string Id { get; set; }

		[JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}