namespace CompileTeijkhrebKursach.View
{
    partial class MainForm
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
            MainMenu = new MenuStrip();
            файоToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            повторитьToolStripMenuItem = new ToolStripMenuItem();
            вырезатьToolStripMenuItem = new ToolStripMenuItem();
            копироватьToolStripMenuItem = new ToolStripMenuItem();
            вставитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            выделитьВсёToolStripMenuItem = new ToolStripMenuItem();
            закрытьВкладкуToolStripMenuItem = new ToolStripMenuItem();
            текстToolStripMenuItem = new ToolStripMenuItem();
            постановкаЗадачиToolStripMenuItem = new ToolStripMenuItem();
            грамматикаToolStripMenuItem = new ToolStripMenuItem();
            классификацияГрамматикиToolStripMenuItem = new ToolStripMenuItem();
            методАнализаToolStripMenuItem = new ToolStripMenuItem();
            диагностикаИНейтрализацияОшибокToolStripMenuItem = new ToolStripMenuItem();
            тестовыйПримерToolStripMenuItem = new ToolStripMenuItem();
            списокЛитературыToolStripMenuItem = new ToolStripMenuItem();
            исходныйКодПрограммыToolStripMenuItem = new ToolStripMenuItem();
            размерШрифтаВОкнеВыводавводаToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            пускToolStripMenuItem = new ToolStripMenuItem();
            справкToolStripMenuItem = new ToolStripMenuItem();
            вызовСправкиToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            языкПрограммыToolStripMenuItem = new ToolStripMenuItem();
            русскийToolStripMenuItem = new ToolStripMenuItem();
            английскийToolStripMenuItem = new ToolStripMenuItem();
            BottomPanel = new Panel();
            NSTUlogo = new PictureBox();
            TopPanel = new Panel();
            PagesCB = new ComboBox();
            TabLabel = new Label();
            InfoButton = new Button();
            QuestionButton = new Button();
            StartEndButton = new Button();
            PasteButton = new Button();
            CutButton = new Button();
            CopyButton = new Button();
            RightButton = new Button();
            LeftButton = new Button();
            SaveButton = new Button();
            FolderButton = new Button();
            FileButton = new Button();
            MainPanel = new Panel();
            splitContainer1 = new SplitContainer();
            NumericLB = new ListBox();
            UpperRichTextBox = new RichTextBox();
            LowerDataGridView = new DataGridView();
            FileNameColumn = new DataGridViewTextBoxColumn();
            LineColumn = new DataGridViewTextBoxColumn();
            ColumnColumn = new DataGridViewTextBoxColumn();
            MessageColumn = new DataGridViewTextBoxColumn();
            MainMenu.SuspendLayout();
            BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NSTUlogo).BeginInit();
            TopPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LowerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.BackColor = Color.Firebrick;
            MainMenu.Font = new Font("Bahnschrift", 14.25F);
            MainMenu.Items.AddRange(new ToolStripItem[] { файоToolStripMenuItem, правкаToolStripMenuItem, текстToolStripMenuItem, пускToolStripMenuItem, справкToolStripMenuItem, языкПрограммыToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(796, 31);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "Главное меню";
            // 
            // файоToolStripMenuItem
            // 
            файоToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, выходToolStripMenuItem });
            файоToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            файоToolStripMenuItem.Name = "файоToolStripMenuItem";
            файоToolStripMenuItem.Size = new Size(69, 27);
            файоToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.BackColor = Color.Firebrick;
            создатьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(208, 28);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += FileButton_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.BackColor = Color.Firebrick;
            открытьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(208, 28);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += FolderButton_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.BackColor = Color.Firebrick;
            сохранитьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(208, 28);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += SaveButton_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.BackColor = Color.Firebrick;
            сохранитьКакToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(208, 28);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.BackColor = Color.Firebrick;
            выходToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(208, 28);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменитьToolStripMenuItem, повторитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem, удалитьToolStripMenuItem, выделитьВсёToolStripMenuItem, закрытьВкладкуToolStripMenuItem });
            правкаToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(85, 27);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.BackColor = Color.Firebrick;
            отменитьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(230, 28);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += LeftButton_Click;
            // 
            // повторитьToolStripMenuItem
            // 
            повторитьToolStripMenuItem.BackColor = Color.Firebrick;
            повторитьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            повторитьToolStripMenuItem.Size = new Size(230, 28);
            повторитьToolStripMenuItem.Text = "Повторить";
            повторитьToolStripMenuItem.Click += RightButton_Click;
            // 
            // вырезатьToolStripMenuItem
            // 
            вырезатьToolStripMenuItem.BackColor = Color.Firebrick;
            вырезатьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            вырезатьToolStripMenuItem.Size = new Size(230, 28);
            вырезатьToolStripMenuItem.Text = "Вырезать";
            вырезатьToolStripMenuItem.Click += CutButton_Click;
            // 
            // копироватьToolStripMenuItem
            // 
            копироватьToolStripMenuItem.BackColor = Color.Firebrick;
            копироватьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            копироватьToolStripMenuItem.Size = new Size(230, 28);
            копироватьToolStripMenuItem.Text = "Копировать";
            копироватьToolStripMenuItem.Click += CopyButton_Click;
            // 
            // вставитьToolStripMenuItem
            // 
            вставитьToolStripMenuItem.BackColor = Color.Firebrick;
            вставитьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            вставитьToolStripMenuItem.Size = new Size(230, 28);
            вставитьToolStripMenuItem.Text = "Вставить";
            вставитьToolStripMenuItem.Click += PasteButton_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.BackColor = Color.Firebrick;
            удалитьToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(230, 28);
            удалитьToolStripMenuItem.Text = "Удалить";
            удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
            // 
            // выделитьВсёToolStripMenuItem
            // 
            выделитьВсёToolStripMenuItem.BackColor = Color.Firebrick;
            выделитьВсёToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            выделитьВсёToolStripMenuItem.Size = new Size(230, 28);
            выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            выделитьВсёToolStripMenuItem.Click += выделитьВсёToolStripMenuItem_Click;
            // 
            // закрытьВкладкуToolStripMenuItem
            // 
            закрытьВкладкуToolStripMenuItem.BackColor = Color.Firebrick;
            закрытьВкладкуToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            закрытьВкладкуToolStripMenuItem.Name = "закрытьВкладкуToolStripMenuItem";
            закрытьВкладкуToolStripMenuItem.Size = new Size(230, 28);
            закрытьВкладкуToolStripMenuItem.Text = "Закрыть вкладку";
            закрытьВкладкуToolStripMenuItem.Click += закрытьВкладкуToolStripMenuItem_Click;
            // 
            // текстToolStripMenuItem
            // 
            текстToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { постановкаЗадачиToolStripMenuItem, грамматикаToolStripMenuItem, классификацияГрамматикиToolStripMenuItem, методАнализаToolStripMenuItem, диагностикаИНейтрализацияОшибокToolStripMenuItem, тестовыйПримерToolStripMenuItem, списокЛитературыToolStripMenuItem, исходныйКодПрограммыToolStripMenuItem, размерШрифтаВОкнеВыводавводаToolStripMenuItem });
            текстToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            текстToolStripMenuItem.Size = new Size(68, 27);
            текстToolStripMenuItem.Text = "Текст";
            // 
            // постановкаЗадачиToolStripMenuItem
            // 
            постановкаЗадачиToolStripMenuItem.BackColor = Color.Firebrick;
            постановкаЗадачиToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            постановкаЗадачиToolStripMenuItem.Name = "постановкаЗадачиToolStripMenuItem";
            постановкаЗадачиToolStripMenuItem.Size = new Size(421, 28);
            постановкаЗадачиToolStripMenuItem.Text = "Постановка задачи";
            // 
            // грамматикаToolStripMenuItem
            // 
            грамматикаToolStripMenuItem.BackColor = Color.Firebrick;
            грамматикаToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            грамматикаToolStripMenuItem.Name = "грамматикаToolStripMenuItem";
            грамматикаToolStripMenuItem.Size = new Size(421, 28);
            грамматикаToolStripMenuItem.Text = "Грамматика";
            // 
            // классификацияГрамматикиToolStripMenuItem
            // 
            классификацияГрамматикиToolStripMenuItem.BackColor = Color.Firebrick;
            классификацияГрамматикиToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            классификацияГрамматикиToolStripMenuItem.Name = "классификацияГрамматикиToolStripMenuItem";
            классификацияГрамматикиToolStripMenuItem.Size = new Size(421, 28);
            классификацияГрамматикиToolStripMenuItem.Text = "Классификация грамматики";
            // 
            // методАнализаToolStripMenuItem
            // 
            методАнализаToolStripMenuItem.BackColor = Color.Firebrick;
            методАнализаToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            методАнализаToolStripMenuItem.Name = "методАнализаToolStripMenuItem";
            методАнализаToolStripMenuItem.Size = new Size(421, 28);
            методАнализаToolStripMenuItem.Text = "Метод анализа";
            // 
            // диагностикаИНейтрализацияОшибокToolStripMenuItem
            // 
            диагностикаИНейтрализацияОшибокToolStripMenuItem.BackColor = Color.Firebrick;
            диагностикаИНейтрализацияОшибокToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            диагностикаИНейтрализацияОшибокToolStripMenuItem.Name = "диагностикаИНейтрализацияОшибокToolStripMenuItem";
            диагностикаИНейтрализацияОшибокToolStripMenuItem.Size = new Size(421, 28);
            диагностикаИНейтрализацияОшибокToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            // 
            // тестовыйПримерToolStripMenuItem
            // 
            тестовыйПримерToolStripMenuItem.BackColor = Color.Firebrick;
            тестовыйПримерToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            тестовыйПримерToolStripMenuItem.Name = "тестовыйПримерToolStripMenuItem";
            тестовыйПримерToolStripMenuItem.Size = new Size(421, 28);
            тестовыйПримерToolStripMenuItem.Text = "Тестовый пример";
            // 
            // списокЛитературыToolStripMenuItem
            // 
            списокЛитературыToolStripMenuItem.BackColor = Color.Firebrick;
            списокЛитературыToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            списокЛитературыToolStripMenuItem.Name = "списокЛитературыToolStripMenuItem";
            списокЛитературыToolStripMenuItem.Size = new Size(421, 28);
            списокЛитературыToolStripMenuItem.Text = "Список литературы";
            // 
            // исходныйКодПрограммыToolStripMenuItem
            // 
            исходныйКодПрограммыToolStripMenuItem.BackColor = Color.Firebrick;
            исходныйКодПрограммыToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            исходныйКодПрограммыToolStripMenuItem.Name = "исходныйКодПрограммыToolStripMenuItem";
            исходныйКодПрограммыToolStripMenuItem.Size = new Size(421, 28);
            исходныйКодПрограммыToolStripMenuItem.Text = "Исходный код программы";
            // 
            // размерШрифтаВОкнеВыводавводаToolStripMenuItem
            // 
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.BackColor = Color.Firebrick;
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.Name = "размерШрифтаВОкнеВыводавводаToolStripMenuItem";
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.Size = new Size(421, 28);
            размерШрифтаВОкнеВыводавводаToolStripMenuItem.Text = "Размер шрифта в окне вывода\\ввода";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.BackColor = Color.Firebrick;
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.Font = new Font("Bahnschrift", 15.75F);
            toolStripComboBox1.ForeColor = SystemColors.ControlLightLight;
            toolStripComboBox1.Items.AddRange(new object[] { "12", "14", "16", "18", "20" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 33);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_TextUpdate;
            // 
            // пускToolStripMenuItem
            // 
            пускToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            пускToolStripMenuItem.Name = "пускToolStripMenuItem";
            пускToolStripMenuItem.Size = new Size(63, 27);
            пускToolStripMenuItem.Text = "Пуск";
            // 
            // справкToolStripMenuItem
            // 
            справкToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вызовСправкиToolStripMenuItem, оПрограммеToolStripMenuItem });
            справкToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            справкToolStripMenuItem.Name = "справкToolStripMenuItem";
            справкToolStripMenuItem.Size = new Size(95, 27);
            справкToolStripMenuItem.Text = "Справка";
            // 
            // вызовСправкиToolStripMenuItem
            // 
            вызовСправкиToolStripMenuItem.BackColor = Color.Firebrick;
            вызовСправкиToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            вызовСправкиToolStripMenuItem.Name = "вызовСправкиToolStripMenuItem";
            вызовСправкиToolStripMenuItem.Size = new Size(210, 28);
            вызовСправкиToolStripMenuItem.Text = "Вызов справки";
            вызовСправкиToolStripMenuItem.Click += вызовСправкиToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.BackColor = Color.Firebrick;
            оПрограммеToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(210, 28);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // языкПрограммыToolStripMenuItem
            // 
            языкПрограммыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { русскийToolStripMenuItem, английскийToolStripMenuItem });
            языкПрограммыToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            языкПрограммыToolStripMenuItem.Name = "языкПрограммыToolStripMenuItem";
            языкПрограммыToolStripMenuItem.Size = new Size(167, 27);
            языкПрограммыToolStripMenuItem.Text = "Язык программы";
            // 
            // русскийToolStripMenuItem
            // 
            русскийToolStripMenuItem.BackColor = Color.Firebrick;
            русскийToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            русскийToolStripMenuItem.Name = "русскийToolStripMenuItem";
            русскийToolStripMenuItem.Size = new Size(184, 28);
            русскийToolStripMenuItem.Text = "Русский";
            русскийToolStripMenuItem.Click += русскийToolStripMenuItem_Click;
            // 
            // английскийToolStripMenuItem
            // 
            английскийToolStripMenuItem.BackColor = Color.Firebrick;
            английскийToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            английскийToolStripMenuItem.Name = "английскийToolStripMenuItem";
            английскийToolStripMenuItem.Size = new Size(184, 28);
            английскийToolStripMenuItem.Text = "Английский";
            английскийToolStripMenuItem.Click += английскийToolStripMenuItem_Click;
            // 
            // BottomPanel
            // 
            BottomPanel.BackColor = Color.ForestGreen;
            BottomPanel.Controls.Add(NSTUlogo);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 460);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(796, 58);
            BottomPanel.TabIndex = 1;
            // 
            // NSTUlogo
            // 
            NSTUlogo.Image = Resources.Логотип_НГТУ_НЭТИ;
            NSTUlogo.Location = new Point(5, 3);
            NSTUlogo.Name = "NSTUlogo";
            NSTUlogo.Size = new Size(100, 50);
            NSTUlogo.SizeMode = PictureBoxSizeMode.Zoom;
            NSTUlogo.TabIndex = 0;
            NSTUlogo.TabStop = false;
            // 
            // TopPanel
            // 
            TopPanel.BackColor = SystemColors.ControlLightLight;
            TopPanel.Controls.Add(PagesCB);
            TopPanel.Controls.Add(TabLabel);
            TopPanel.Controls.Add(InfoButton);
            TopPanel.Controls.Add(QuestionButton);
            TopPanel.Controls.Add(StartEndButton);
            TopPanel.Controls.Add(PasteButton);
            TopPanel.Controls.Add(CutButton);
            TopPanel.Controls.Add(CopyButton);
            TopPanel.Controls.Add(RightButton);
            TopPanel.Controls.Add(LeftButton);
            TopPanel.Controls.Add(SaveButton);
            TopPanel.Controls.Add(FolderButton);
            TopPanel.Controls.Add(FileButton);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 31);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(796, 65);
            TopPanel.TabIndex = 2;
            // 
            // PagesCB
            // 
            PagesCB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PagesCB.DropDownStyle = ComboBoxStyle.DropDownList;
            PagesCB.Font = new Font("Bahnschrift", 12F);
            PagesCB.FormattingEnabled = true;
            PagesCB.Location = new Point(475, 29);
            PagesCB.MaximumSize = new Size(500, 0);
            PagesCB.Name = "PagesCB";
            PagesCB.Size = new Size(141, 27);
            PagesCB.TabIndex = 11;
            PagesCB.SelectedIndexChanged += PagesCB_SelectedIndexChanged;
            // 
            // TabLabel
            // 
            TabLabel.AutoSize = true;
            TabLabel.Font = new Font("Bahnschrift", 12F);
            TabLabel.Location = new Point(475, 7);
            TabLabel.Name = "TabLabel";
            TabLabel.Size = new Size(142, 19);
            TabLabel.TabIndex = 4;
            TabLabel.Text = "Текущая вкладка:";
            // 
            // InfoButton
            // 
            InfoButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InfoButton.BackgroundImage = Resources.icons8_information_64;
            InfoButton.BackgroundImageLayout = ImageLayout.Zoom;
            InfoButton.Location = new Point(734, 7);
            InfoButton.Name = "InfoButton";
            InfoButton.Size = new Size(50, 50);
            InfoButton.TabIndex = 10;
            InfoButton.UseVisualStyleBackColor = true;
            InfoButton.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // QuestionButton
            // 
            QuestionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            QuestionButton.BackgroundImage = Resources.Icon_round_Question_mark_svg;
            QuestionButton.BackgroundImageLayout = ImageLayout.Zoom;
            QuestionButton.Location = new Point(678, 7);
            QuestionButton.Name = "QuestionButton";
            QuestionButton.Size = new Size(50, 50);
            QuestionButton.TabIndex = 9;
            QuestionButton.UseVisualStyleBackColor = true;
            QuestionButton.Click += вызовСправкиToolStripMenuItem_Click;
            // 
            // StartEndButton
            // 
            StartEndButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartEndButton.BackgroundImage = Resources.icons8_end_50;
            StartEndButton.BackgroundImageLayout = ImageLayout.Zoom;
            StartEndButton.Location = new Point(622, 7);
            StartEndButton.Name = "StartEndButton";
            StartEndButton.Size = new Size(50, 50);
            StartEndButton.TabIndex = 8;
            StartEndButton.UseVisualStyleBackColor = true;
            StartEndButton.Click += StartEndButton_Click;
            // 
            // PasteButton
            // 
            PasteButton.BackgroundImage = Resources.icons8_paste_50;
            PasteButton.BackgroundImageLayout = ImageLayout.Zoom;
            PasteButton.Location = new Point(419, 7);
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(50, 50);
            PasteButton.TabIndex = 7;
            PasteButton.UseVisualStyleBackColor = true;
            PasteButton.Click += PasteButton_Click;
            // 
            // CutButton
            // 
            CutButton.BackgroundImage = Resources.icons8_cut_paper_50;
            CutButton.BackgroundImageLayout = ImageLayout.Zoom;
            CutButton.Location = new Point(363, 7);
            CutButton.Name = "CutButton";
            CutButton.Size = new Size(50, 50);
            CutButton.TabIndex = 6;
            CutButton.UseVisualStyleBackColor = true;
            CutButton.Click += CutButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.BackgroundImage = Resources.icons8_copy_50;
            CopyButton.BackgroundImageLayout = ImageLayout.Zoom;
            CopyButton.Location = new Point(307, 7);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(50, 50);
            CopyButton.TabIndex = 5;
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // RightButton
            // 
            RightButton.BackgroundImage = Resources.icons8_move_right_32;
            RightButton.BackgroundImageLayout = ImageLayout.Zoom;
            RightButton.Location = new Point(251, 7);
            RightButton.Name = "RightButton";
            RightButton.Size = new Size(50, 50);
            RightButton.TabIndex = 4;
            RightButton.UseVisualStyleBackColor = true;
            RightButton.Click += RightButton_Click;
            // 
            // LeftButton
            // 
            LeftButton.BackgroundImage = Resources.icons8_move_left_32;
            LeftButton.BackgroundImageLayout = ImageLayout.Zoom;
            LeftButton.Location = new Point(195, 7);
            LeftButton.Name = "LeftButton";
            LeftButton.Size = new Size(50, 50);
            LeftButton.TabIndex = 3;
            LeftButton.UseVisualStyleBackColor = true;
            LeftButton.Click += LeftButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackgroundImage = Resources.icons8_save_50;
            SaveButton.BackgroundImageLayout = ImageLayout.Zoom;
            SaveButton.Location = new Point(126, 7);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(50, 50);
            SaveButton.TabIndex = 2;
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // FolderButton
            // 
            FolderButton.BackgroundImage = Resources.icons8_folder_50;
            FolderButton.BackgroundImageLayout = ImageLayout.Zoom;
            FolderButton.Location = new Point(70, 7);
            FolderButton.Name = "FolderButton";
            FolderButton.Size = new Size(50, 50);
            FolderButton.TabIndex = 1;
            FolderButton.UseVisualStyleBackColor = true;
            FolderButton.Click += FolderButton_Click;
            // 
            // FileButton
            // 
            FileButton.BackgroundImage = Resources.icons8_file_50;
            FileButton.BackgroundImageLayout = ImageLayout.Zoom;
            FileButton.Location = new Point(14, 7);
            FileButton.Name = "FileButton";
            FileButton.Size = new Size(50, 50);
            FileButton.TabIndex = 0;
            FileButton.UseVisualStyleBackColor = true;
            FileButton.Click += FileButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ControlLightLight;
            MainPanel.Controls.Add(splitContainer1);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 96);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(796, 364);
            MainPanel.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(NumericLB);
            splitContainer1.Panel1.Controls.Add(UpperRichTextBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(LowerDataGridView);
            splitContainer1.Size = new Size(796, 364);
            splitContainer1.SplitterDistance = 182;
            splitContainer1.TabIndex = 4;
            // 
            // NumericLB
            // 
            NumericLB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            NumericLB.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NumericLB.FormattingEnabled = true;
            NumericLB.IntegralHeight = false;
            NumericLB.ItemHeight = 19;
            NumericLB.Location = new Point(5, 3);
            NumericLB.Name = "NumericLB";
            NumericLB.Size = new Size(52, 176);
            NumericLB.TabIndex = 3;
            // 
            // UpperRichTextBox
            // 
            UpperRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UpperRichTextBox.Font = new Font("Bahnschrift", 12F);
            UpperRichTextBox.Location = new Point(63, 3);
            UpperRichTextBox.Name = "UpperRichTextBox";
            UpperRichTextBox.ShortcutsEnabled = false;
            UpperRichTextBox.Size = new Size(730, 176);
            UpperRichTextBox.TabIndex = 0;
            UpperRichTextBox.Text = "";
            UpperRichTextBox.WordWrap = false;
            UpperRichTextBox.TextChanged += UpperRichTextBox_TextChanged;
            // 
            // LowerDataGridView
            // 
            LowerDataGridView.AllowUserToAddRows = false;
            LowerDataGridView.AllowUserToDeleteRows = false;
            LowerDataGridView.BackgroundColor = SystemColors.ControlLight;
            LowerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LowerDataGridView.Columns.AddRange(new DataGridViewColumn[] { FileNameColumn, LineColumn, ColumnColumn, MessageColumn });
            LowerDataGridView.Dock = DockStyle.Fill;
            LowerDataGridView.Location = new Point(0, 0);
            LowerDataGridView.Name = "LowerDataGridView";
            LowerDataGridView.ReadOnly = true;
            LowerDataGridView.Size = new Size(796, 178);
            LowerDataGridView.TabIndex = 0;
            // 
            // FileNameColumn
            // 
            FileNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileNameColumn.HeaderText = "Путь к файлу";
            FileNameColumn.Name = "FileNameColumn";
            FileNameColumn.ReadOnly = true;
            // 
            // LineColumn
            // 
            LineColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LineColumn.HeaderText = "Строка";
            LineColumn.Name = "LineColumn";
            LineColumn.ReadOnly = true;
            LineColumn.Width = 71;
            // 
            // ColumnColumn
            // 
            ColumnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnColumn.HeaderText = "Столбец";
            ColumnColumn.Name = "ColumnColumn";
            ColumnColumn.ReadOnly = true;
            ColumnColumn.Width = 79;
            // 
            // MessageColumn
            // 
            MessageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            MessageColumn.HeaderText = "Сообщение";
            MessageColumn.Name = "MessageColumn";
            MessageColumn.ReadOnly = true;
            MessageColumn.Width = 98;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 518);
            Controls.Add(MainPanel);
            Controls.Add(TopPanel);
            Controls.Add(BottomPanel);
            Controls.Add(MainMenu);
            MainMenuStrip = MainMenu;
            MinimumSize = new Size(812, 557);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Текстовый редактор";
            FormClosing += MainForm_FormClosing;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NSTUlogo).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            MainPanel.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LowerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem файоToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem текстToolStripMenuItem;
        private ToolStripMenuItem пускToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem повторитьToolStripMenuItem;
        private ToolStripMenuItem вырезатьToolStripMenuItem;
        private ToolStripMenuItem копироватьToolStripMenuItem;
        private ToolStripMenuItem вставитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem выделитьВсёToolStripMenuItem;
        private ToolStripMenuItem постановкаЗадачиToolStripMenuItem;
        private ToolStripMenuItem грамматикаToolStripMenuItem;
        private ToolStripMenuItem классификацияГрамматикиToolStripMenuItem;
        private ToolStripMenuItem методАнализаToolStripMenuItem;
        private ToolStripMenuItem диагностикаИНейтрализацияОшибокToolStripMenuItem;
        private ToolStripMenuItem тестовыйПримерToolStripMenuItem;
        private ToolStripMenuItem списокЛитературыToolStripMenuItem;
        private ToolStripMenuItem исходныйКодПрограммыToolStripMenuItem;
        private ToolStripMenuItem справкToolStripMenuItem;
        private ToolStripMenuItem вызовСправкиToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private Panel BottomPanel;
        private Panel TopPanel;
        private PictureBox NSTUlogo;
        private Panel MainPanel;
        private Button FileButton;
        private Button PasteButton;
        private Button CutButton;
        private Button CopyButton;
        private Button RightButton;
        private Button LeftButton;
        private Button SaveButton;
        private Button FolderButton;
        private Button InfoButton;
        private Button QuestionButton;
        private Button StartEndButton;
        private ToolStripMenuItem размерШрифтаВОкнеВыводавводаToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        public RichTextBox UpperRichTextBox;
        private Label TabLabel;
        private ComboBox PagesCB;
        private ToolStripMenuItem языкПрограммыToolStripMenuItem;
        private ToolStripMenuItem русскийToolStripMenuItem;
        private ToolStripMenuItem английскийToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ListBox NumericLB;
        private DataGridView LowerDataGridView;
        private DataGridViewTextBoxColumn FileNameColumn;
        private DataGridViewTextBoxColumn LineColumn;
        private DataGridViewTextBoxColumn ColumnColumn;
        private DataGridViewTextBoxColumn MessageColumn;
        private ToolStripMenuItem закрытьВкладкуToolStripMenuItem;
    }
}