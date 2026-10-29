using PostService.Dtos;
using System.Net.Http.Json;

namespace PostService.App
{
    public partial class PostService : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7225/")
        };

        public PostService()
        {
            InitializeComponent();

            gridPostings.AutoGenerateColumns = false;
        }

        private async Task LoadPostingsAsync()
        {
            try
            {
                var postings = await _httpClient.GetFromJsonAsync<PostingGetDto[]>("postings");
                gridPostings.DataSource = postings;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message + ": Не вдалося отримати дані з сервера. Перевірте, чи запущено PostService.");
            }
        }

        private async void PostingList_Load(object? sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // update button click event
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await LoadPostingsAsync();
        }

        // delete button click event
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridPostings.CurrentRow?.DataBoundItem is not PostingGetDto selectedPosting)
            {
                MessageBox.Show("Ви маєте обрати запис для видалення");
                return;
            }

            var response = await _httpClient.DeleteAsync($"postings/{selectedPosting.Id}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(
                    $"Не вдалося видалити відправлення. Сервер повернув статус {(int)response.StatusCode}.");
            }
        }
    }
}
