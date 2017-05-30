using System;
using System.Windows;
using System.Windows.Input;

namespace Z12_Commands
{
    public class TestCommand : ICommand
    {
        private bool _whatShouldWeReturnForCanExecute;

        public bool WhatShouldWeReturnForCanExecute
        {
            get => _whatShouldWeReturnForCanExecute;
            set
            {
                if (_whatShouldWeReturnForCanExecute == value)
                {
                    return;
                }

                _whatShouldWeReturnForCanExecute = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _whatShouldWeReturnForCanExecute;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("TestCommand executed");
        }

        public event EventHandler CanExecuteChanged;
    }
}
