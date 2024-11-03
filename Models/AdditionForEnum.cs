using System.ComponentModel.DataAnnotations;

namespace LR10.Models
{
    public static class AdditionForEnum
    {
        public static string GetDisplayName(Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }
    }
}
