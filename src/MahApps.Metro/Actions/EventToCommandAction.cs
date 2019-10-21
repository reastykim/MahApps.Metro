using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MahApps.Metro.Actions
{
    public class EventToCommandAction : TriggerAction<DependencyObject>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommandAction), new PropertyMetadata(null));

        protected override void Invoke(object parameter)
        {
            if (Command != null)
            {
                if (Command.CanExecute(parameter))
                {
                    Command.Execute(parameter);
                }
            }
        }
    }
}
