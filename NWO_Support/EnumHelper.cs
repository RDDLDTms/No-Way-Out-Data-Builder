using System.ComponentModel;

namespace NWO_Support
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field is null)
                return string.Empty;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
