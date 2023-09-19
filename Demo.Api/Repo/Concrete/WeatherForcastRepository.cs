using Demo.Api.Repo.Contract;
using System;

namespace Demo.Api.Repo.Concrete
{
    public class WeatherForcastRepository : IWeatherForcastRepository
    {
        private List<WeatherForecast> _data;
        public WeatherForcastRepository()
        {
            _data = new()
            {
                new() { Id= 1, Date = DateTime.Now.AddDays(Random.Shared.Next(1, 5)), TemperatureC = Random.Shared.Next(-20, 55), Summary = "Hot" },
                new() { Id= 2, Date = DateTime.Now.AddDays(Random.Shared.Next(2, 5)), TemperatureC = Random.Shared.Next(-20, 55), Summary = "Rainy" },
                new() { Id= 3, Date = DateTime.Now.AddDays(Random.Shared.Next(3, 5)), TemperatureC = Random.Shared.Next(-20, 55), Summary = "Cold" },
                new() { Id= 4, Date = DateTime.Now.AddDays(Random.Shared.Next(4, 5)), TemperatureC = Random.Shared.Next(-20, 55), Summary = "Rainy" },
            };
        }

        public Task<WeatherForecast> GetForcastAsync(int cityId)
        {
            return Task.FromResult(_data.FirstOrDefault(s => s.Id == cityId)!);
        }

        Task<List<WeatherForecast>> IWeatherForcastRepository.GetWeatherForecastsAsync()
        {
            return Task.FromResult(_data);
        }
    }
}
