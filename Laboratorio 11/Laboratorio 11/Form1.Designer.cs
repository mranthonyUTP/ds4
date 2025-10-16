namespace Laboratorio_11
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
            this.buttonSaludo = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaludo
            // 
            this.buttonSaludo.AutoSize = true;
            this.buttonSaludo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonSaludo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaludo.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonSaludo.FlatAppearance.BorderSize = 2;
            this.buttonSaludo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaludo.ForeColor = System.Drawing.Color.White;
            this.buttonSaludo.Location = new System.Drawing.Point(344, 194);
            this.buttonSaludo.Name = "buttonSaludo";
            this.buttonSaludo.Size = new System.Drawing.Size(128, 48);
            this.buttonSaludo.TabIndex = 0;
            this.buttonSaludo.Text = "Say Hello";
            this.buttonSaludo.UseVisualStyleBackColor = false;
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(394, 275);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(0, 16);
            this.lblHelloWorld.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 548);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.buttonSaludo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaludo;
        private System.Windows.Forms.Label lblHelloWorld;
    }
}

