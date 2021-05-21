using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NovoApp
{
    public class Words : INotifyPropertyChanged
    {
        private bool _found;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Found 
        {
            get => _found;
            set
            {
                _found = value;
                RaisePropertyChanged();
            } 
        }
        public string Name { get; set; }

        public Words(string name) => Name = name;

    }
}
