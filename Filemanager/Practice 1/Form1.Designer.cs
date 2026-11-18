namespace Practice_1
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            treeView1 = new TreeView();
            button2 = new Button();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 418);
            button1.Name = "button1";
            button1.Size = new Size(156, 25);
            button1.TabIndex = 0;
            button1.Text = "Поиск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Стартовая директория:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 27);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 3;
            label2.Text = "Шаблон имени файла:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(486, 24);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 23);
            textBox2.TabIndex = 4;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 53);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(776, 346);
            treeView1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(618, 418);
            button2.Name = "button2";
            button2.Size = new Size(156, 25);
            button2.TabIndex = 6;
            button2.Text = "Остановить";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(348, 423);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 7;
            label3.Text = "00:00:00.0000000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(treeView1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Файловый менеджер";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private TreeView treeView1;
        private Button button2;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}
