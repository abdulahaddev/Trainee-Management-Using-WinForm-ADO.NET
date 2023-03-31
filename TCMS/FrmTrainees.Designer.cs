
namespace TCMS
{
    partial class FrmTrainees
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTrainees = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(974, 437);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnTrainees
            // 
            this.btnTrainees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(113)))), ((int)(((byte)(211)))));
            this.btnTrainees.FlatAppearance.BorderSize = 0;
            this.btnTrainees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainees.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainees.ForeColor = System.Drawing.Color.White;
            this.btnTrainees.Image = global::TCMS.Properties.Resources.addTrainee;
            this.btnTrainees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainees.Location = new System.Drawing.Point(790, 24);
            this.btnTrainees.Name = "btnTrainees";
            this.btnTrainees.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTrainees.Size = new System.Drawing.Size(172, 52);
            this.btnTrainees.TabIndex = 3;
            this.btnTrainees.Text = "   Add Trainee";
            this.btnTrainees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrainees.UseVisualStyleBackColor = false;
            this.btnTrainees.Click += new System.EventHandler(this.btnTrainees_Click);
            // 
            // FrmTrainees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 519);
            this.Controls.Add(this.btnTrainees);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTrainees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTrainees";
            this.Load += new System.EventHandler(this.FrmTrainees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTrainees;
    }
}