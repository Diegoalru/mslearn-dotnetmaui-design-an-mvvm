using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieCatalog.Models;

namespace MovieCatalog.ViewModels;

public class MovieListViewModel : ObservableObject
{
    public ObservableCollection<MovieViewModel> Movies { get; set; }
    public ICommand DeleteMovieCommand { get; set; }
    private MovieViewModel? _selectedMovie;

    public MovieListViewModel()
    {
        Movies = [];
        DeleteMovieCommand = new Command<MovieViewModel>(DeleteMovie);
    }

    public MovieViewModel? SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    public async Task RefreshMovies()
    {
        var moviesData = await MoviesDatabase.GetMovies();

        foreach (var movie in moviesData)
            Movies.Add(new MovieViewModel(movie));
    }

    private void DeleteMovie(MovieViewModel movie)
    {
        Movies.Remove(movie);
    }
}