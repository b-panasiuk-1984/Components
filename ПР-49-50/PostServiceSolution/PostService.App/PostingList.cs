using PostService.Dtos;
using System.Net.Http.Json;

namespace PostService.App
{
    public partial class PostService : Form
    {
        private readonly IPostServiceClient _postService = new PostServiceClient();
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

        // delete button click event
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridPostings.CurrentRow?.DataBoundItem is not PostingGetDto selectedPosting)
            {
                MessageBox.Show("Виберіть відправлення, яке потрібно видалити.");
                return;
            }

            var response = await _httpClient.DeleteAsync($"postings/{selectedPosting.Id}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(
                    $"Не вдалося видалити відправлення. Сервер повернув статус {(int)response.StatusCode}.");
            }
            else
                MessageBox.Show($"Помилка {selectedPosting.Id}"); 
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            using (var dlg = new PostView(_postService))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    await Task.Delay(100);
                    await LoadPostingsAsync();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (gridPostings.CurrentRow?.DataBoundItem is not PostingGetDto selectedPosting)
            {
                MessageBox.Show(this, "Помилка.");
                return;
            }
            using var dlg = new PostView(_postService, selectedPosting.Id, isReadOnly: true);
            dlg.ShowDialog();
        }

        // edit button click event
        private async void btnEditClick(object sender, EventArgs e)
        {
            if (gridPostings.CurrentRow?.DataBoundItem is not PostingGetDto selectedPosting)
            {
                MessageBox.Show(this, "Помилка.");
                return;
            }
            using (var dlg = new PostView(_postService, selectedPosting.Id))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    await Task.Delay(100);
                    await LoadPostingsAsync();
                }
            }
        }
    }
}
