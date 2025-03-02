namespace CompileTeijkhrebKursach.View
{
    partial class ProgramCard
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
            TopPanel = new Panel();
            label2 = new Label();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            TopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.BackColor = Color.Firebrick;
            TopPanel.Controls.Add(label2);
            TopPanel.Controls.Add(label1);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(550, 104);
            TopPanel.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(174, 33);
            label2.TabIndex = 1;
            label2.Text = "О программе";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 33);
            label1.TabIndex = 0;
            label1.Text = "Текстовый редактор";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.Location = new Point(12, 110);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(526, 203);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "Данный программный продукт разработан студентом \"Новосибирского Государственного Технического Университета\" (НГТУ НЭТИ) факультета \"АВТФ\" группы \"АВТ-214\" Тейхребом Эриком Алексеевичем.";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.Firebrick;
            button1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(388, 319);
            button1.Name = "button1";
            button1.Size = new Size(150, 50);
            button1.TabIndex = 2;
            button1.Text = "Закрыть";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ProgramCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 376);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(TopPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ProgramCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "О программе";
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel TopPanel;
        private Label label2;
        private Label label1;
        private RichTextBox richTextBox1;
        private Button button1;
    }
}