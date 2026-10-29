using PostService.CommonTypes;
using PostService.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PostService.App
{
    public partial class PostView : Form
    {
        private int _id = -1;
        private readonly IPostServiceClient _postService;

        public PostView()
        {
            InitializeComponent();

            this.comboDeliveryType.DataSource = Enum.GetValues(typeof(DeliveryType));
        }

        internal PostView(IPostServiceClient postService) : this()
        {
            _postService = postService;
            this.Text = "Створення посилки";
            lblTitle.Text = "Нове відправлення";
            lblDescription.Text = "Заповніть інформацію про відправлення";
        }

        internal PostView(IPostServiceClient postService, int id) : this(postService)
        {
            _id = id;
            this.Text = "Редагувати посилку";
            lblTitle.Text = "Редагування відправлення";
            lblDescription.Text = "Змініть потрібні дані та збережіть їх";
            LoadPostingData(id);
        }
        internal PostView(IPostServiceClient postService, int id, bool isReadOnly) : this(postService, id)
        {
            if (isReadOnly)
            {
                this.Text = "Деталі посилки";
                lblTitle.Text = "Деталі відправлення";
                lblDescription.Text = "Інформація про вибране відправлення";

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox or ComboBox)
                    {
                        ctrl.Enabled = false;
                    }
                }

                if (btnSave != null)
                    btnSave.Visible = false;

                if (btnCancel != null)
                    btnCancel.Visible = false;
            }
        }

        private async void LoadPostingData(int id)
        {
            try
            {
                var p = await _postService.GetPostingByIdAsync(id);
                if (p != null)
                {
                    textBoxFrom.Text = p.From;
                    textBoxTo.Text = p.To;
                    textBoxContent.Text = p.Content;
                    comboDeliveryType.SelectedItem = p.DeliveryType;
                    textBoxWeight.Text = p.Weight.ToString();
                    textBoxPrice.Text = p.Value.ToString() ?? "";
                    textBoxCost.Text = p.Price.ToString() ?? "";

                    textBoxWidth.Text = p.Width.ToString();
                    textBoxHeight.Text = p.Height.ToString();
                    textBoxDepth.Text = p.Depth.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Помилка: {ex.Message}");
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void txtBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task<bool> SendPostRequest(DeliveryType dt, float w, float val, float width, float h, float d)
        {
            var dto = new PostingPostDTO();
            dto.From = textBoxFrom.Text;
            dto.To = textBoxTo.Text;
            dto.Content = textBoxContent.Text;
            dto.DeliveryType = dt;
            dto.Weight = w;
            dto.Value = val;
            dto.Width = width;
            dto.Height = h;
            dto.Depth = d;

            await _postService.CreatePostingAsync(dto);

            return true;
        }
        private async Task<bool> SendPutRequest(DeliveryType dt, float w, float val, float width, float h, float d)
        {
            var dto = new PostingPutDTO();
            dto.Id = _id;
            dto.From = textBoxFrom.Text;
            dto.To = textBoxTo.Text;
            dto.Content = textBoxContent.Text;
            dto.DeliveryType = dt;
            dto.Weight = w;
            dto.Value = val;
            dto.Width = width;
            dto.Height = h;
            dto.Depth = d;

            await _postService.UpdatePostingAsync(_id, dto);

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            var requiredFields = new[] { textBoxFrom, textBoxTo, textBoxContent, textBoxWeight, textBoxWidth, textBoxHeight, textBoxDepth };

            if (!Validate(requiredFields, textBoxWeight, textBoxWidth, textBoxHeight, textBoxDepth))
            {
                return;
            }

            float w = float.TryParse(textBoxWeight.Text, out var parsedW) ? parsedW : 0f;
            float val = float.TryParse(textBoxContent.Text, out var parsedV) ? parsedV : 0.0f;
            float width = float.TryParse(textBoxWidth.Text, out var parsedWd) ? parsedWd : 0f;
            float h = float.TryParse(textBoxHeight.Text, out var parsedH) ? parsedH : 0f;
            float d = float.TryParse(textBoxDepth.Text, out var parsedD) ? parsedD : 0f;
            float dlVl = float.TryParse(textBoxPrice.Text, out var parsedDlVl) ? parsedDlVl : 0f;

            var dt = comboDeliveryType.SelectedItem is DeliveryType dType ? dType : DeliveryType.Department;

            bool success = false;

            try
            {
                if (_id == -1)
                {
                    success = await SendPostRequest(dt, w, val, width, h, d);
                }
                else
                {
                    success = await SendPutRequest(dt, w, val, width, h, d);
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show(this, "Цей запис уже був видалений.",
                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == null)
            {
                var result = MessageBox.Show(
                    this,
                    "Сервер недоступний. Бажаєте повторити спробу?",
                    "Помилка мережі",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Retry)
                {
                    btnSave_Click(sender, e);
                }
            }
        }

        public static bool Validate(Control[] fields, TextBox textBoxWeight = null, TextBox textBoxWidth = null, TextBox textBoxHeight = null, TextBox textBoxDepth = null)
        {
            if (fields.Any(f => string.IsNullOrWhiteSpace(f.Text)))
            {
                MessageBox.Show("Заповніть усі обов'язкові поля, крім оголошеної вартості!",
                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxWeight != null && float.TryParse(textBoxWeight.Text, out float w) && w <= 0)
            {
                MessageBox.Show("Значення ваги має бути більшим за 0!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxWidth != null && float.TryParse(textBoxWidth.Text, out float wd) && wd <= 0)
            {
                MessageBox.Show("Значення ширини має бути більшим за 0!",
                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxHeight != null && float.TryParse(textBoxHeight.Text, out float h) && h <= 0)
            {
                MessageBox.Show("Значення висоти має бути більшим за 0!",
                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxDepth != null && float.TryParse(textBoxDepth.Text, out float d) && d <= 0)
            {
                MessageBox.Show("Значення глибини має бути більшим за 0!",
                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
