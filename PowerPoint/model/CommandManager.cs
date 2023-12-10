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

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void UndoCommand()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.Unexcute();
                _redoStack.Push(command);
            }
        }

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
