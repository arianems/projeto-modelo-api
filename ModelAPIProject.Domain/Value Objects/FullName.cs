using ModelAPIProject.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenAPI.Domain.Value_Objects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string Surname { get; private set; }

        public FullName(string firstName, string? middleName, string surname)
        {
            if ((string.IsNullOrEmpty(firstName) || firstName.Length <= 1 ) 
                || (string.IsNullOrEmpty(surname) || surname.Length <= 1))
            {
                throw new Exception("Invalid name and/or surname.");
            }

            FirstName = firstName.Trim().ToUpper();
            MiddleName = middleName?.Trim().ToUpper();
            Surname = surname.Trim().ToUpper();
        }

        public override string ToString()
        {
            if(!string.IsNullOrEmpty(MiddleName))
                return $"{FirstName} {MiddleName} {Surname}";
            else
                return $"{FirstName} {Surname}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;

            if (MiddleName != null) yield return MiddleName;

            yield return Surname;

        }
    }
}
