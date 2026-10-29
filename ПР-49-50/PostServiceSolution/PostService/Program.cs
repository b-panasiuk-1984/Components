using Microsoft.AspNetCore.Http.HttpResults;
using PostService.Dtos;
using PostService.Mappings;
using PostService.Models;
using PostService.Services;
using PostService.CommonTypes;
using PostService.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingService, PostingService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var repository = scope.ServiceProvider.GetRequiredService<IPostingRepository>();
    repository.CreateDb();
}
app.UseCors("AllowFrontend");
var postings = new List<Posting>
{
    new Posting
    {
        Id = 1,
        From = "John",
        To = "Mike",
        Content = "Message 1",
        DeliveryType = DeliveryType.Courier,
        Weight = 2.5f,
        Width = 30,
        Height = 20,
        Depth = 10,
        Value = 50.0f,
        Price = 10.0f,
        CreatedAt = DateTime.UtcNow
    }
};
app.MapGet("/", () => "Це API поштового клієнта");

// ендпойт з попередньої практичної роботи
//app.MapGet("/postings", () => postings);


// ендпойнт з попередньої практичної роботи
//app.MapGet("/postings/{id}", (int id) =>
//{
//    var posting = postings.FirstOrDefault(p => p.Id == id);
//    return posting is null ? Results.NotFound() :
//    Results.Ok(posting);
//});

// ендпойнт з попередньої практичної роботи
//app.MapPut("/postings/{id}", (int id, Posting updated) =>
//{
//    var posting = postings.FirstOrDefault(p => p.Id == id);

//    if (posting is null)
//        return Results.NotFound();

//    posting.From = updated.From;
//    posting.To = updated.To;
//    posting.Content = updated.Content;
//    posting.DeliveryType = updated.DeliveryType;
//    posting.Weight = updated.Weight;
//    posting.Width = updated.Width;
//    posting.Height = updated.Height;
//    posting.Depth = updated.Depth;
//    posting.Value = updated.Value;
//    posting.Price = updated.Price;

//    return Results.Ok(posting);
//});

// ендпойнт з попередньої практичної роботи
//app.MapDelete("/postings/{id}", (int id) =>
//{
//    var posting = postings.FirstOrDefault(p => p.Id == id);

//    if (posting is null)
//        return Results.NotFound();

//    postings.Remove(posting);

//    return Results.NoContent();
//});

// ендпойнт з попередьної практичної роботи
//app.MapPost("/postings", (Posting posting) =>
//{
//    posting.Id = postings.Max(p => p.Id) + 1;
//    postings.Add(posting);
//    return Results.Created("/postings/{posting.Id}", posting);
//});

app.MapPut("/postings/{id}", (int id, PostingPutDTO putDto, IPostingService postingService) =>
{
    Console.WriteLine("UPDATE POSTING");
    var posting = PostingMapper.ToPosting(putDto);
    posting.Id = id;

    var newPosting = postingService.Update(posting);
    return newPosting == null ? Results.NotFound() : Results.Ok(PostingMapper.ToGetDto(newPosting));
});

// ендпойнт з попередньої практичної роботи
// app.MapGet("/postings", (IPostingService postingService) =>
// {
//     return postingService.GetAll();
// });

// ендпойнт з попередньої практичної роботи
// app.MapGet("/postings/{id}", (int id, IPostingService postingService) =>
// {
//     var posting = postingService.Find(id);
//     return posting == null ? Results.NotFound() : Results.Ok(posting);
// });

app.MapPost("/postings", (PostingPostDTO postDto, IPostingService postingService) =>
{
    Posting newPosting = PostingMapper.ToPosting(postDto);
    var savedObject = postingService.Create(newPosting);
    var resultDto = PostingMapper.ToGetDto(savedObject);
    return Results.Created($"/postings/{resultDto.Id}", resultDto);
});

app.MapDelete("/postings/{id}", (int id, IPostingService postingService) =>
{
    bool deleted = postingService.Delete(id) == 1;

    if (!deleted)
        return Results.NotFound();
    return Results.Ok(postingService.GetAll());
});

app.MapGet("/postings", (IPostingService postingService) =>
{
    var postings = postingService.GetAll();
    var dtos = postings.Select(p => PostingMapper.ToGetDto(p));
    return Results.Ok(dtos);
});

app.MapGet("/postings/{id}", (int id, IPostingService postingService) =>
{
    var posting = postingService.Find(id);
    return posting == null ? Results.NotFound() : Results.Ok(posting);
});

app.Run();
