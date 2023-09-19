using Demo.Api.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DIDemoController : ControllerBase
    {
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;
        private readonly ISingletonService singletonService;
        private readonly IDIDemoService dIDemoService;
        private readonly ILogger<DIDemoController> logger;

        public DIDemoController(
            IScopedService scopedService,
            ITransientService transientService,
            ISingletonService singletonService,
            IDIDemoService dIDemoService,
            ILogger<DIDemoController> logger)
        {
            this.scopedService = scopedService;
            this.transientService = transientService;
            this.singletonService = singletonService;
            this.dIDemoService = dIDemoService;
            this.logger = logger;
        }

        /// <summary>
        /// Singleton Dependency
        /// </summary>
        /// <remarks>
        /// Demo for Singleton Registration of service
        /// </remarks>
        /// <returns></returns>
        /// <response code = "200">Guid from different module</response>
        [HttpGet()]
        [Route("Singleton")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<object> GetSingleton()
        {
            logger.LogInformation($"calling method : {nameof(this.GetSingleton)}");
            int fromController = await singletonService.GetId();
            int fromService = await dIDemoService.GetSingleton();
            return new { idFromController = fromController, idFromService = fromService };
        }

        /// <summary>
        /// Scoped Dependency
        /// </summary>
        /// <remarks>
        /// Demo for Scoped Registration of service
        /// </remarks>
        /// <returns></returns>
        /// <response code = "200">Guid from different module</response>
        [HttpGet()]
        [Route("Scoped")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<object> GetScoped()
        {
            logger.LogInformation($"Calling Method : {nameof(this.GetScoped)}");
            int fromController = await scopedService.GetId();
            int fromService = await dIDemoService.GetScoped();
            return new { idFromController = fromController, idFromService = fromService };
        }

        /// <summary>
        /// Scoped Dependency
        /// </summary>
        /// <remarks>
        /// Demo for Scoped Registration of service
        /// </remarks>
        /// <returns></returns>
        /// <response code = "200">Guid from different module</response>
        [HttpGet()]
        [Route("Transient")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<object> GetTransient()
        {
            logger.LogInformation($"Calling method : {nameof(this.GetTransient)}");
            int fromController = await transientService.GetId();
            int fromService = await dIDemoService.GetTransient();
            return new { idFromController = fromController, idFromService = fromService };
        }
    }
}
