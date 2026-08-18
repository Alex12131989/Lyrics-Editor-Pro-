using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsEditorPro.ViewModels
{
    public class Navigation
    {
        private BaseVM _currentVM;

        public BaseVM CurrentVM
        {
            get => _currentVM; 
            set
            {
                _currentVM = value;
                OnCurrentVMChanged();
            }
        }

        private void OnCurrentVMChanged()
        {
            CurrentVMChanged?.Invoke();
        }

        public event Action CurrentVMChanged;
    }
}