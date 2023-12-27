using Xunit;
using Bogus;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Allure.Xunit;
using Allure.Xunit.Attributes;
using Newtonsoft.Json;
using PracticeApi;
using PracticeApi.Models;


namespace TestProject1;

public class UserTests
{
    private readonly HttpClient _client;
    private readonly ILogger _logger;
    private readonly Faker _faker;

    public UserTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:3000/");

        _logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("Log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        _faker = new Faker();

    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_CreateUser()
    {
        var newUser = new User { Id = 4, Name = _faker.Name.FullName() , Email = _faker.Internet.Email()};
        var jsonUser = JsonConvert.SerializeObject(newUser);
        var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("users", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_GetUser()
    {
        var response = await _client.GetAsync("users/1");

        response.EnsureSuccessStatusCode();

        var user = await response.Content.ReadAsStringAsync();
        var retrievedUser = JsonConvert.DeserializeObject<User>(user);

        Assert.NotNull(retrievedUser);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_UpdateUser()
    {
        var updateUser = new User { Id = 1, Name = _faker.Name.FullName(), Email = _faker.Internet.Email() };
        var jsonUser = JsonConvert.SerializeObject(updateUser);
        var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("users/1", content);

        Assert.True(response.IsSuccessStatusCode);
    }
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_DeleteUser()
    {
        var response = await _client.DeleteAsync("users/2");

        Assert.True(response.IsSuccessStatusCode);
    }
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_CreatePost()
    {
        var newPost = new Post { Id = 3, UserId = 1, Title = "Test Post", Body = "This is a test post." };
        var jsonPost = JsonConvert.SerializeObject(newPost);
        var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("posts", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_GetPost()
    {
        var response = await _client.GetAsync("posts/1");

        response.EnsureSuccessStatusCode();

        var post = await response.Content.ReadAsStringAsync();
        var retrievedPost = JsonConvert.DeserializeObject<Post>(post);

        Assert.NotNull(retrievedPost);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_UpdatePost()
    {
        var updatePost = new Post { Id = 1, UserId = 1, Title = "Updated Post", Body = "This is an updated post." };
        var jsonPost = JsonConvert.SerializeObject(updatePost);
        var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("posts/1", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_DeletePost()
    {
        var response = await _client.DeleteAsync("posts/2");

        Assert.True(response.IsSuccessStatusCode);
    }
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_CreateComment()
    {
        var newComment = new Comment { Id = 3, PostId = 1, Name = _faker.Name.FullName(), Email = _faker.Internet.Email(), Body = "This is a test comment." };
        var jsonComment = JsonConvert.SerializeObject(newComment);
        var content = new StringContent(jsonComment, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("comments", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_GetComment()
    {
        var response = await _client.GetAsync("comments/1");

        response.EnsureSuccessStatusCode();

        var comment = await response.Content.ReadAsStringAsync();
        var retrievedComment = JsonConvert.DeserializeObject<Comment>(comment);

        Assert.NotNull(retrievedComment);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_UpdateComment()
    {
        var updateComment = new Comment { Id = 1, PostId = 1, Name = _faker.Name.FullName(), Email = _faker.Internet.Email(), Body = "This is an updated comment." };
        var jsonComment = JsonConvert.SerializeObject(updateComment);
        var content = new StringContent(jsonComment, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("comments/1", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_DeleteComment()
    {
        var response = await _client.DeleteAsync("comments/2");

        Assert.True(response.IsSuccessStatusCode);
    }
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_CreateAlbum()
    {
        var newAlbum = new Album { Id = 3, UserId = 1, Title = "Test Album" };
        var jsonAlbum = JsonConvert.SerializeObject(newAlbum);
        var content = new StringContent(jsonAlbum, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("albums", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_GetAlbum()
    {
        var response = await _client.GetAsync("albums/1");

        response.EnsureSuccessStatusCode();

        var album = await response.Content.ReadAsStringAsync();
        var retrievedAlbum = JsonConvert.DeserializeObject<Album>(album);

        Assert.NotNull(retrievedAlbum);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_UpdateAlbum()
    {
        var updateAlbum = new Album { Id = 1, UserId = 1, Title = "Updated Album" };
        var jsonAlbum = JsonConvert.SerializeObject(updateAlbum);
        var content = new StringContent(jsonAlbum, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("albums/1", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_DeleteAlbum()
    {
        var response = await _client.DeleteAsync("albums/2");

        Assert.True(response.IsSuccessStatusCode);
    }
    
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_CreateTodo()
    {
        var newTodo = new Todo { Id = 4, UserId = 1, Title = "Test Todo", Completed = false };
        var jsonTodo = JsonConvert.SerializeObject(newTodo);
        var content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("todos", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_GetTodo()
    {
        var response = await _client.GetAsync("todos/1");

        response.EnsureSuccessStatusCode();

        var todo = await response.Content.ReadAsStringAsync();
        var retrievedTodo = JsonConvert.DeserializeObject<Todo>(todo);

        Assert.NotNull(retrievedTodo);
    }
    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_UpdateTodo()
    {
        var updateTodo = new Todo { Id = 1, UserId = 1, Title = "Updated Todo", Completed = true };
        var jsonTodo = JsonConvert.SerializeObject(updateTodo);
        var content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("todos/1", content);

        Assert.True(response.IsSuccessStatusCode);
    }

    [AllureXunit]
    [Obsolete("Obsolete")]
    public async Task Test_DeleteTodo()
    {
        var response = await _client.DeleteAsync("todos/2");

        Assert.True(response.IsSuccessStatusCode);
    }
}





