
using System;
using System.ComponentModel.DataAnnotations;
namespace TylorShop.Models_Customs
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayFirstNCharactersAttribute : Attribute
    {
        private readonly int _maxLength;

        public DisplayFirstNCharactersAttribute(int maxLength)
        {
            _maxLength = maxLength;
        }

        public string Truncate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length > _maxLength ? value.Substring(0, _maxLength) + "..." : value;
        }
    }

}
