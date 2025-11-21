namespace Laboratorio_14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_Add = new Button();
            btn_Save = new Button();
            btn_Cancel = new Button();
            btn_Delete = new Button();
            btn_Search = new Button();
            search_bar = new TextBox();
            label1 = new Label();
            id_TBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            productName_TBox = new TextBox();
            label4 = new Label();
            price_TBox = new TextBox();
            label5 = new Label();
            stock_TBox = new TextBox();
            btn_Exit = new Button();
            SuspendLayout();
            // 
            // btn_Add
            // 
            btn_Add.BackgroundImage = (Image)resources.GetObject("btn_Add.BackgroundImage");
            btn_Add.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Add.FlatAppearance.BorderColor = Color.White;
            btn_Add.FlatAppearance.BorderSize = 0;
            btn_Add.FlatAppearance.MouseDownBackColor = Color.White;
            btn_Add.Location = new Point(12, 12);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(35, 35);
            btn_Add.TabIndex = 0;
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // btn_Save
            // 
            btn_Save.AccessibleDescription = "Save";
            btn_Save.BackgroundImage = (Image)resources.GetObject("btn_Save.BackgroundImage");
            btn_Save.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Save.FlatAppearance.BorderColor = Color.White;
            btn_Save.FlatAppearance.BorderSize = 0;
            btn_Save.FlatAppearance.MouseDownBackColor = Color.White;
            btn_Save.Location = new Point(53, 12);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(35, 35);
            btn_Save.TabIndex = 1;
            btn_Save.Tag = "";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BackgroundImage = (Image)resources.GetObject("btn_Cancel.BackgroundImage");
            btn_Cancel.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Cancel.FlatAppearance.BorderColor = Color.White;
            btn_Cancel.FlatAppearance.BorderSize = 0;
            btn_Cancel.FlatAppearance.MouseDownBackColor = Color.White;
            btn_Cancel.Location = new Point(94, 12);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(35, 35);
            btn_Cancel.TabIndex = 2;
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.BackgroundImage = (Image)resources.GetObject("btn_Delete.BackgroundImage");
            btn_Delete.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Delete.FlatAppearance.BorderColor = Color.White;
            btn_Delete.FlatAppearance.BorderSize = 0;
            btn_Delete.FlatAppearance.MouseDownBackColor = Color.White;
            btn_Delete.Location = new Point(135, 12);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(35, 35);
            btn_Delete.TabIndex = 3;
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // btn_Search
            // 
            btn_Search.BackgroundImage = (Image)resources.GetObject("btn_Search.BackgroundImage");
            btn_Search.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Search.FlatAppearance.BorderColor = Color.White;
            btn_Search.FlatAppearance.BorderSize = 0;
            btn_Search.FlatAppearance.MouseDownBackColor = Color.White;
            btn_Search.Location = new Point(736, 16);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(26, 27);
            btn_Search.TabIndex = 4;
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += btn_Search_Click;
            // 
            // search_bar
            // 
            search_bar.Location = new Point(592, 16);
            search_bar.Name = "search_bar";
            search_bar.Size = new Size(138, 27);
            search_bar.TabIndex = 5;
            search_bar.TextChanged += search_bar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(488, 19);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 6;
            label1.Text = "Buscar por ID:";
            // 
            // id_TBox
            // 
            id_TBox.Location = new Point(32, 136);
            id_TBox.Name = "id_TBox";
            id_TBox.Size = new Size(56, 27);
            id_TBox.TabIndex = 7;
            id_TBox.TextChanged += id_TBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 113);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 9;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(171, 113);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 11;
            label3.Text = "Nombre del producto:";
            // 
            // productName_TBox
            // 
            productName_TBox.Location = new Point(171, 136);
            productName_TBox.Name = "productName_TBox";
            productName_TBox.Size = new Size(318, 27);
            productName_TBox.TabIndex = 10;
            productName_TBox.TextChanged += productName_TBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 186);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 13;
            label4.Text = "Precio:";
            // 
            // price_TBox
            // 
            price_TBox.Location = new Point(32, 209);
            price_TBox.Name = "price_TBox";
            price_TBox.Size = new Size(97, 27);
            price_TBox.TabIndex = 12;
            price_TBox.TextChanged += price_TBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(171, 186);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 15;
            label5.Text = "Stock";
            // 
            // stock_TBox
            // 
            stock_TBox.Location = new Point(171, 209);
            stock_TBox.Name = "stock_TBox";
            stock_TBox.Size = new Size(45, 27);
            stock_TBox.TabIndex = 14;
            stock_TBox.TextChanged += stock_TBox_TextChanged;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(35, 389);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(135, 49);
            btn_Exit.TabIndex = 16;
            btn_Exit.Text = "Salir";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Exit);
            Controls.Add(label5);
            Controls.Add(stock_TBox);
            Controls.Add(label4);
            Controls.Add(price_TBox);
            Controls.Add(label3);
            Controls.Add(productName_TBox);
            Controls.Add(label2);
            Controls.Add(id_TBox);
            Controls.Add(label1);
            Controls.Add(search_bar);
            Controls.Add(btn_Search);
            Controls.Add(btn_Delete);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Save);
            Controls.Add(btn_Add);
            Name = "Form1";
            Text = "frmProductos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Add;
        private Button btn_Save;
        private Button btn_Cancel;
        private Button btn_Delete;
        private Button btn_Search;
        private TextBox search_bar;
        private Label label1;
        private TextBox id_TBox;
        private Label label2;
        private Label label3;
        private TextBox productName_TBox;
        private Label label4;
        private TextBox price_TBox;
        private Label label5;
        private TextBox stock_TBox;
        private Button btn_Exit;
    }
}
