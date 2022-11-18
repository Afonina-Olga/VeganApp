using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VeganGO.ViewModels
{
    public class ValidationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<ValidationResult>> _errors = new Dictionary<string, List<ValidationResult>>();

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.GetValueOrDefault(propertyName, null);
        }

        public void ValidateProperty<T>(T value, string propertyName)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                value,
                new ValidationContext(this)
                {
                    MemberName = propertyName
                },
                validationResults);

            if (isValid)
            {
                _errors.Remove(propertyName);
            }
            else
            {
                _errors[propertyName] = validationResults;
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ClearErrors(string propertyName)
        {
            _errors.Remove(propertyName);
        }

        public void ClearErrors()
        {
            _errors.Clear();
        }
    }
}