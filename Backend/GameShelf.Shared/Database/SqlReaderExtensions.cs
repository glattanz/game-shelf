using Newtonsoft.Json;
using System.Data;
using System.Globalization;

namespace ProjectManagement.Shared.Database
{
    public static class SqlReaderExtensions
    {
        public static string GetString(this IDataRecord reader, string fieldName)
        {
            string returnValue = string.Empty;

            object value = reader[fieldName];

            if (!Convert.IsDBNull(value))
            {
                returnValue = Convert.ToString(value, CultureInfo.InvariantCulture);
            }

            return returnValue;
        }

        public static bool GetBooleanFromBit(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value))
            {
                return false;
            }

            return Convert.ToBoolean(value);
        }

        public static int GetInt32(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value))
            {
                return 0;
            }

            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static int? GetInt32Nullable(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value) || value == null)
            {
                return null;
            }

            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static long GetInt64(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value))
            {
                return 0;
            }

            return Convert.ToInt64(value, CultureInfo.InvariantCulture);
        }

        public static double GetDouble(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value))
            {
                return 0.0;
            }

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        public static float GetFloat(this IDataRecord reader, string fieldName)
        {
            var value = reader[fieldName];

            if (Convert.IsDBNull(value))
            {
                return (float)0.0;
            }

            return (float)Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        public static Guid GetGuid(this IDataRecord reader, string fieldName)
        {
            Guid returnValue = Guid.Empty;

            object value = reader[fieldName];
            if (!Convert.IsDBNull(value))
            {
                returnValue = Guid.Parse(Convert.ToString(value, CultureInfo.InvariantCulture));
            }

            return returnValue;
        }

        public static DateTime GetDateTime(this IDataRecord reader, string fieldName)
        {
            DateTime returnValue = DateTime.MinValue;

            object value = reader[fieldName];

            if (!Convert.IsDBNull(value))
            {
                returnValue = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
            }

            return returnValue;
        }

        public static DateTime? GetDateTimeNullable(this IDataRecord reader, string fieldName)
        {
            DateTime? returnValue = null;

            object value = reader[fieldName];

            if (!Convert.IsDBNull(value) && value != null)
            {
                returnValue = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
            }

            return returnValue;
        }

        public static byte[] GetBytes(this IDataRecord reader, string fieldName)
        {
            object value = reader[fieldName];
            if (!Convert.IsDBNull(value))
            {
                return (byte[])value;
            }

            return new byte[0];
        }

        public static byte[] GetBytesOrNull(this IDataRecord reader, string fieldName)
        {
            object value = reader[fieldName];
            if (!Convert.IsDBNull(value))
            {
                return (byte[])value;
            }

            return null;
        }

        public static IList<T> GetList<T>(this IDataRecord reader, string fieldName)
            where T : class
        {
            object value = reader[fieldName];
            if (Convert.IsDBNull(value))
            {
                return new List<T>();
            }

            var json = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            return JsonConvert.DeserializeObject<IList<T>>(json);
        }
    }
}