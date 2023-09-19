using Demo.Api.Repo.Concrete;
using Demo.Api.Repo.Contract;
using Demo.Api.Service.Contract;

namespace Demo.Api.Service.Concrete
{
    public class WeatherForcastService : IWeatherForcastService
    {
        private readonly IWeatherForcastRepository weatherForcastRepository;

        public WeatherForcastService()
        {
            this.weatherForcastRepository = new WeatherForcastRepository();
        }

        public Task<WeatherForecast> GetForcastAsync(int cityId)
        {
            return this.weatherForcastRepository.GetForcastAsync(cityId);
        }

        public Task<List<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return this.weatherForcastRepository.GetWeatherForecastsAsync();
        }
    }
}
