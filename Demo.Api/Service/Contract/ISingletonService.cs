namespace Demo.Api.Service.Contract
{
    public interface ISingletonService
    {
        Task<int> GetId();
    }
    public class SingletonService : ISingletonService
    {
        private int _id;
        public SingletonService()
        {
            _id = Random.Shared.Next(1, 50);
        }

        public Task<int> GetId()
        {
            return Task.FromResult(_id);
        }
    }
}
