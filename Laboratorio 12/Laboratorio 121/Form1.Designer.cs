namespace Laboratorio_121
{
    partial class Form1
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
            Grade1_text_lbl = new Label();
            Solve_btn = new Button();
            Reset_btn = new Button();
            exit_btn = new Button();
            Grade2_text_lbl = new Label();
            Grade3_text_lbl = new Label();
            Final_grade_lbl = new Label();
            Final = new Label();
            Grade2_box = new TextBox();
            Grade1_box = new TextBox();
            Grade3_box = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // Grade1_text_lbl
            // 
            Grade1_text_lbl.AutoSize = true;
            Grade1_text_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade1_text_lbl.Location = new Point(276, 110);
            Grade1_text_lbl.Name = "Grade1_text_lbl";
            Grade1_text_lbl.Size = new Size(127, 20);
            Grade1_text_lbl.TabIndex = 0;
            Grade1_text_lbl.Text = "Calificación NO.1:";
            Grade1_text_lbl.Click += Grade1_text_Click;
            // 
            // Solve_btn
            // 
            Solve_btn.Cursor = Cursors.Hand;
            Solve_btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Solve_btn.Location = new Point(276, 341);
            Solve_btn.Name = "Solve_btn";
            Solve_btn.Size = new Size(216, 50);
            Solve_btn.TabIndex = 1;
            Solve_btn.Text = "Calcular";
            Solve_btn.UseVisualStyleBackColor = true;
            Solve_btn.Click += Solve_btn_Click;
            // 
            // Reset_btn
            // 
            Reset_btn.BackColor = Color.FromArgb(192, 192, 255);
            Reset_btn.Cursor = Cursors.Hand;
            Reset_btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Reset_btn.Location = new Point(12, 398);
            Reset_btn.Name = "Reset_btn";
            Reset_btn.Size = new Size(103, 40);
            Reset_btn.TabIndex = 2;
            Reset_btn.Text = "Reset";
            Reset_btn.UseVisualStyleBackColor = false;
            Reset_btn.Click += button2_Click;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Firebrick;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit_btn.ForeColor = Color.White;
            exit_btn.Location = new Point(685, 398);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(103, 40);
            exit_btn.TabIndex = 3;
            exit_btn.Text = "Salir";
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.Click += button3_Click;
            // 
            // Grade2_text_lbl
            // 
            Grade2_text_lbl.AutoSize = true;
            Grade2_text_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade2_text_lbl.Location = new Point(276, 162);
            Grade2_text_lbl.Name = "Grade2_text_lbl";
            Grade2_text_lbl.Size = new Size(129, 20);
            Grade2_text_lbl.TabIndex = 5;
            Grade2_text_lbl.Text = "Calificación NO.2:";
            // 
            // Grade3_text_lbl
            // 
            Grade3_text_lbl.AutoSize = true;
            Grade3_text_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade3_text_lbl.Location = new Point(276, 212);
            Grade3_text_lbl.Name = "Grade3_text_lbl";
            Grade3_text_lbl.Size = new Size(129, 20);
            Grade3_text_lbl.TabIndex = 7;
            Grade3_text_lbl.Text = "Calificación NO.3:";
            Grade3_text_lbl.Click += label5_Click;
            // 
            // Final_grade_lbl
            // 
            Final_grade_lbl.AutoSize = true;
            Final_grade_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Final_grade_lbl.Location = new Point(276, 279);
            Final_grade_lbl.Name = "Final_grade_lbl";
            Final_grade_lbl.Size = new Size(128, 20);
            Final_grade_lbl.TabIndex = 10;
            Final_grade_lbl.Text = "Calificación Final:";
            Final_grade_lbl.Click += label7_Click;
            // 
            // Final
            // 
            Final.AutoSize = true;
            Final.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Final.Location = new Point(442, 279);
            Final.Name = "Final";
            Final.Size = new Size(0, 20);
            Final.TabIndex = 9;
            Final.Click += Final_Click;
            // 
            // Grade2_box
            // 
            Grade2_box.Cursor = Cursors.IBeam;
            Grade2_box.Location = new Point(409, 159);
            Grade2_box.Name = "Grade2_box";
            Grade2_box.Size = new Size(83, 27);
            Grade2_box.TabIndex = 11;
            Grade2_box.TextChanged += Grade2_TextChanged;
            // 
            // Grade1_box
            // 
            Grade1_box.Cursor = Cursors.IBeam;
            Grade1_box.Location = new Point(409, 107);
            Grade1_box.Name = "Grade1_box";
            Grade1_box.Size = new Size(83, 27);
            Grade1_box.TabIndex = 11;
            Grade1_box.TextChanged += Grade1_TextChanged;
            // 
            // Grade3_box
            // 
            Grade3_box.Cursor = Cursors.IBeam;
            Grade3_box.Location = new Point(409, 209);
            Grade3_box.Name = "Grade3_box";
            Grade3_box.Size = new Size(83, 27);
            Grade3_box.TabIndex = 11;
            Grade3_box.TextChanged += Grade3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(183, 37);
            label1.Name = "label1";
            label1.Size = new Size(422, 31);
            label1.TabIndex = 12;
            label1.Text = "Calculadora de Promedios con 3 notas";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(Grade3_box);
            Controls.Add(Grade1_box);
            Controls.Add(Grade2_box);
            Controls.Add(Final_grade_lbl);
            Controls.Add(Final);
            Controls.Add(Grade3_text_lbl);
            Controls.Add(Grade2_text_lbl);
            Controls.Add(exit_btn);
            Controls.Add(Reset_btn);
            Controls.Add(Solve_btn);
            Controls.Add(Grade1_text_lbl);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Grade1_text_lbl;
        private Button Solve_btn;
        private Button Reset_btn;
        private Button exit_btn;
        private Label label2;
        private Label Grade2_text_lbl;
        private Label label4;
        private Label Grade3_text_lbl;
        private Label label6;
        private Label Final_grade_lbl;
        private Label Final;
        private TextBox Grade2_box;
        private TextBox Grade1_box;
        private TextBox Grade3_box;
        private Label label1;
    }
}
