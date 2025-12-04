namespace Parcial_2
{
    partial class Conversor
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
            Cotización = new Label();
            Moneda_text = new TextBox();
            Convertir_a = new Label();
            Monedas_Dropdown = new ComboBox();
            Convertir_btn = new Button();
            dataGridView1 = new DataGridView();
            Monto = new DataGridViewTextBoxColumn();
            Moneda = new DataGridViewTextBoxColumn();
            MontosFinales = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Cotización
            // 
            Cotización.AutoSize = true;
            Cotización.Location = new Point(83, 64);
            Cotización.Name = "Cotización";
            Cotización.Size = new Size(63, 15);
            Cotización.TabIndex = 0;
            Cotización.Text = "Cotización";
            // 
            // Moneda_text
            // 
            Moneda_text.Location = new Point(152, 61);
            Moneda_text.Margin = new Padding(3, 2, 3, 2);
            Moneda_text.Name = "Moneda_text";
            Moneda_text.Size = new Size(87, 23);
            Moneda_text.TabIndex = 1;
            Moneda_text.TextChanged += Moneda_text_TextChanged;
            // 
            // Convertir_a
            // 
            Convertir_a.AutoSize = true;
            Convertir_a.Location = new Point(254, 64);
            Convertir_a.Name = "Convertir_a";
            Convertir_a.Size = new Size(68, 15);
            Convertir_a.TabIndex = 2;
            Convertir_a.Text = "Convertir a:";
            // 
            // Monedas_Dropdown
            // 
            Monedas_Dropdown.Cursor = Cursors.UpArrow;
            Monedas_Dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            Monedas_Dropdown.FormattingEnabled = true;
            Monedas_Dropdown.Items.AddRange(new object[] { "EUR", "USD", "COP" });
            Monedas_Dropdown.Location = new Point(328, 61);
            Monedas_Dropdown.Margin = new Padding(3, 2, 3, 2);
            Monedas_Dropdown.Name = "Monedas_Dropdown";
            Monedas_Dropdown.Size = new Size(133, 23);
            Monedas_Dropdown.TabIndex = 3;
            Monedas_Dropdown.SelectedIndexChanged += Monedas_Dropdown_SelectedIndexChanged;
            // 
            // Convertir_btn
            // 
            Convertir_btn.Location = new Point(492, 53);
            Convertir_btn.Margin = new Padding(3, 2, 3, 2);
            Convertir_btn.Name = "Convertir_btn";
            Convertir_btn.Size = new Size(94, 34);
            Convertir_btn.TabIndex = 4;
            Convertir_btn.Text = "Convertir";
            Convertir_btn.UseVisualStyleBackColor = true;
            Convertir_btn.Click += Convertir_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Monto, Moneda, MontosFinales });
            dataGridView1.Location = new Point(162, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(343, 219);
            dataGridView1.TabIndex = 5;
            // 
            // Monto
            // 
            Monto.HeaderText = "Montos";
            Monto.Name = "Monto";
            Monto.ReadOnly = true;
            // 
            // Moneda
            // 
            Moneda.HeaderText = "Monedas";
            Moneda.Name = "Moneda";
            Moneda.ReadOnly = true;
            // 
            // MontosFinales
            // 
            MontosFinales.HeaderText = "Monto Convertido";
            MontosFinales.Name = "MontosFinales";
            MontosFinales.ReadOnly = true;
            // 
            // Conversor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(dataGridView1);
            Controls.Add(Convertir_btn);
            Controls.Add(Monedas_Dropdown);
            Controls.Add(Convertir_a);
            Controls.Add(Moneda_text);
            Controls.Add(Cotización);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Conversor";
            Text = "Conversor";
            Load += Conversor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Cotización;
        private TextBox Moneda_text;
        private Label Convertir_a;
        private ComboBox Monedas_Dropdown;
        private Button Convertir_btn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Moneda;
        private DataGridViewTextBoxColumn MontosFinales;
        private DataGridViewTextBoxColumn Monto;
    }
}
