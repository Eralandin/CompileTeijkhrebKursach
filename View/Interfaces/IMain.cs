using CompileTeijkhrebKursach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileTeijkhrebKursach.View.Interfaces
{
    public interface IMain
    {
        event EventHandler<string> CreateFile;
        event EventHandler<string> OpenFile;
        event EventHandler<string> SaveFile;
        event EventHandler StartEnd;
        event EventHandler OpenHelp;
        event EventHandler About;
        event EventHandler Repeat;
        event EventHandler<string> SaveAsFile;
        event FormClosingEventHandler CloseProgram;
        event EventHandler<int> SelectPage;
        event EventHandler<Operation> ChangeLastUserOperation;
        event EventHandler NullLastUserOperation;
        void Message(string message);
        void InsertFileText(string text);
        void RepeatToView(Operation operate);
        void AddTab (string fileName);
        string GetText();
        void SetLastText(string text);
        void SetPage(string pageName);
        void SetFlagToComboBoxItem(string itemName, bool flag);
    }
}
