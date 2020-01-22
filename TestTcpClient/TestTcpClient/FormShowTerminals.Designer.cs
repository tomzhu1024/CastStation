namespace TestTcpClient
{
    partial class FormShowTerminals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowTerminals));
            this.txtBig = new System.Windows.Forms.TextBox();
            this.btnGetTerms = new System.Windows.Forms.Button();
            this.txtSmall = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBig
            // 
            this.txtBig.Location = new System.Drawing.Point(12, 12);
            this.txtBig.Multiline = true;
            this.txtBig.Name = "txtBig";
            this.txtBig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBig.Size = new System.Drawing.Size(436, 363);
            this.txtBig.TabIndex = 4;
            // 
            // btnGetTerms
            // 
            this.btnGetTerms.Location = new System.Drawing.Point(341, 381);
            this.btnGetTerms.Name = "btnGetTerms";
            this.btnGetTerms.Size = new System.Drawing.Size(107, 23);
            this.btnGetTerms.TabIndex = 3;
            this.btnGetTerms.Text = "Refresh List";
            this.btnGetTerms.UseVisualStyleBackColor = true;
            this.btnGetTerms.Click += new System.EventHandler(this.btnGetTerms_Click);
            // 
            // txtSmall
            // 
            this.txtSmall.Location = new System.Drawing.Point(13, 382);
            this.txtSmall.Name = "txtSmall";
            this.txtSmall.Size = new System.Drawing.Size(241, 21);
            this.txtSmall.TabIndex = 1;
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.Location = new System.Drawing.Point(260, 381);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Set";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // FormShowTerminals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 414);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtSmall);
            this.Controls.Add(this.btnGetTerms);
            this.Controls.Add(this.txtBig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowTerminals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Terminals List";
            this.Load += new System.EventHandler(this.FormShowTerminals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBig;
        private System.Windows.Forms.Button btnGetTerms;
        private System.Windows.Forms.TextBox txtSmall;
        private System.Windows.Forms.Button btnFinish;
    }
}