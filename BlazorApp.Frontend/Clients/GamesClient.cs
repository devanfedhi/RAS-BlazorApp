using System;
using System.Security.Cryptography.X509Certificates;
using BlazorApp.Frontend.Models;

namespace BlazorApp.Frontend.Clients;


public class GamesClient(HttpClient httpClient)
{
    // private readonly List<GameSummary> games = 
    // [
    //     new(){
    //         Id = 1,
    //         Name = "Street Fighter II",
    //         Genre = "Fighting",
    //         Price = 19.99M,
    //         ReleaseDate = new DateOnly(1992, 7, 15)
    //     },
    //     new(){
    //         Id = 2,
    //         Name = "Final Fantasy XIV",
    //         Genre = "Roleplaying",
    //         Price = 59.99M,
    //         ReleaseDate = new DateOnly(2010, 9, 30)
    //     },
    //     new(){
    //         Id = 3,
    //         Name = "FIFA 23",
    //         Genre = "Sports",
    //         Price = 69.99M,
    //         ReleaseDate = new DateOnly(2022, 9, 27)
    //     }
    // ];

    // private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();

    public async Task<GameSummary[]> GetGamesAsync() => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
        // => [.. games];

    public async Task AddGameAsync(GameDetails game) => await httpClient.PostAsJsonAsync("games", game);
    // {
        
        // Genre genre = GetGenreById(game.GenreId);

        // var gameSummary = new GameSummary
        // {
        //     Id = games.Count + 1,
        //     Name = game.Name,
        //     Genre = genre.Name,
        //     Price = game.Price,
        //     ReleaseDate = game.ReleaseDate
        // };

        // games.Add(gameSummary);
    // }


    public async Task<GameDetails> GetGameAsync(int id) => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Game not found");
    // {
        // GameSummary game = GetGameSummaryById(id);
        // var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        // return new GameDetails
        // {
        //     Id = game.Id,
        //     Name = game.Name,
        //     GenreId = genre.Id.ToString(),
        //     Price = game.Price,
        //     ReleaseDate = game.ReleaseDate
        // };
    // }

    public async Task UpdateGameAsync(GameDetails updatedGame) => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    // {
        // var genre = GetGenreById(updatedGame.GenreId);
        // GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        // existingGame.Name = updatedGame.Name;
        // existingGame.Genre = genre.Name;
        // existingGame.Price = updatedGame.Price;
        // existingGame.ReleaseDate = updatedGame.ReleaseDate;

    // }

    public async Task DeleteGameAsync(int id) => await httpClient.DeleteAsync($"games/{id}");
    // {
    //     GameSummary game = GetGameSummaryById(id);
    //     games.Remove(game);
    // }

    // private GameSummary GetGameSummaryById(int id)
    // {
    //     GameSummary? game = games.Find(game => game.Id == id);

    //     ArgumentNullException.ThrowIfNull(game);
    //     return game;
    // }

    // private Genre GetGenreById(string? id)
    // {
    //     ArgumentException.ThrowIfNullOrWhiteSpace(id);

    //     return genres.Single(genre => genre.Id == int.Parse(id));
    // }
}
