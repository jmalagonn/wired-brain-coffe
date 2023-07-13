using System;
using System.Windows.Input;

namespace WiredBrainCoffe.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object?, bool>? canExecute;

        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);

            this.execute = execute;
            this.canExecute=canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => this.canExecute is null || this.canExecute(parameter);

        public void Execute(object? parameter) => this.execute(parameter);
    }
}
