using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers.Lib.Converters
{
    class UserTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            return
                sourceType == typeof(int) ||
                base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            if (value is int)
                return new User((int)value);

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext context,
            Type destinationType)
        {
            return
                destinationType == typeof(int) ||
                base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(int))
                return ((User)value).Id;

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
