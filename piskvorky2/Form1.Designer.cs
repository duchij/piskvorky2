namespace piskvorky2
{
    partial class Form1
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
            this.gv_gameField = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gv_gameField)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_gameField
            // 
            this.gv_gameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_gameField.ColumnHeadersVisible = false;
            this.gv_gameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_gameField.Location = new System.Drawing.Point(0, 0);
            this.gv_gameField.MultiSelect = false;
            this.gv_gameField.Name = "gv_gameField";
            this.gv_gameField.ReadOnly = true;
            this.gv_gameField.RowHeadersVisible = false;
            this.gv_gameField.RowHeadersWidth = 10;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gv_gameField.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_gameField.Size = new System.Drawing.Size(297, 311);
            this.gv_gameField.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 311);
            this.Controls.Add(this.gv_gameField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_gameField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_gameField;
    }
}

