using OnlineStore.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string _header;
        private string _content;

        public string Header
        {
            get => _header;
            set
            {
                if (_header != value)
                {
                    _header = value;
                    OnPropertyChanged(nameof(Header));
                }
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _subtitle;

        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                if (_subtitle != value)
                {
                    _subtitle = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}