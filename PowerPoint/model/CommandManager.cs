using System.Collections.Generic;
using PowerPoint.model.command;

namespace PowerPoint.model {
    public class CommandManager {
        Model _model;
        Stack<ICommand> _undoStack;
        Stack<ICommand> _redoStack;

        public CommandManager(Model model) {
            _model = model;
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();
            UpdateRedoUndoButtonEnabled();
        }

        public void ExecuteCommand(ICommand command) {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
            UpdateRedoUndoButtonEnabled();
        }

        public void UndoCommand() {
            if (_undoStack.Count > 0) {
                ICommand command = _undoStack.Pop();
                command.ExecuteBack();
                _redoStack.Push(command);
            }

            UpdateRedoUndoButtonEnabled();
        }

        public void RedoCommand() {
            if (_redoStack.Count > 0) {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }

            UpdateRedoUndoButtonEnabled();
        }

        private void UpdateRedoUndoButtonEnabled() {
            if (_undoStack.Count > 0) {
                _model.UndoButtonEnabled = true;
            }
            else {
                _model.UndoButtonEnabled = false;
            }

            if (_redoStack.Count > 0) {
                _model.RedoButtonEnabled = true;
            }
            else {
                _model.RedoButtonEnabled = false;
            }
        }
    }
}