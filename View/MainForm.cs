﻿using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.Presenter;
using CompileTeijkhrebKursach.View.Interfaces;
using System.Globalization;
using System.Resources;


namespace CompileTeijkhrebKursach.View
{
    public partial class MainForm : Form, IMain
    {
        //Необходимые для работы программы поля
        private MainPresenter _presenter;
        private int selectionIndex = 0;
        private readonly bool isRightButtonClickOverridden = false;
        private string lastText = "";
        private bool isCutEnabled = false;
        private Dictionary<int, int> pairsOfPages = new Dictionary<int, int>();
        private bool isEnabledToTextChanged = true;

        //Конструктор класса
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
            lastText = UpperRichTextBox.Text;
            UpperRichTextBox.DragEnter += new DragEventHandler(MainForm_DragEnter);
            UpperRichTextBox.DragDrop += new DragEventHandler(MainForm_DragDrop);
            UpperRichTextBox.AllowDrop = true;
            UpperRichTextBox.VScroll += (s, e) => SyncScroll();
            UpperRichTextBox.TextChanged += (s, e) => UpdateLineNumbers();
            UpperRichTextBox.SelectionChanged += (s, e) => SyncScroll();
            this.SizeChanged += (s, e) => UpdateLineNumbers();
            NumericLB.SelectionMode = SelectionMode.None;
            UpdateLineNumbers();
        }

        //Все события, назначенные на действия пользователя, те или иные
        public event EventHandler<string> CreateFile;
        public event EventHandler<string> OpenFile;
        public event EventHandler<string> SaveFile;
        public event EventHandler StartEnd;
        public event EventHandler Repeat;
        public event EventHandler<string> SaveAsFile;
        public event FormClosingEventHandler CloseProgram;
        public event EventHandler<int> SelectPage;
        public event EventHandler<Operation> ChangeLastUserOperation;
        public event EventHandler NullLastUserOperation;
        public event EventHandler<string> SetNewFileSavedStr;
        public event EventHandler<string> SetNewFileOpenedStr;
        public event EventHandler<string> SetNewFileCreatedStr;
        public event EventHandler<string> ThrowLastTextToModel;
        public event EventHandler<string> ThrowNewTextToModel;
        public event EventHandler CloseCurrentPage;


        ////Блок работы со вкладками
        //Очистка словаря пар страниц
        public void ClearPairs()
        {
            pairsOfPages.Clear();
        }
        //Удаление удаляемой вкладки
        public void DeleteDeletedPage()
        {
            int startIndexToFix = PagesCB.SelectedIndex;
            Dictionary<int, int> buffDict = new Dictionary<int, int>();
            pairsOfPages.Remove(PagesCB.SelectedIndex);
            PagesCB.Items.Remove(PagesCB.SelectedItem);
            foreach (var pair in pairsOfPages)
            {
                if (pair.Key > startIndexToFix)
                {
                    buffDict.Add(pair.Key - 1, pair.Value);
                }
                else
                {
                    buffDict.Add(pair.Key, pair.Value);
                }
            }
            pairsOfPages = buffDict;

        }
        //Удаление всех вкладок
        public void DeleteAllPages()
        {
            isEnabledToTextChanged = false;
            UpperRichTextBox.Clear();
            PagesCB.Items.Clear();
            isEnabledToTextChanged = true;
        }
        //Редактирование имени текущей вкладки
        public void EditCurrentPageName(string newName)
        {
            PagesCB.Items[PagesCB.SelectedIndex] = newName;
            PagesCB.Update();
        }
        //Метод установки вкладки
        public void SetPage(int pageId)
        {
            PagesCB.SelectedIndex = pairsOfPages.FirstOrDefault(x => x.Value == pageId).Key;
        }
        //Метод добавления вкладки
        public void AddTab(string fileName, int idOfPage)
        {
            pairsOfPages.Add(PagesCB.Items.Count, idOfPage);
            PagesCB.Items.Add(fileName);
            PagesCB.SelectedIndex = pairsOfPages.FirstOrDefault(x => x.Value == idOfPage).Key;
        }
        //Закрытие вкладки
        private void закрытьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseCurrentPage?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Обработка смены вкладки
        private void PagesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (PagesCB.Focused)
                {
                    SelectPage?.Invoke(this, pairsOfPages[PagesCB.SelectedIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Обработка ввода комбинаций
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Сохранение
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveButton_Click(this, EventArgs.Empty);
                return true;
            }
            //Вырезать
            else if (keyData == (Keys.Control | Keys.X))
            {
                CutButton_Click(this, EventArgs.Empty);
            }
            //Копировать
            else if (keyData == (Keys.Control | Keys.C))
            {
                CopyButton_Click(this, EventArgs.Empty);
            }
            //Вставить
            else if (keyData == (Keys.Control | Keys.V))
            {
                PasteButton_Click(this, EventArgs.Empty);
            }
            //Открытие файла
            else if (keyData == (Keys.Control | Keys.O))
            {
                FolderButton_Click(this, EventArgs.Empty);
                return true;
            }
            //Выбрать всё
            else if (keyData == (Keys.Control | Keys.A))
            {
                UpperRichTextBox.SelectAll();
            }
            //Отмена
            else if (keyData == (Keys.Control | Keys.Z))
            {
                UpperRichTextBox.Undo();
            }
            //Создание нового файла
            else if (keyData == (Keys.Control | Keys.N))
            {
                FileButton_Click(this, EventArgs.Empty);
            }
            //Закрытие вкладки
            else if (keyData == (Keys.Control | Keys.W))
            {
                try
                {
                    CloseCurrentPage?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        ////Блок работы с нумерацией строк
        //Синхронизация скроллинга
        private void SyncScroll()
        {
            int firstIndex = UpperRichTextBox.GetCharIndexFromPosition(new Point(0, 3));
            int firstLine = UpperRichTextBox.GetLineFromCharIndex(firstIndex);

            if (firstLine < NumericLB.Items.Count)
            {
                NumericLB.TopIndex = firstLine;
            }
        }
        //Обновление нумерации
        private void UpdateLineNumbers()
        {
            int totalLines = UpperRichTextBox.Lines.Length;

            NumericLB.BeginUpdate();
            NumericLB.Items.Clear();
            for (int i = 1; i <= totalLines; i++)
            {
                NumericLB.Items.Add(i.ToString());
            }
            NumericLB.EndUpdate();

            SyncScroll();
        }
        //Кнопка перевода на другой шрифт
        private void toolStripComboBox1_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                UpperRichTextBox.Font = new Font("Bahnschrift", float.Parse(toolStripComboBox1.Text));
                LowerDataGridView.Font = new Font("Bahnschrift", float.Parse(toolStripComboBox1.Text));
                NumericLB.Font = new Font("Bahnschrift", float.Parse(toolStripComboBox1.Text));
                NumericLB.ItemHeight = int.Parse(toolStripComboBox1.Text);
                UpdateLineNumbers();
                UpperRichTextBox.Update();
                LowerDataGridView.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////Блок оповещений
        //Метод для оповещения путём MessageBox
        public void Message(string message)
        {
            MessageBox.Show(message);
        }


        ////Блок "раскидки" текста
        //Метод получения текста
        public string GetText()
        {
            return UpperRichTextBox.Text;
        }
        //Метод установки текста до изменения
        public void SetLastText(string text)
        {
            lastText = text;
        }
        //Метод установки текста в поле для ввода
        public void InsertFileText(string text)
        {
            UpperRichTextBox.Text = text;
        }
        //Метод "повтор в текст"
        public void RepeatToView(Operation operation)
        {
            try
            {
                if (operation.isDelete == false)
                {
                    int position = UpperRichTextBox.SelectionStart;
                    UpperRichTextBox.Text = UpperRichTextBox.Text.Insert(UpperRichTextBox.SelectionStart, operation.containtment);
                    lastText = UpperRichTextBox.Text;
                    UpperRichTextBox.Focus();
                    UpperRichTextBox.SelectionStart = position + operation.containtment.Length;
                }
                else
                {
                    if (UpperRichTextBox.SelectionStart > 0)
                    {
                        int position = UpperRichTextBox.SelectionStart;
                        UpperRichTextBox.Text = UpperRichTextBox.Text.Remove(position - 1, 1);
                        lastText = UpperRichTextBox.Text;
                        UpperRichTextBox.Focus();
                        UpperRichTextBox.SelectionStart = position - operation.containtment.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Отмена
        private void LeftButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpperRichTextBox.CanUndo)
                {
                    UpperRichTextBox.Undo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Повтор
        private void RightButton_Click(object sender, EventArgs e)
        {
            try
            {
                Repeat?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Копирование
        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpperRichTextBox.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Вырезать
        private void CutButton_Click(object sender, EventArgs e)
        {
            try
            {
                isCutEnabled = true;
                UpperRichTextBox.Cut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Вставить
        private void PasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpperRichTextBox.Paste();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Обработка кнопки "Удалить"
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UpperRichTextBox.SelectedText.Length > 0)
            {
                UpperRichTextBox.SelectedText = "";
            }
        }
        //Обработка кнопки "Выделить всё"
        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpperRichTextBox.SelectAll();
        }
        //Обработка ввода текста
        private void UpperRichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isEnabledToTextChanged) return;

                string newText = UpperRichTextBox.Text;
                ThrowNewTextToModel?.Invoke(this, newText);
                int cursorPos = UpperRichTextBox.SelectionStart;

                if (newText.Length > lastText.Length) // Ввод символа
                {
                    int diff = newText.Length - lastText.Length;
                    string insertedText = newText.Substring(cursorPos - (newText.Length - lastText.Length), newText.Length - lastText.Length);
                    if (diff == 1)
                    {
                        ChangeLastUserOperation?.Invoke(this, new Operation(insertedText, false, false, false));
                    }
                    else
                    {
                        ChangeLastUserOperation?.Invoke(this, new Operation(insertedText, false, false, true));
                    }
                }
                else if (newText.Length < lastText.Length) // Удаление символа
                {
                    int diff = lastText.Length - newText.Length;
                    string deletedText = lastText.Substring(cursorPos, diff);
                    if (diff == 1 && isCutEnabled == false)
                    {
                        ChangeLastUserOperation?.Invoke(this, new Operation(deletedText, false, true, false));
                    }
                    else
                    {
                        NullLastUserOperation?.Invoke(this, EventArgs.Empty);
                        isCutEnabled = false;
                    }
                }
                int firstVisibleLine = UpperRichTextBox.GetLineFromCharIndex(UpperRichTextBox.GetCharIndexFromPosition(new Point(0, 0)));
                lastText = newText;
                ThrowLastTextToModel?.Invoke(this, lastText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////Блок перевода
        //Метод для перевода интерфейса
        private void UpdateControlsText(Control control, ResourceManager res)
        {
            LowerDataGridView.Columns[0].HeaderText = res.GetString("FileNameColumn");
            LowerDataGridView.Columns[1].HeaderText = res.GetString("LineColumn");
            LowerDataGridView.Columns[2].HeaderText = res.GetString("ColumnColumn");
            LowerDataGridView.Columns[3].HeaderText = res.GetString("MessageColumn");
            _presenter.CloseProgramStr = res.GetString("CloseProgramStr");
            _presenter.CloseSavedStr = res.GetString("CloseSavedStr");
            _presenter.CloseUnsavedStr = res.GetString("CloseUnsavedStr");
            _presenter.MessageNoPathStr = res.GetString("MessageNoPathStr");
            _presenter.SaveNoPathStr = res.GetString("SaveNoPathStr");
            TabLabel.Text = res.GetString("TabLabel");
            SetNewFileSavedStr?.Invoke(this, res.GetString("FileSaved"));
            SetNewFileOpenedStr?.Invoke(this, res.GetString("FileOpened"));
            SetNewFileCreatedStr?.Invoke(this, res.GetString("FileCreated"));

            foreach (var item in this.MainMenuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    UpdateMenuItems(menuItem, res);
                }
            }
        }
        //Метод обновления текста MenuStrip
        private void UpdateMenuItems(ToolStripMenuItem menuItem, ResourceManager res)
        {
            if (!string.IsNullOrEmpty(menuItem.Name))
            {
                string newText = res.GetString(menuItem.Name);
                if (!string.IsNullOrEmpty(newText))
                    menuItem.Text = newText;
            }


            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    UpdateMenuItems(subMenuItem, res);
                }
            }
        }
        //Метод для установки\удаления флажка "* " при изменении\сохранении
        public void SetFlagToComboBoxItem(int pageToEditId, bool flag)
        {
            if (flag)
            {
                string currentPageName = PagesCB.Items[pairsOfPages.FirstOrDefault(x => x.Value == pageToEditId).Key].ToString();
                if (currentPageName.StartsWith("* "))
                {
                    PagesCB.Items[pairsOfPages.FirstOrDefault(x => x.Value == pageToEditId).Key] = PagesCB.Items[pairsOfPages.FirstOrDefault(x => x.Value == pageToEditId).Key].ToString().Remove(0, 2);
                }
            }
            else
            {
                string currentPageName = PagesCB.Items[pairsOfPages.FirstOrDefault(x => x.Value == pageToEditId).Key].ToString();
                if (!currentPageName.StartsWith("* "))
                {
                    PagesCB.Items[pairsOfPages.FirstOrDefault(x => x.Value == pageToEditId).Key] = "* " + currentPageName;
                }
            }
        }
        //Выбор русского языка
        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                ResourceManager res = new ResourceManager("CompileTeijkhrebKursach.Resources.Resource_ru", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Выбор английского языка
        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                ResourceManager res = new ResourceManager("CompileTeijkhrebKursach.Resources.Resource_en", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////Блок работы с файлом
        //Создание файла
        private void FileButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog.FileName;
                CreateFile?.Invoke(this, saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Открытие готового файла
        private void FolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog.FileName;
                isEnabledToTextChanged = false;
                OpenFile?.Invoke(this, filename);
                isEnabledToTextChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Сохранение файла
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile?.Invoke(this, UpperRichTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Сохранить как
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAsFile?.Invoke(this, UpperRichTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////Блок "не для первой лабы"
        //Пуск
        private void StartEndButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartEnd?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Обработка закрытия программы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseProgram?.Invoke(this, e);
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        ////Блок обработки Drag&Drop
        //Обработка Drag&Drop
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Обработка Drag&Drop
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {
                        OpenFile?.Invoke(this, filePath);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно открыть файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////Блок вспомогательных элементов
        //Справка
        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string helpFilePath = "Resources/Help.chm";
                if (System.IO.File.Exists(helpFilePath))
                {
                    // Открываем справку по указанному файлу
                    Help.ShowHelp(this, helpFilePath);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramCard programCard = new ProgramCard();
            programCard.Show();
        }
    }
}
