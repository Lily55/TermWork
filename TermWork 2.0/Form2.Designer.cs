namespace TermWork_2._0
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 273);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1317, 377);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(1168, 41);
            button1.Name = "button1";
            button1.Size = new Size(142, 62);
            button1.TabIndex = 1;
            button1.Text = "Выход в Меню";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(34, 41);
            button2.Name = "button2";
            button2.Size = new Size(142, 62);
            button2.TabIndex = 2;
            button2.Text = "Select 1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(196, 41);
            button3.Name = "button3";
            button3.Size = new Size(142, 62);
            button3.TabIndex = 3;
            button3.Text = "Select 2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(358, 41);
            button4.Name = "button4";
            button4.Size = new Size(142, 62);
            button4.TabIndex = 4;
            button4.Text = "Select 3";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(520, 41);
            button5.Name = "button5";
            button5.Size = new Size(142, 62);
            button5.TabIndex = 5;
            button5.Text = "Select 4";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(682, 41);
            button6.Name = "button6";
            button6.Size = new Size(142, 62);
            button6.TabIndex = 6;
            button6.Text = "Select 5";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(844, 41);
            button7.Name = "button7";
            button7.Size = new Size(142, 62);
            button7.TabIndex = 7;
            button7.Text = "Select 6";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1006, 41);
            button8.Name = "button8";
            button8.Size = new Size(142, 62);
            button8.TabIndex = 8;
            button8.Text = "Select 7";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(12, 123);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1317, 144);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "Нажмите кнопку выбора select-запроса";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1341, 662);
            Controls.Add(richTextBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private RichTextBox richTextBox1;
    }
}