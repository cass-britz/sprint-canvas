namespace SprintCanvas.Api.Features.Health;

public class HealthResponse
{
    public string Status { get; set; } = "healthy";
    public DateTime Timestamp { get; set; }
}
