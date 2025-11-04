using System.Net.Http;
using System.Net.Http.Json;

namespace HelloMaui;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient = new();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
{
    try
    {
        string url = "https://fluffy-space-system-7jvw46q9q5phr4v6-5070.app.github.dev/hitmeBro/hitme";

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

        var rawResponse = await _httpClient.GetStringAsync(url);
        ApiResponseLabel.Text = $"Raw Response: {rawResponse}";

        // Optional: Try parsing only if it's valid JSON
        var response = JsonSerializer.Deserialize<HitMeResponse>(rawResponse);
        ApiResponseLabel.Text = $"Message: {response?.Message}";
    }
    catch (Exception ex)
    {
        ApiResponseLabel.Text = $"Error: {ex.Message}";
    }
}
}

public class HitMeResponse
{
    public string Message { get; set; }
}