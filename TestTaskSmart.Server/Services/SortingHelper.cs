using System.Reflection;

namespace TestTaskSmart.Server.Services
{
    public class SortingHelper
    {
        public static IEnumerable<T> SortByProperty<T>(IEnumerable<T> source, string propertyName, string? sortType)
        {
            if (string.IsNullOrEmpty(propertyName))
                return source;

            PropertyInfo propertyInfo;

            if (propertyName.Contains('.'))
            {
                string[] parts = propertyName.Split('.');
                string lastPart = parts.Last();
                var currentType = typeof(T);
                foreach (var part in parts)
                {
                    propertyInfo = currentType.GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                        throw new ArgumentException($"No property '{part}' found on type '{currentType}'");

                    currentType = propertyInfo.PropertyType;
                }
            }
            else 
            {
                propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                    throw new ArgumentException($"No property '{propertyName}' found on type '{typeof(T)}'");
            }

            sortType = string.IsNullOrEmpty(sortType) ? "ASC" : sortType.ToUpper();

            return sortType.ToUpper() == "DESC"
                ? source.OrderByDescending(x => GetValueByPath(x, propertyName))
                : source.OrderBy(x => GetValueByPath(x, propertyName));
        }

        private static object GetValueByPath(object obj, string path)
        {
            var parts = path.Split('.');
            foreach (var part in parts)
            {
                var prop = obj.GetType().GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (prop == null)
                    throw new ArgumentException($"No property '{part}' found on type '{obj.GetType()}'");
                obj = prop.GetValue(obj, null);
            }
            return obj;
        }
    }
}
