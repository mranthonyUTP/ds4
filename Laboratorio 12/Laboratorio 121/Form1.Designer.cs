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
            Grade1_text = new Label();
            Solve_btn = new Button();
            Reset_btn = new Button();
            exit_btn = new Button();
            Grade2_text = new Label();
            Grade3_text = new Label();
            Final_grade = new Label();
            Final = new Label();
            // Replace this line:
            // grade2 = new TextBox();

            // With this line:

            Grade2 = new TextBox();
            Grade1_box = new TextBox();
            Grade3 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // Grade1_text
            // 
            Grade1_text.AutoSize = true;
            Grade1_text.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade1_text.Location = new Point(276, 110);
            Grade1_text.Name = "Grade1_text";
            Grade1_text.Size = new Size(127, 20);
            Grade1_text.TabIndex = 0;
            Grade1_text.Text = "Calificación NO.1:";
            Grade1_text.Click += Grade1_text_Click;
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
            // Grade2_text
            // 
            Grade2_text.AutoSize = true;
            Grade2_text.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade2_text.Location = new Point(276, 162);
            Grade2_text.Name = "Grade2_text";
            Grade2_text.Size = new Size(129, 20);
            Grade2_text.TabIndex = 5;
            Grade2_text.Text = "Calificación NO.2:";
            // 
            // Grade3_text
            // 
            Grade3_text.AutoSize = true;
            Grade3_text.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Grade3_text.Location = new Point(276, 212);
            Grade3_text.Name = "Grade3_text";
            Grade3_text.Size = new Size(129, 20);
            Grade3_text.TabIndex = 7;
            Grade3_text.Text = "Calificación NO.3:";
            Grade3_text.Click += label5_Click;
            // 
            // Final_grade
            // 
            Final_grade.AutoSize = true;
            Final_grade.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Final_grade.Location = new Point(276, 279);
            Final_grade.Name = "Final_grade";
            Final_grade.Size = new Size(128, 20);
            Final_grade.TabIndex = 10;
            Final_grade.Text = "Calificación Final:";
            Final_grade.Click += label7_Click;
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
            // Grade2
            // 
            Grade2.Cursor = Cursors.IBeam;
            Grade2.Location = new Point(409, 159);
            Grade2.Name = "Grade2";
            Grade2.Size = new Size(83, 27);
            Grade2.TabIndex = 11;
            Grade2.TextChanged += Grade2_TextChanged;
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
            // Grade3
            // 
            Grade3.Cursor = Cursors.IBeam;
            Grade3.Location = new Point(409, 209);
            Grade3.Name = "Grade3";
            Grade3.Size = new Size(83, 27);
            Grade3.TabIndex = 11;
            Grade3.TextChanged += Grade3_TextChanged;
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
            Controls.Add(Grade3);
            Controls.Add(Grade1_box);
            Controls.Add(Grade2);
            Controls.Add(Final_grade);
            Controls.Add(Final);
            Controls.Add(Grade3_text);
            Controls.Add(Grade2_text);
            Controls.Add(exit_btn);
            Controls.Add(Reset_btn);
            Controls.Add(Solve_btn);
            Controls.Add(Grade1_text);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Grade1_text;
        private Button Solve_btn;
        private Button Reset_btn;
        private Button exit_btn;
        private Label label2;
        private Label Grade2_text;
        private Label label4;
        private Label Grade3_text;
        private Label label6;
        private Label Final_grade;
        private Label Final;
        private TextBox Grade2;
        private TextBox Grade1_box;
        private TextBox Grade3;
        private Label label1;
    }
}
