using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.View;
using CompileTeijkhrebKursach.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private Operation lastUserOperation;
        private List<TextModel> textModels = new List<TextModel>();
        private int currentPageId;
        private string SaveFileStr1 = "Сохранить файл";
        private string SaveFileStr2 = "Сохранить файл";
        private string FileSaved = "Файл успешно сохранён";
        private string FileOpened = "Файл успешно открыт";

        public MainPresenter(IMain view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.CreateFile += CreateFile;
            _view.OpenFile += OpenFile;
            _view.SaveFile += SaveFile;
            _view.SaveAsFile += SaveAsFile;
            _view.CloseProgram += CloseProgram;
            _view.Repeat += Repeat;
            _view.SelectPage += SelectPage;
            _view.ChangeLastUserOperation += ChangeLastUserOperation;
            _view.NullLastUserOperation += NullLastUserOperation;
        }
        public void ChangeLastUserOperation(object sender, Operation lastUserOperation)
        {
            this.lastUserOperation = lastUserOperation ?? throw new ArgumentNullException( nameof(lastUserOperation));
            isSaved = false;
            _view.SetFlagToComboBoxItem(Path.GetFileName(editingFileName), isSaved);
        }
        public void NullLastUserOperation(object sender, EventArgs e)
        {
            this.lastUserOperation = null;
            isSaved = false;
            _view.SetFlagToComboBoxItem(Path.GetFileName(editingFileName), isSaved);
        }
        public void SelectPage(object sender, int index)
        {
            TextModel model = textModels.Find(x => x.id == index);
            if (model != null)
            {
                textModels[currentPageId-1].text = _view.GetText();
                textModels[currentPageId-1].isSaved = isSaved;
                textModels[currentPageId-1].lastText = _view.GetText();
                _view.SetLastText(model.lastText);
                currentPageId = model.id;
                editingFileName = model.editingFileName;
                isSaved = model.isSaved;
                lastUserOperation = null;
                _view.InsertFileText(model.text);
                _view.SetPage(Path.GetFileName(editingFileName));
            }
        }
        public void Repeat(object sender, EventArgs e)
        {
            if (lastUserOperation != null)
            {
                _view.RepeatToView(lastUserOperation);
            }
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
            foreach (var textModel in textModels)
            {
                if (textModel.editingFileName == fileDestination)
                {
                    SelectPage(this, textModels.Find(x => x.editingFileName == fileDestination).id);
                    return;
                }
            }
            string fileText = File.ReadAllText(fileDestination);
            string fileName = Path.GetFileName(fileDestination);
            TextModel newTextModel = new TextModel(fileDestination,textModels.Count + 1, fileText, lastUserOperation, isSaved, fileText);
            textModels.Add(newTextModel);
            _view.AddTab(fileName);
            currentPageId = newTextModel.id;
            lastUserOperation = null;
            editingFileName = fileDestination;
            _view.InsertFileText(fileText);
            _view.SetLastText(fileText);
            isSaved = true;
            _view.Message("Файл успешно открыт!");
        }
        public void SaveFile(object sender, string textToSave)
        {
            if (!string.IsNullOrEmpty(editingFileName))
            {
                System.IO.File.WriteAllText(editingFileName,textToSave);
                isSaved = true;
                _view.SetFlagToComboBoxItem(Path.GetFileName(editingFileName), isSaved);
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
                        _view.SetFlagToComboBoxItem(Path.GetFileName(editingFileName), isSaved);
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
    }
}
