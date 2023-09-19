namespace Demo.Api.Service.Contract
{
    public interface IScopedService
    {
        Task<int> GetId();
    }

    public class ScopedService : IScopedService
    {
        private int _id;
        public ScopedService()
        {
            _id = Random.Shared.Next(1, 50);
        }

        public Task<int> GetId()
        {
            return Task.FromResult(_id);
        }
    }
}
