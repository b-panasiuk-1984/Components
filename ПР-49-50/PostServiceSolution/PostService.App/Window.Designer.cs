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
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)gridPostings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)postingGetDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gridPostings
            // 
            gridPostings.AllowUserToAddRows = false;
            gridPostings.AllowUserToDeleteRows = false;
            gridPostings.AutoGenerateColumns = false;
            gridPostings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPostings.Columns.AddRange(new DataGridViewColumn[] { From, To, Content, DeliveryType, Weight, Width, Height, Depth, Value, Price, CreatedAt });
            gridPostings.DataSource = postingGetDtoBindingSource;
            gridPostings.Location = new Point(12, 52);
            gridPostings.MultiSelect = false;
            gridPostings.Name = "gridPostings";
            gridPostings.ReadOnly = true;
            gridPostings.RowHeadersWidth = 62;
            gridPostings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPostings.Size = new Size(1564, 311);
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
            From.Width = 150;
            // 
            // To
            // 
            To.DataPropertyName = "To";
            To.HeaderText = "Куди";
            To.MinimumWidth = 8;
            To.Name = "To";
            To.ReadOnly = true;
            To.Width = 150;
            // 
            // Content
            // 
            Content.DataPropertyName = "Content";
            Content.HeaderText = "Контент";
            Content.MinimumWidth = 8;
            Content.Name = "Content";
            Content.ReadOnly = true;
            Content.Width = 150;
            // 
            // DeliveryType
            // 
            DeliveryType.DataPropertyName = "DeliveryType";
            DeliveryType.HeaderText = "Тип";
            DeliveryType.MinimumWidth = 8;
            DeliveryType.Name = "DeliveryType";
            DeliveryType.ReadOnly = true;
            DeliveryType.Width = 150;
            // 
            // Weight
            // 
            Weight.DataPropertyName = "Weight";
            Weight.HeaderText = "Вага";
            Weight.MinimumWidth = 8;
            Weight.Name = "Weight";
            Weight.ReadOnly = true;
            Weight.Width = 150;
            // 
            // Width
            // 
            Width.DataPropertyName = "Width";
            Width.HeaderText = "Ширина";
            Width.MinimumWidth = 8;
            Width.Name = "Width";
            Width.ReadOnly = true;
            Width.Width = 150;
            // 
            // Height
            // 
            Height.DataPropertyName = "Height";
            Height.HeaderText = "Висота";
            Height.MinimumWidth = 8;
            Height.Name = "Height";
            Height.ReadOnly = true;
            Height.Width = 150;
            // 
            // Depth
            // 
            Depth.DataPropertyName = "Depth";
            Depth.HeaderText = "Глибина";
            Depth.MinimumWidth = 8;
            Depth.Name = "Depth";
            Depth.ReadOnly = true;
            Depth.Width = 150;
            // 
            // Value
            // 
            Value.DataPropertyName = "Value";
            Value.HeaderText = "Вартість";
            Value.MinimumWidth = 8;
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.Width = 150;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Ціна";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 150;
            // 
            // CreatedAt
            // 
            CreatedAt.DataPropertyName = "CreatedAt";
            CreatedAt.HeaderText = "Дата";
            CreatedAt.MinimumWidth = 8;
            CreatedAt.Name = "CreatedAt";
            CreatedAt.ReadOnly = true;
            CreatedAt.Visible = false;
            CreatedAt.Width = 150;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Оновити";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(130, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // PostService
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1588, 376);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(gridPostings);
            Name = "PostService";
            Text = "Window";
            Load += PostingList_Load;
            ((System.ComponentModel.ISupportInitialize)gridPostings).EndInit();
            ((System.ComponentModel.ISupportInitialize)postingGetDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridPostings;
        private Button btnUpdate;
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
    }
}
