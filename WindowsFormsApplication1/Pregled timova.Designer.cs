namespace WindowsFormsApplication1
{
    partial class Pregled_timova
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imeTimaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naslovAplikacijeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaOBJDataSet1 = new WindowsFormsApplication1.bazaOBJDataSet1();
            this.timTableAdapter = new WindowsFormsApplication1.bazaOBJDataSet1TableAdapters.TimTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaOBJDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(98, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 37);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pregled projekata";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Pregledaj Projekt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imeTimaDataGridViewTextBoxColumn,
            this.naslovAplikacijeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.timBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(33, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(398, 322);
            this.dataGridView1.TabIndex = 8;
            // 
            // imeTimaDataGridViewTextBoxColumn
            // 
            this.imeTimaDataGridViewTextBoxColumn.DataPropertyName = "imeTima";
            this.imeTimaDataGridViewTextBoxColumn.HeaderText = "imeTima";
            this.imeTimaDataGridViewTextBoxColumn.Name = "imeTimaDataGridViewTextBoxColumn";
            this.imeTimaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // naslovAplikacijeDataGridViewTextBoxColumn
            // 
            this.naslovAplikacijeDataGridViewTextBoxColumn.DataPropertyName = "naslovAplikacije";
            this.naslovAplikacijeDataGridViewTextBoxColumn.HeaderText = "naslovAplikacije";
            this.naslovAplikacijeDataGridViewTextBoxColumn.Name = "naslovAplikacijeDataGridViewTextBoxColumn";
            this.naslovAplikacijeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timBindingSource
            // 
            this.timBindingSource.DataMember = "Tim";
            this.timBindingSource.DataSource = this.bazaOBJDataSet1;
            // 
            // bazaOBJDataSet1
            // 
            this.bazaOBJDataSet1.DataSetName = "bazaOBJDataSet1";
            this.bazaOBJDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timTableAdapter
            // 
            this.timTableAdapter.ClearBeforeFill = true;
            // 
            // Pregled_timova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 457);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Name = "Pregled_timova";
            this.Text = "Pregled_timova";
            this.Load += new System.EventHandler(this.Pregled_timova_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaOBJDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private bazaOBJDataSet1 bazaOBJDataSet1;
        private System.Windows.Forms.BindingSource timBindingSource;
        private bazaOBJDataSet1TableAdapters.TimTableAdapter timTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeTimaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naslovAplikacijeDataGridViewTextBoxColumn;
    }
}