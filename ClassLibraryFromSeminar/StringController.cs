using System.Reflection;
using System.Text;
using ReflectionHomeWorkV02.Serviсes;


namespace ClassLibraryFromSeminar {
    public static class StringController {
        public static string ObjectToString(object obj) {
            StringBuilder stringBuilder = new StringBuilder();
            var type = obj.GetType();

            stringBuilder.Append(type + "\n");
            stringBuilder.Append(type.Assembly + "\n");
            stringBuilder.Append(type.Namespace + "\n");
            stringBuilder.Append(type.Name + "\n");

            var properties = type.GetProperties(
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy |
                BindingFlags.Public
            );
            foreach (var item in properties) {
                var value = item.GetValue(obj);

                var customNameAttribute = item.GetCustomAttribute<CustomName>();
                if (customNameAttribute != null) {
                    var propertyName = customNameAttribute.Name;
                    stringBuilder.Append(propertyName + ":");
                }
                else {
                    stringBuilder.Append(item.Name + ":");
                }

                if (item.PropertyType == typeof(char[])) {
                    stringBuilder.Append(new String(value as char[]) + "\n");
                }
                else {
                    stringBuilder.Append(value + "\n");
                }
            }

            return stringBuilder.ToString();
        }

        public static object? StringToObject<T>(string endString) where T : class {
            string[] str = endString.Split("\n");
            Dictionary<string, string> dictionary =
                (from item in str
                    where item.Contains("SomePropertyNumber")
                          || item.Contains("SomePropertyText")
                    select item.Split(":")
                )
                .ToDictionary(str2 => str2[0], str2 => str2[1]);
            
            var classType = typeof(T);
            var instance = Activator.CreateInstance(
                classType,
                new object[] {
                    int.Parse(dictionary["SomePropertyNumber"]),
                    dictionary["SomePropertyText"]
                })
                as T;

            // object? obj = Activator.CreateInstance("MyClass", new Ob);


            return instance;
        }
    }
}