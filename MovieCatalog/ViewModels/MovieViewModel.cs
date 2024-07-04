using CommunityToolkit.Mvvm.ComponentModel;
using MovieCatalog.Models;

namespace MovieCatalog.ViewModels;

public class MovieViewModel(Movie movie) : ObservableObject
{
    private string _title = movie.Title;
    private string _studio = movie.Studio;
    private string _director = movie.Director;
    private DateOnly _year = new(movie.Year, 1, 1);

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Studio
    {
        get => _studio;
        set => SetProperty(ref _studio, value);
    }

    public string Director
    {
        get => _director;
        set => SetProperty(ref _director, value);
    }

    public DateOnly Year
    {
        get => _year;
        set => SetProperty(ref _year, value);
    }
}