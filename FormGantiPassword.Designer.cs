namespace AppKasir
{
    partial class FormGantiPassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKonfirPwBaru = new System.Windows.Forms.TextBox();
            this.txtPwBaru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwLama = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGanti = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(120, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Password Baru";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(120, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "Konfirmasi Password Baru";
            // 
            // txtKonfirPwBaru
            // 
            this.txtKonfirPwBaru.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKonfirPwBaru.Enabled = false;
            this.txtKonfirPwBaru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(140)))), ((int)(((byte)(197)))));
            this.txtKonfirPwBaru.Location = new System.Drawing.Point(277, 198);
            this.txtKonfirPwBaru.Name = "txtKonfirPwBaru";
            this.txtKonfirPwBaru.Size = new System.Drawing.Size(194, 20);
            this.txtKonfirPwBaru.TabIndex = 27;
            this.txtKonfirPwBaru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKonfirPwBaru_KeyDown);
            // 
            // txtPwBaru
            // 
            this.txtPwBaru.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPwBaru.Enabled = false;
            this.txtPwBaru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(140)))), ((int)(((byte)(197)))));
            this.txtPwBaru.Location = new System.Drawing.Point(277, 172);
            this.txtPwBaru.Name = "txtPwBaru";
            this.txtPwBaru.Size = new System.Drawing.Size(194, 20);
            this.txtPwBaru.TabIndex = 26;
            this.txtPwBaru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwBaru_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(120, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Password Lama";
            // 
            // txtPwLama
            // 
            this.txtPwLama.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPwLama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(140)))), ((int)(((byte)(197)))));
            this.txtPwLama.Location = new System.Drawing.Point(277, 125);
            this.txtPwLama.Name = "txtPwLama";
            this.txtPwLama.Size = new System.Drawing.Size(194, 20);
            this.txtPwLama.TabIndex = 30;
            this.txtPwLama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwLama_KeyPress);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(140)))), ((int)(((byte)(197)))));
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(584, 40);
            this.panel6.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Form Ganti Password";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::AppKasir.Properties.Resources.close15px;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(554, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 19;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGanti
            // 
            this.btnGanti.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGanti.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGanti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(77)))), ((int)(((byte)(104)))));
            this.btnGanti.Location = new System.Drawing.Point(123, 255);
            this.btnGanti.Name = "btnGanti";
            this.btnGanti.Size = new System.Drawing.Size(348, 32);
            this.btnGanti.TabIndex = 33;
            this.btnGanti.Text = "GANTI PASSWORD";
            this.btnGanti.UseVisualStyleBackColor = false;
            this.btnGanti.Click += new System.EventHandler(this.btnGanti_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.Location = new System.Drawing.Point(363, 224);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 19);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Hide Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormGantiPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(77)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnGanti);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwLama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKonfirPwBaru);
            this.Controls.Add(this.txtPwBaru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGantiPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGantiPassword";
            this.Load += new System.EventHandler(this.FormGantiPassword_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKonfirPwBaru;
        private System.Windows.Forms.TextBox txtPwBaru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwLama;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGanti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}