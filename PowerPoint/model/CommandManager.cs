using PowerPoint.model.command;
using System.Collections.Generic;

namespace PowerPoint.model
{
    public class CommandManager
    {
        Model _model;
        Stack<ICommand> _undoStack;
        Stack<ICommand> _redoStack;

        public CommandManager(Model model)
        {
            _model = model;
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();
        }

        // execute
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        // undo
        public void UndoCommand()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.ExecuteBack();
                _redoStack.Push(command);
            }
        }

        // redo
        public void RedoCommand()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }
    }
}
