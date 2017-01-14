using System.Collections.Generic;
using System.Linq;
using ConductOfCode.Specs.Clients;

namespace ConductOfCode.Specs
{
    public class StackFacade
    {
        private readonly StackClient _client;

        public StackFacade()
        {
            _client = new StackClient();
        }

        public void Clear()
        {
            _client.ClearAsync().Wait();
        }

        public string Peek()
        {
            return _client.PeekAsync().Result.Value;
        }

        public string Pop()
        {
            return _client.PopAsync().Result.Value;
        }

        public void Push(string item)
        {
            _client.PushAsync(new Item { Value = item }).Wait();
        }

        public IEnumerable<string> ToArray()
        {
            return _client.ToArrayAsync().Result.Select(x => x.Value);
        }
    }
}