using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.Presenter;
using CompileTeijkhrebKursach.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CompileTeijkhrebKursach.View
{
    public partial class MainForm : Form, IMain
    {
        private readonly MainPresenter _presenter;
        private int selectionIndex = 0;
        private bool isRightButtonClickOverridden = false;
        private string lastText = "";
        private bool isCutEnabled = false;
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
            lastText = UpperRichTextBox.Text;
            UpperRichTextBox.DragEnter += new DragEventHandler(MainForm_DragEnter);
            UpperRichTextBox.DragDrop += new DragEventHandler(MainForm_DragDrop);
            UpperRichTextBox.AllowDrop = true;
        }
        public event EventHandler<string> CreateFile;
        public event EventHandler<string> OpenFile;
        public event EventHandler<string> SaveFile;
        public event EventHandler StartEnd;
        public event EventHandler OpenHelp;
        public event EventHandler About;
        public event EventHandler Repeat;
        public event EventHandler<string> SaveAsFile;
        public event FormClosingEventHandler CloseProgram;
        public event EventHandler<int> SelectPage;
        public event EventHandler<Operation> ChangeLastUserOperation;
        public event EventHandler NullLastUserOperation;
        public void Message(string message)
        {
            MessageBox.Show(message);
        }
        public string GetText()
        {
            return UpperRichTextBox.Text;
        }
        public void SetLastText(string text)
        {
            lastText = text;
        }
        public void InsertFileText(string text)
        {
            UpperRichTextBox.Text = text;
        }
        private void UpdateControlsText(Control control, ResourceManager res)
        {
            //SaveFileStr1 = res.GetString("SaveFileStr1");
            //SaveFileStr2 = res.GetString("SaveFileStr2");
            //FileSaved = res.GetString("FileSaved");
            //FileOpened = res.GetString("FileOpened");

            foreach (var item in this.MainMenuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    UpdateMenuItems(menuItem, res);
                }
            }
        }
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
        public void SetFlagToComboBoxItem(string itemName, bool flag)
        {
            if (flag)
            {
                List<Tuple<string, int>> values = new List<Tuple<string, int>>();
                foreach (var item in PagesCB.Items)
                {
                    if (item != null)
                    {
                        if (item.ToString().StartsWith("* "))
                        {
                            String altItem = new String(item.ToString());
                            values.Add(new Tuple<string, int>(altItem.ToString().Remove(0, 2), PagesCB.Items.IndexOf(item)));
                        }
                        else
                        {
                            values.Add(new Tuple<string, int>(item.ToString(), PagesCB.Items.IndexOf(item)));
                        }
                    }
                }
                int neededIndex = values.Find(x => x.Item1 == itemName).Item2;
                if (PagesCB.Items[neededIndex].ToString().StartsWith("* "))
                {
                    PagesCB.Items[neededIndex] = itemName;
                }
            }
            else
            {
                List<Tuple<string, int>> values = new List<Tuple<string, int>>();
                foreach (var item in PagesCB.Items)
                {
                    if (item != null)
                    {
                        if (item.ToString().StartsWith("* "))
                        {
                            String altItem = new String(item.ToString());
                            values.Add(new Tuple<string, int>(altItem.ToString().Remove(0, 2), PagesCB.Items.IndexOf(item)));
                        }
                        else
                        {
                            values.Add(new Tuple<string, int>(item.ToString(), PagesCB.Items.IndexOf(item)));
                        }
                    }
                }
                int neededIndex = values.Find(x => x.Item1 == itemName).Item2;
                PagesCB.Items[neededIndex] = "* " + itemName;
            }
        }
        public void SetPage(string pageName)
        {
            PagesCB.SelectedItem = pageName;
        }
        public void RepeatToView(Operation operation)
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
        public void AddTab(string fileName)
        {
            PagesCB.Items.Add(fileName);
            PagesCB.SelectedItem = fileName;
        }
        //Создание файла
        private void FileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            CreateFile?.Invoke(this, saveFileDialog.FileName);
        }
        //Открытие готового файла
        private void FolderButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            OpenFile?.Invoke(this, filename);
        }
        //Сохранение файла
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile?.Invoke(this, UpperRichTextBox.Text);
        }
        //Отмена
        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (UpperRichTextBox.CanUndo)
            {
                UpperRichTextBox.Undo();
            }
        }
        //Повтор
        private void RightButton_Click(object sender, EventArgs e)
        {
            Repeat?.Invoke(this, EventArgs.Empty);
        }
        //Копирование
        private void CopyButton_Click(object sender, EventArgs e)
        {
            UpperRichTextBox.Copy();
        }
        //Вырезать
        private void CutButton_Click(object sender, EventArgs e)
        {
            isCutEnabled = true;
            UpperRichTextBox.Cut();
        }
        //Вставить
        private void PasteButton_Click(object sender, EventArgs e)
        {
            UpperRichTextBox.Paste();
        }
        //Пуск
        private void StartEndButton_Click(object sender, EventArgs e)
        {
            StartEnd?.Invoke(this, EventArgs.Empty);
        }
        //Справка
        private void QuestionButton_Click(object sender, EventArgs e)
        {
            OpenHelp?.Invoke(this, EventArgs.Empty);
        }
        //О программе
        private void InfoButton_Click(object sender, EventArgs e)
        {
            About?.Invoke(this, EventArgs.Empty);
        }
        //Сохранить как
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile?.Invoke(this, UpperRichTextBox.Text);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseProgram?.Invoke(this, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpperRichTextBox_Leave(object sender, EventArgs e)
        {
            selectionIndex = UpperRichTextBox.SelectionStart;
        }

        private void UpperRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!UpperRichTextBox.Focused) return;

            string newText = UpperRichTextBox.Text;
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
            lastText = newText;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UpperRichTextBox.SelectedText.Length > 0)
            {
                UpperRichTextBox.SelectedText = "";
            }
        }
        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpperRichTextBox.SelectAll();
        }
        private void toolStripComboBox1_TextUpdate(object sender, EventArgs e)
        {
            UpperRichTextBox.Font = new Font("Bahnschrift", float.Parse(toolStripComboBox1.Text));
            DownRichTextBox.Font = new Font("Bahnschrift", float.Parse(toolStripComboBox1.Text));
            UpperRichTextBox.Update();
            DownRichTextBox.Update();
        }
        private void AddPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Упс!");
        }
        private void PagesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PagesCB.Focused)
            {
                SelectPage?.Invoke(this, PagesCB.SelectedIndex + 1);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveButton_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.X))
            {
                CutButton_Click(this, EventArgs.Empty);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                CopyButton_Click(this, EventArgs.Empty);
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                PasteButton_Click(this, EventArgs.Empty);
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                FolderButton_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                UpperRichTextBox.SelectAll();
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                FileButton_Click(this, EventArgs.Empty);
            }
            else if (keyData == (Keys.Control | Keys.W))
            {
                //ЗАКРЫТИЕ ВКЛАДКИ
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
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

        private void MainForm_DragDrop(object sender, DragEventArgs e)
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

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            ResourceManager res = new ResourceManager("CompileTeijkhrebKursach.Resources.Resource_ru", typeof(MainForm).Assembly);
            UpdateControlsText(this,res);
        }

        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            ResourceManager res = new ResourceManager("CompileTeijkhrebKursach.Resources.Resource_en", typeof(MainForm).Assembly);
            UpdateControlsText(this, res);
        }
    }
}
