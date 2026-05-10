namespace UatGolden20260510.Tests;

public class ScaffoldCleanupTests
{
    private const string RepoRoot = "/workspace/repo";
    private const string ApiProjectRoot = "/workspace/repo/src/UatGolden20260510.Api";

    [Fact]
    public void Program_NoWeatherForecastEndpoint()
    {
        // Arrange
        var programPath = Path.Combine(ApiProjectRoot, "Program.cs");

        // Act
        var content = File.ReadAllText(programPath);

        // Assert
        Assert.DoesNotContain("weatherforecast", content, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("/weatherforecast", content, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Program_NoWeatherForecastTypeReference()
    {
        // Arrange
        var programPath = Path.Combine(ApiProjectRoot, "Program.cs");

        // Act
        var content = File.ReadAllText(programPath);

        // Assert
        Assert.DoesNotContain("WeatherForecast", content, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void WeatherForecast_ModelFileDoesNotExist()
    {
        // Arrange & Act
        var filePath = Path.Combine(ApiProjectRoot, "WeatherForecast.cs");

        // Assert
        Assert.False(File.Exists(filePath), "WeatherForecast.cs should have been deleted.");
    }

    [Fact]
    public void WeatherForecast_ControllerFileDoesNotExist()
    {
        // Arrange & Act
        var filePath = Path.Combine(ApiProjectRoot, "Controllers", "WeatherForecastController.cs");

        // Assert
        Assert.False(File.Exists(filePath), "WeatherForecastController.cs should have been deleted.");
    }

    [Fact]
    public void Controllers_DirectoryDoesNotExist()
    {
        // Arrange & Act
        var dirPath = Path.Combine(ApiProjectRoot, "Controllers");

        // Assert
        Assert.False(Directory.Exists(dirPath), "Controllers directory should have been removed.");
    }
}
