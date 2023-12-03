using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Book_Store.src
{
	/// <inheritdoc cref="ICommand"/>
	class RelayCommand : ICommand
	{
		private Action<object> _execute;
		private Func<object, bool> _canExecute;

		/// <inheritdoc cref="ICommand.CanExecuteChanged"/>
		public event EventHandler? CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		/// <inheritdoc cref="ICommand.CanExecute(object?)"/>
		public bool CanExecute(object? parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}
		/// <inheritdoc cref="ICommand.Execute(object?)"/>
		public void Execute(object? parameter)
		{
			_execute(parameter);
		}
	}
}
