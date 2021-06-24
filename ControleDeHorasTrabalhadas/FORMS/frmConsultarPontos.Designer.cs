
namespace ControleDeHorasTrabalhadas.FORMS
{
    partial class frmConsultarPontos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.Movement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvResults);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONSULTA DE PONTOS";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToAddRows = false;
            this.gvResults.AllowUserToDeleteRows = false;
            this.gvResults.AllowUserToResizeColumns = false;
            this.gvResults.AllowUserToResizeRows = false;
            this.gvResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(53)))), ((int)(((byte)(90)))));
            this.gvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Movement,
            this.ds_status,
            this.localizacao});
            this.gvResults.Cursor = System.Windows.Forms.Cursors.Cross;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvResults.EnableHeadersVisualStyles = false;
            this.gvResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.gvResults.Location = new System.Drawing.Point(38, 95);
            this.gvResults.MultiSelect = false;
            this.gvResults.Name = "gvResults";
            this.gvResults.ReadOnly = true;
            this.gvResults.RowHeadersVisible = false;
            this.gvResults.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.gvResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResults.Size = new System.Drawing.Size(444, 178);
            this.gvResults.TabIndex = 14;
            this.gvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResults_CellContentClick);
            // 
            // Movement
            // 
            this.Movement.HeaderText = "DATA APONTADA";
            this.Movement.Name = "Movement";
            this.Movement.ReadOnly = true;
            this.Movement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Movement.Width = 170;
            // 
            // ds_status
            // 
            this.ds_status.HeaderText = "MOVIMENTO";
            this.ds_status.Name = "ds_status";
            this.ds_status.ReadOnly = true;
            this.ds_status.Width = 125;
            // 
            // localizacao
            // 
            this.localizacao.HeaderText = "LOCALIZAÇÃO";
            this.localizacao.Name = "localizacao";
            this.localizacao.ReadOnly = true;
            this.localizacao.Width = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "PONTOS REGISTRADOS :";
            // 
            // dtpData
            // 
            this.dtpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(332, 28);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(147, 29);
            this.dtpData.TabIndex = 2;
            this.dtpData.Value = new System.DateTime(2017, 10, 11, 0, 0, 0, 0);
            this.dtpData.Visible = false;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(506, 33);
            this.button4.TabIndex = 13;
            this.button4.Text = "SOLICITAR ALTERAÇÃO DO APONTAMENTO SELECIONADO";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmConsultarPontos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(53)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(530, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarPontos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultarPontos_FormClosing);
            this.Load += new System.EventHandler(this.frmConsultarPontos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn localizacao;
    }
}