using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using BeatSaberMarkupLanguage.Attributes;

namespace SimplePriority
{
    public class SettingsChanged : INotifyPropertyChanged
    {
        #region Properties

        [UIValue("priorities")]
        public List<object> Priorities = ((ProcessPriorityClass[])Enum.GetValues(typeof(ProcessPriorityClass))).Cast<object>().ToList();
        [UIValue("priority")]
        public ProcessPriorityClass Priority
        {
            get => Configuration.Instance.Priority;
            set
            {
                Configuration.Instance.Priority = value; 
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
