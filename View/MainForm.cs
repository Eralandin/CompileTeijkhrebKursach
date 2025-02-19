using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.Presenter;
using CompileTeijkhrebKursach.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CompileTeijkhrebKursach.View
{
    public partial class MainForm : Form, IMain
    {
        private readonly MainPresenter _presenter;
        private int selectionIndex = 0;
        private bool isRightButtonClickOverridden = false;
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }
        public event EventHandler<string> CreateFile;
        public event EventHandler<string> OpenFile;
        public event EventHandler<string> SaveFile;
        public event EventHandler StartEnd;
        public event EventHandler OpenHelp;
        public event EventHandler About;
        public event EventHandler<Operation> AddUndo;
        public event EventHandler Undo;
        public event EventHandler Repeat;
        public event EventHandler<string> SaveAsFile;
        public event FormClosingEventHandler CloseProgram;
        public void Message(string message)
        {
            MessageBox.Show(message);
        }
        public void InsertFileText(string text)
        {
            UpperRichTextBox.Text = text;
        }
        public void UndoToView(Operation operation)
        {
            if (operation.isCut)
            {

            }
            else
            {
                int startPos = operation.position;
                foreach (char label in operation.containtment.ToCharArray())
                {
                    UpperRichTextBox.Text = UpperRichTextBox.Text.Insert(startPos,label.ToString());
                    startPos++;
                }
            }
        }
        public void RepeatToView(Operation operate)
        {
            UpperRichTextBox.Text = UpperRichTextBox.Text.Insert(UpperRichTextBox.SelectionStart, operate.containtment);
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
        //Отмена предыдущей операции
        private void LeftButton_Click(object sender, EventArgs e)
        {
            Undo?.Invoke(this, EventArgs.Empty);
        }
        //Повтор последней операции (кроме вырезать и множественного удаления)
        private void RightButton_Click(object sender, EventArgs e)
        {
            Repeat?.Invoke(this, EventArgs.Empty);
        }
        //Копировать
        private void CopyButton_Click(object sender, EventArgs e)
        {

        }
        //Вырезать
        private void CutButton_Click(object sender, EventArgs e)
        {

        }
        //Вставить
        private void PasteButton_Click(object sender, EventArgs e)
        {

        }
        //Пуск (пока не делаем)
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

        private void UpperRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && UpperRichTextBox.SelectedText.Length == 0)
            {
                if (!isRightButtonClickOverridden)
                {
                    RightButton.Click -= RightButton_Click;
                    RightButton.Click += DeleteRepeat;
                    isRightButtonClickOverridden = true;
                }
                AddUndo?.Invoke(this, new Operation("",UpperRichTextBox.SelectionStart,false,true));
            }
            else if (e.KeyCode == Keys.Back)
            {
                RightButton.Enabled = false;
            }
            else
            {
                RightButton.Enabled = true;

                if (isRightButtonClickOverridden)
                {
                    RightButton.Click -= DeleteRepeat;
                    RightButton.Click += RightButton_Click;
                    isRightButtonClickOverridden = false;
                }
            }
        }
        public void DeleteRepeat(object sender, EventArgs e)
        {
            UpperRichTextBox.Focus();
            UpperRichTextBox.SelectionStart = selectionIndex;
            if (UpperRichTextBox.Text.Length > 0 && UpperRichTextBox.SelectionStart != 0)
            {
                UpperRichTextBox.Text = UpperRichTextBox.Text.Remove(UpperRichTextBox.SelectionStart - 1, 1);
                UpperRichTextBox.SelectionStart = selectionIndex - 1;
            }
        }
        private void UpperRichTextBox_Leave(object sender, EventArgs e)
        {
            selectionIndex = UpperRichTextBox.SelectionStart;
        }
    }
}
