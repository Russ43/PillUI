using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text; 
using System.Windows.Input;


namespace PillUI
{
	// Mostly ported from
	// http://www.wpftutorial.net/delegatecommand.html
	public class DelegateCommand : ICommand
	{
		// fields
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _execute;


		// events
		public event EventHandler CanExecuteChanged;


		// constructors
		public DelegateCommand(Action<object> execute)
			: this(execute, null)
		{
		}

		public DelegateCommand(Action<object> execute,
			Predicate<object> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}


		// ICommand methods
		public bool CanExecute(object parameter)
		{
			if(_canExecute == null)
			{
				return true;
			}

			return _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}


		// methods
		public void RaiseCanExecuteChanged()
		{
			if(CanExecuteChanged != null)
			{
				CanExecuteChanged(this, EventArgs.Empty);
			}
		}
	}
}

