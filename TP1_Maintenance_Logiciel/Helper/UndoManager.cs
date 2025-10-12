using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Maintenance_Logiciel.Members;

namespace TP1_Maintenance_Logiciel.Helper
{
    public static class UndoManager
    {
        private static readonly Stack<UndoEntry> _history = new();
        public static void Push(UndoEntry undoEntry)
        {
            _history.Push(undoEntry);
        }
        public static Action Undo = () =>
        {

            UndoEntry undoEntry = _history.Pop();
            undoEntry.Undo();
            Console.WriteLine(undoEntry.Description.ToString());
        };
    }
}
