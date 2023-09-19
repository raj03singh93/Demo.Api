namespace Demo.Api.Service.Contract
{
    public interface IWeatherForcastService
    {
        Task<WeatherForecast> GetForcastAsync(int cityId);
        Task<List<WeatherForecast>> GetWeatherForecastsAsync();
    }
}
