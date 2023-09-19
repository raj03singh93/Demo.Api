namespace Demo.Api.Service.Contract
{
    public interface ITransientService
    {
        Task<int> GetId();
    }
    public class TransientService : ITransientService
    {
        private int _id;
        public TransientService()
        {
            _id = Random.Shared.Next(1, 50);
        }

        public Task<int> GetId()
        {
            return Task.FromResult(_id);
        }
    }
}
