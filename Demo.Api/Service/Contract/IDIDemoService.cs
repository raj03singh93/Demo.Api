namespace Demo.Api.Service.Contract
{
    public interface IDIDemoService
    {
        Task<int> GetSingleton();
        Task<int> GetScoped();
        Task<int> GetTransient();
    }

    public class DIDemoService : IDIDemoService
    {
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;
        private readonly ISingletonService singletonService;
        public DIDemoService(IScopedService scopedService, ITransientService transientService, ISingletonService singletonService)
        {
            this.scopedService = scopedService;
            this.transientService = transientService;
            this.singletonService = singletonService;
        }

        public Task<int> GetScoped()
        {
            return scopedService.GetId();
        }

        public Task<int> GetSingleton()
        {
            return singletonService.GetId();
        }

        public Task<int> GetTransient()
        {
            return transientService.GetId();
        }
    }
}
