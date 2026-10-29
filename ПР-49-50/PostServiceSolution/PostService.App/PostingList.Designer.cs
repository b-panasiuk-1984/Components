using PostService.Dtos;

namespace PostService.App
{
    partial class PostService
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridPostings = new DataGridView();
            From = new DataGridViewTextBoxColumn();
            To = new DataGridViewTextBoxColumn();
            Content = new DataGridViewTextBoxColumn();
            DeliveryType = new DataGridViewTextBoxColumn();
            Weight = new DataGridViewTextBoxColumn();
            Width = new DataGridViewTextBoxColumn();
            Height = new DataGridViewTextBoxColumn();
            Depth = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            CreatedAt = new DataGridViewTextBoxColumn();
            postingGetDtoBindingSource = new BindingSource(components);
            lblTitle = new Label();
            lblDescription = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
            btnCreate = new Button();
            btnDetails = new Button();
            ((System.ComponentModel.ISupportInitialize)gridPostings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)postingGetDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gridPostings
            // 
            gridPostings.AllowUserToAddRows = false;
            gridPostings.AllowUserToDeleteRows = false;
            gridPostings.AllowUserToResizeRows = false;
            gridPostings.AutoGenerateColumns = false;
            gridPostings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPostings.BackgroundColor = Color.White;
            gridPostings.BorderStyle = BorderStyle.None;
            gridPostings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridPostings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridPostings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 52, 82);
            gridPostings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridPostings.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 52, 82);
            gridPostings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridPostings.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridPostings.ColumnHeadersHeight = 44;
            gridPostings.Columns.AddRange(new DataGridViewColumn[] { From, To, Content, DeliveryType, Weight, Width, Height, Depth, Value, Price, CreatedAt });
            gridPostings.DataSource = postingGetDtoBindingSource;
            gridPostings.DefaultCellStyle.BackColor = Color.White;
            gridPostings.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            gridPostings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            gridPostings.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 95);
            gridPostings.DefaultCellStyle.Padding = new Padding(8, 0, 4, 0);
            gridPostings.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            gridPostings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 249, 253);
            gridPostings.EnableHeadersVisualStyles = false;
            gridPostings.GridColor = Color.FromArgb(229, 234, 241);
            gridPostings.Location = new Point(24, 112);
            gridPostings.MultiSelect = false;
            gridPostings.Name = "gridPostings";
            gridPostings.ReadOnly = true;
            gridPostings.RowHeadersVisible = false;
            gridPostings.RowTemplate.Height = 40;
            gridPostings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPostings.Size = new Size(1312, 568);
            gridPostings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPostings.TabIndex = 0;
            gridPostings.CellContentClick += dataGridView1_CellContentClick;
            // 
            // From
            // 
            From.DataPropertyName = "From";
            From.HeaderText = "Звідки";
            From.MinimumWidth = 8;
            From.Name = "From";
            From.ReadOnly = true;
            From.FillWeight = 105F;
            // 
            // To
            // 
            To.DataPropertyName = "To";
            To.HeaderText = "Куди";
            To.MinimumWidth = 8;
            To.Name = "To";
            To.ReadOnly = true;
            To.FillWeight = 105F;
            // 
            // Content
            // 
            Content.DataPropertyName = "Content";
            Content.HeaderText = "Повідомленя";
            Content.MinimumWidth = 8;
            Content.Name = "Content";
            Content.ReadOnly = true;
            Content.FillWeight = 140F;
            // 
            // DeliveryType
            // 
            DeliveryType.DataPropertyName = "DeliveryType";
            DeliveryType.HeaderText = "Тип";
            DeliveryType.MinimumWidth = 8;
            DeliveryType.Name = "DeliveryType";
            DeliveryType.ReadOnly = true;
            DeliveryType.FillWeight = 90F;
            // 
            // Weight
            // 
            Weight.DataPropertyName = "Weight";
            Weight.HeaderText = "Вага";
            Weight.MinimumWidth = 8;
            Weight.Name = "Weight";
            Weight.ReadOnly = true;
            Weight.FillWeight = 75F;
            // 
            // Width
            // 
            Width.DataPropertyName = "Width";
            Width.HeaderText = "Ширина";
            Width.MinimumWidth = 8;
            Width.Name = "Width";
            Width.ReadOnly = true;
            Width.FillWeight = 75F;
            // 
            // Height
            // 
            Height.DataPropertyName = "Height";
            Height.HeaderText = "Висота";
            Height.MinimumWidth = 8;
            Height.Name = "Height";
            Height.ReadOnly = true;
            Height.FillWeight = 75F;
            // 
            // Depth
            // 
            Depth.DataPropertyName = "Depth";
            Depth.HeaderText = "Глибина";
            Depth.MinimumWidth = 8;
            Depth.Name = "Depth";
            Depth.ReadOnly = true;
            Depth.FillWeight = 75F;
            // 
            // Value
            // 
            Value.DataPropertyName = "Value";
            Value.HeaderText = "Вартість";
            Value.MinimumWidth = 8;
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.FillWeight = 85F;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Ціна";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.FillWeight = 85F;
            // 
            // CreatedAt
            // 
            CreatedAt.DataPropertyName = "CreatedAt";
            CreatedAt.HeaderText = "Дата";
            CreatedAt.MinimumWidth = 8;
            CreatedAt.Name = "CreatedAt";
            CreatedAt.ReadOnly = true;
            CreatedAt.Visible = false;
            CreatedAt.FillWeight = 100F;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 52, 82);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Відправлення";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.ForeColor = Color.FromArgb(104, 116, 133);
            lblDescription.Location = new Point(27, 68);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(260, 20);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Перегляд та керування відправленнями";
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(37, 99, 235);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(988, 31);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(104, 40);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Редагувати";
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += btnEditClick;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1220, 31);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Видалити";
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(22, 163, 74);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(872, 31);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(104, 40);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Створити";
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDetails
            // 
            btnDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetails.BackColor = Color.FromArgb(71, 85, 105);
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.ForeColor = Color.White;
            btnDetails.Location = new Point(1104, 31);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(104, 40);
            btnDetails.TabIndex = 6;
            btnDetails.Text = "Дивитись";
            btnDetails.Cursor = Cursors.Hand;
            btnDetails.Click += btnDetails_Click;
            // 
            // PostService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1360, 720);
            MinimumSize = new Size(1120, 560);
            Controls.Add(btnDetails);
            Controls.Add(btnCreate);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(gridPostings);
            Name = "PostService";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Керування відправленнями";
            Load += PostingList_Load;
            ((System.ComponentModel.ISupportInitialize)gridPostings).EndInit();
            ((System.ComponentModel.ISupportInitialize)postingGetDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridPostings;
        private Label lblTitle;
        private Label lblDescription;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn depthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private BindingSource postingGetDtoBindingSource;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn To;
        private DataGridViewTextBoxColumn Content;
        private DataGridViewTextBoxColumn DeliveryType;
        private DataGridViewTextBoxColumn Weight;
        private DataGridViewTextBoxColumn Width;
        private DataGridViewTextBoxColumn Height;
        private DataGridViewTextBoxColumn Depth;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn CreatedAt;
        private Button btnCreate;
        private Button btnDetails;
    }
}
