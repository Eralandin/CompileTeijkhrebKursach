using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.View;
using CompileTeijkhrebKursach.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompileTeijkhrebKursach.Presenter
{
    public class MainPresenter
    {
        private readonly IMain _view;
        private string editingFileName = "";
        private bool isSaved = true;
        private Operation lastUserEdit;
        private Stack<Operation> undoList;

        public MainPresenter(IMain view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.CreateFile += CreateFile;
            _view.OpenFile += OpenFile;
            _view.SaveFile += SaveFile;
            _view.AddUndo += AddUndo;
            _view.Undo += Undo;
            _view.SaveAsFile += SaveAsFile;
            _view.CloseProgram += CloseProgram;
            _view.Repeat += Repeat;
            undoList = new Stack<Operation>();
        }
        public void Repeat(object sender, EventArgs e)
        {
            Operation repeatable = lastUserEdit;
            _view.RepeatToView(repeatable);
        }
        public void CreateFile(object sender, string fileName)
        {
            System.IO.File.Create(fileName).Close();
            _view.Message("Файл успешно создан!");
        }
        public void CloseProgram(object sender, FormClosingEventArgs e)
        {
            if (isSaved != true)
            {
                if (MessageBox.Show("Файл не сохранён. Вы уверены, что хотите закрыть программу?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        public void OpenFile(object sender, string fileDestination)
        {
            string fileText = File.ReadAllText(fileDestination);
            undoList.Clear();
            editingFileName = fileDestination;
            _view.InsertFileText(fileText);
            isSaved = true;
            _view.Message("Файл успешно открыт!");
        }
        public void SaveFile(object sender, string textToSave)
        {
            if (!string.IsNullOrEmpty(editingFileName))
            {
                System.IO.File.WriteAllText(editingFileName,textToSave);
                _view.Message("Файл успешно сохранён!");
            }
            else
            {
                if (MessageBox.Show("Не выбран редактируемый файл. Желаете создать файл?", "Отсутствует редактируемый файл", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog()==DialogResult.OK)
                    {
                        editingFileName = saveFileDialog.FileName;

                        System.IO.File.WriteAllText(editingFileName, textToSave);
                        isSaved = true;
                        _view.Message("Файл успешно сохранён!");
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        public void SaveAsFile(object sender, string textToSave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editingFileName = saveFileDialog.FileName;
                System.IO.File.WriteAllText(editingFileName, textToSave);
                isSaved = true;
                _view.Message("Файл успешно сохранён!");
            }
        }
        public void Undo(object sender, EventArgs e)
        {
            if (undoList.Count > 0)
            {
                _view.UndoToView(undoList.Pop());
            }
        }
        public void AddUndo(object sender, Operation undoText)
        {
            isSaved = false;
            undoList.Push(undoText);
            if ((sender as MainForm).UpperRichTextBox.Focused)
            {
                lastUserEdit = undoText;
            }
        }
    }
}
