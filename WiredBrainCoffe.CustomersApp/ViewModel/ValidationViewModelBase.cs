using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errorsByPropertyName = new();
        public bool HasErrors => this.errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && this.errorsByPropertyName.ContainsKey(propertyName)
                ? this.errorsByPropertyName[propertyName]
                : Enumerable.Empty<string>();
        }

        protected virtual void OnErrorChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        protected void AddError(string error, 
            [CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null) return;

            if (!this.errorsByPropertyName.ContainsKey(propertyName))
            {
                this.errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!this.errorsByPropertyName[propertyName].Contains(error))
            {
                this.errorsByPropertyName[propertyName].Add(error);
                OnErrorChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = null)
        { 
            if (propertyName is null) return;

            if (this.errorsByPropertyName.ContainsKey(propertyName))
            {
                this.errorsByPropertyName.Remove(propertyName);
                OnErrorChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }
}
