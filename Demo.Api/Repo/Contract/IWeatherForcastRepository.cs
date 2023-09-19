namespace Demo.Api.Repo.Contract
{
    public interface IWeatherForcastRepository
    {
        Task<WeatherForecast> GetForcastAsync(int cityId);
        Task<List<WeatherForecast>> GetWeatherForecastsAsync();
    }
}
