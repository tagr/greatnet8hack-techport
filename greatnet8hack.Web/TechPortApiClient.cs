using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace greatnet8hack.Web
{
    public class TechPortApiClient(HttpClient httpClient, IMemoryCache memoryCache)
    {
        private const string NO_TAGS = "comma-delimited";

        public async Task<GptProjectResponse?> GetSearchResponseAsync(string search, WritingLevel level)
        {
            return await memoryCache.GetOrCreateAsync($"{search.ToLower()}{level}", async e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromSeconds(uint.MaxValue)
                });

                var rng = new Random();

                var returnValue = new GptProjectResponse();
                var response = await httpClient.PostAsync($"/search/{search}", null);
                var result = JsonSerializer.Deserialize<SearchResponse>(await response.Content.ReadAsStringAsync());

                if (result == null || result.projects.Length == 0) return returnValue;

                var projectResponse = await httpClient.PostAsync($"/project/{result.projects[0].projectId}", null);
                var projectResult = JsonSerializer.Deserialize<ProjectResponse>(await projectResponse.Content.ReadAsStringAsync());

                if (projectResult == null || projectResult.project.description == null) return returnValue;

                returnValue.Project = projectResult.project;

                var headlineResponse = await httpClient.PostAsync($"/headline/{(int)level}", new StringContent($"{returnValue.Project.description}. {returnValue.Project.benefits}"));
                var headline = JsonSerializer.Deserialize<ApiResponse>(await headlineResponse.Content.ReadAsStringAsync())?.Content;
                returnValue.GptResponse.Headline = headline ?? string.Empty;

                var subheadResponse = await httpClient.PostAsync($"/subhead", new StringContent($"{returnValue.Project.description}. {returnValue.Project.benefits}"));
                var subhead = JsonSerializer.Deserialize<ApiResponse>(await subheadResponse.Content.ReadAsStringAsync())?.Content;
                returnValue.GptResponse.Subhead = subhead ?? string.Empty;

                var imageResponse = await httpClient.PostAsync($"/image", new StringContent(returnValue.GptResponse.Headline));
                var content = await imageResponse.Content.ReadAsStringAsync();
                var image = JsonSerializer.Deserialize<ApiResponse>(content)?.Content;
                returnValue.GptResponse.ImageUrl = image ?? string.Empty;

                var tagResponse = await httpClient.PostAsync($"/tags", new StringContent($"{returnValue.Project.description}. {returnValue.Project.benefits}"));
                var tagContent = JsonSerializer.Deserialize<ApiResponse>(await tagResponse.Content.ReadAsStringAsync())?.Content;
                if (tagContent != null && tagContent.IndexOf(',') > 0 && !tagContent.Contains(NO_TAGS, StringComparison.CurrentCulture))
                {
                    returnValue.GptResponse.Keywords = tagContent.Split(',').Select(t => t.Trim()).ToArray();
                }

                return returnValue;
            });       
        }
    }
}
