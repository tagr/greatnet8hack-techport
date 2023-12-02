using Azure;
using Azure.AI.OpenAI;
using greatnet8hack.ApiService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var client = new HttpClient();
var aiClient = new OpenAIClient(
        new Uri(Environment.GetEnvironmentVariable("OPENAI_API_PROXY_URL")),
        new AzureKeyCredential(Environment.GetEnvironmentVariable("OPENAI_APIKEY")));

app.MapPost("/search/{search}", async ([FromRoute] string search) =>
{
    var url = Environment.GetEnvironmentVariable("TECHPORT_API_SEARCH_URL");
    var stream = await client.GetStreamAsync($"{url}{search}");
    return Results.Stream(stream, "application/json");
});

app.MapPost("/project/{id}", async ([FromRoute] string id) =>
{
    var url = Environment.GetEnvironmentVariable("TECHPORT_API_PROJECT_URL");
    var stream = await client.GetStreamAsync($"{url}{id}");
    return Results.Stream(stream, "application/json");
});

app.MapPost("/headline/{level}", async ([FromRoute] int level, HttpRequest req) =>
{
    if (req == null || req.ContentLength == null) return Results.BadRequest();

    var reader = new StreamReader(req.Body);
    var corpus = await reader.ReadToEndAsync();

    if (string.IsNullOrWhiteSpace(corpus)) return Results.BadRequest();

    var content = level == 0
        ? await GetResponse(aiClient, $"{builder.Configuration["AcademicHeadlinePrompt"]}{corpus}")
        : await GetResponse(aiClient, $"{builder.Configuration["ScandalousHeadlinePrompt"]}{corpus}", level);

    return Results.Ok(new { Content = content });
});

app.MapPost("/subhead", async (HttpRequest req) =>
{
    if (req == null || req.ContentLength == null) return Results.BadRequest();

    var reader = new StreamReader(req.Body);
    var corpus = await reader.ReadToEndAsync();

    if (string.IsNullOrWhiteSpace(corpus)) return Results.BadRequest();

    var content = await GetResponse(aiClient, $"{builder.Configuration["Subhead"]}{corpus}");

    return Results.Ok(new { Content = content });
});


app.MapPost("/image", async (HttpRequest req) =>
{
    if (req == null || req.ContentLength == null) return Results.BadRequest();

    var reader = new StreamReader(req.Body);
    var corpus = await reader.ReadToEndAsync();

    if (string.IsNullOrWhiteSpace(corpus)) return Results.BadRequest();

    var content = await GetImageResponse(aiClient, client, $"{builder.Configuration["ImagePrompt"]}{corpus}");

    return Results.Ok(new { Content = content });
});

app.MapPost("/tags", async (HttpRequest req) =>
{
    if (req == null || req.ContentLength == null) return Results.BadRequest();

    var reader = new StreamReader(req.Body);
    var corpus = await reader.ReadToEndAsync();

    if (string.IsNullOrWhiteSpace(corpus)) return Results.BadRequest();

    var content = await GetResponse(aiClient, $"{builder.Configuration["TagPrompt"]}{corpus}");

    return Results.Ok(new { Content = content });
});

app.MapDefaultEndpoints();

app.Run();

static async Task<string> GetResponse(OpenAIClient client, string prompt, float temperature = 0.1f)
{
    var completionsOptions = new ChatCompletionsOptions
    {
        MaxTokens = 1024,
        Temperature = temperature,
        NucleusSamplingFactor = 0.95f,
        DeploymentName = "gpt-35-turbo",
        Messages = {
            new ChatMessage(ChatRole.User, prompt)
        }
    };

    var response = await client.GetChatCompletionsAsync(completionsOptions);

    if (response == null) return string.Empty;

    var content = response.GetRawResponse().Content.ToString();
    var json = JsonSerializer.Deserialize<OpenAiResponse>(content);

    if (json == null || json.choices == null) return string.Empty;

    var returnValue = json.choices[0].message.content;

    return returnValue.Replace("\"", string.Empty);
}

static async Task<string> GetImageResponse(OpenAIClient aiClient, HttpClient client, string prompt)
{
    var completionsOptions = new ImageGenerationOptions()
    {
        Prompt = prompt,
        Size = ImageSize.Size256x256,
    };

    var response = await aiClient.GetImageGenerationsAsync(completionsOptions);

    if (response == null || response.Value == null) return string.Empty;

    Uri uri = response.Value.Data[0].Url;

    var imageResponse = await client.GetAsync(uri);
    var imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();

    var base64 = Convert.ToBase64String(imageBytes);

    return $"data:image/png;base64,{base64}";
}