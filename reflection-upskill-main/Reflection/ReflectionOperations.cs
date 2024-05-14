using System.Reflection;

[assembly: CLSCompliant(true)]

namespace Reflection
{
    public static class ReflectionOperations
    {
        public static string GetTypeName(object obj)
        {
            Type type = obj.GetType();
            return type.Name;
        }

        public static string GetFullTypeName<T>()
        {
            Type type = typeof(T);
            return type.FullName!;
        }

        public static string GetAssemblyQualifiedName<T>()
        {
            Type type = typeof(T);
            return type.AssemblyQualifiedName!;
        }

        public static string[] GetPrivateInstanceFields(object obj)
        {
            Type type = obj.GetType();

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            string[] ans = new string[fieldInfos.Length];

            for (int i = 0; i < fieldInfos.Length; i++)
            {
                ans[i] = fieldInfos[i].Name;
            }

            return ans;
        }

        public static string[] GetPublicStaticFields(object obj)
        {
            Type type = obj.GetType();

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Static | BindingFlags.Public);

            string[] ans = new string[fieldInfos.Length];

            for (int i = 0; i < fieldInfos.Length; i++)
            {
                ans[i] = fieldInfos[i].Name;
            }

            return ans;
        }

        public static string?[] GetInterfaceDataDetails(object obj)
        {
            Type type = obj.GetType();

            Type[] interfaceInfos = type.GetInterfaces();

            string[] ans = new string[interfaceInfos.Length];

            for (int i = 0; i < interfaceInfos.Length; i++)
            {
                ans[i] = interfaceInfos[i].FullName!;
            }

            return ans;
        }

        public static string?[] GetConstructorsDataDetails(object obj)
        {
            Type type = obj.GetType();

            ConstructorInfo[] interfaceInfos = type.GetConstructors();

            string?[] ans = new string[interfaceInfos.Length];

            for (int i = 0; i < interfaceInfos.Length; i++)
            {
                ans[i] = interfaceInfos[i].ToString();
            }

            return ans;
        }

        public static string?[] GetTypeMembersDataDetails(object obj)
        {
            Type type = obj.GetType();

            MemberInfo[] interfaceInfos = type.GetMembers();

            string?[] ans = new string[interfaceInfos.Length];

            for (int i = 0; i < interfaceInfos.Length; i++)
            {
                ans[i] = interfaceInfos[i].ToString();
            }

            return ans;
        }

        public static string?[] GetMethodDataDetails(object obj)
        {
            Type type = obj.GetType();

            MethodInfo[] interfaceInfos = type.GetMethods();

            string?[] ans = new string[interfaceInfos.Length];

            for (int i = 0; i < interfaceInfos.Length; i++)
            {
                ans[i] = interfaceInfos[i].ToString();
            }

            return ans;
        }

        public static string?[] GetPropertiesDataDetails(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] interfaceInfos = type.GetProperties();

            string?[] ans = new string[interfaceInfos.Length];

            for (int i = 0; i < interfaceInfos.Length; i++)
            {
                ans[i] = interfaceInfos[i].ToString();
            }

            return ans;
        }
    }
}
