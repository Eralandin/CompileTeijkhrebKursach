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
        event EventHandler<Operation> AddUndo;
        event EventHandler Undo;
        event EventHandler Repeat;
        event EventHandler<string> SaveAsFile;
        event FormClosingEventHandler CloseProgram;
        void Message(string message);
        void InsertFileText(string text);
        void UndoToView(Operation operation);
        void RepeatToView(Operation operate);
    }
}
