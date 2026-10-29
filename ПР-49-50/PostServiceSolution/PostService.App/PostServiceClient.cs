using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PostService.Dtos;

namespace PostService.App
{
    internal class PostServiceClient : IPostServiceClient
    {
        private readonly HttpClient _httpClient;
        public PostServiceClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5001");
        }
        public async Task<PostingGetDto[]> GetPostingsAsync()
        {
            using var response = await _httpClient.GetAsync("/postings");
            await EnsureSuccessAsync(response);

            return await response.Content.ReadFromJsonAsync<PostingGetDto[]>();
        }
        public async Task<PostingGetDto> GetPostingByIdAsync(int id)
        {
            using var response = await _httpClient.GetAsync($"/postings/{id}");
            await EnsureSuccessAsync(response);

            return await response.Content.ReadFromJsonAsync<PostingGetDto>();
        }
        public async Task<PostingGetDto> CreatePostingAsync(PostingPostDTO posting)
        {
            using var response = await _httpClient.PostAsJsonAsync("/postings", posting);
            await EnsureSuccessAsync(response);

            return await response.Content.ReadFromJsonAsync<PostingGetDto>();
        }
        public async Task<PostingGetDto> UpdatePostingAsync(int id, PostingPutDTO posting)
        {
            using var response = await _httpClient.PutAsJsonAsync($"/postings/{id}", posting);
            await EnsureSuccessAsync(response);

            return await response.Content.ReadFromJsonAsync<PostingGetDto>();
        }
        public async Task DeletePostingAsync(int id)
        {
            using var response = await _httpClient.DeleteAsync($"/postings/{id}");
            await EnsureSuccessAsync(response);
        }

        private static async Task EnsureSuccessAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var problem = await response.Content.ReadFromJsonAsync<Exception>();
                throw new Exception(problem.Message);
            }

            throw new HttpRequestException(
                $"Сервер повернув помилку {(int)response.StatusCode}.",
                null,
                response.StatusCode);
        }
    }
}