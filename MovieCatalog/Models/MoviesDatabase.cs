namespace MovieCatalog.Models;

internal static class MoviesDatabase
{
    public static async Task<IEnumerable<Movie>> GetMovies()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");

        System.Text.Json.JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        IEnumerable<Movie>? movies = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Movie>>(stream, options);

        return movies ?? [];
    }
}
