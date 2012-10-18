using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.Utility
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public class ReflectionUtil
    {
        #region ConvertTo

        /// <summary>
        /// 获取数组中对象的类型
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static Type[] ConvertTo(object[] objs)
        {
            //检查数组长度
            if ((objs == null) || (objs.Length == 0))
            {
                return new Type[0];
            }
            Type[] typeArray = new Type[objs.Length];
            //
            for (int i = 0; i < objs.Length; i++)
            {
                typeArray[i] = objs[i].GetType();
            }
            return typeArray;
        }

        #endregion

        #region CreateInstance

        /// <summary>
        /// 根据类型创建对象实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>对象实例</returns>
        public static object CreateInstance(Type type)
        {
            return CreateInstance(type, new object[0]);
        }

        /// <summary>
        /// 根据类型和应用程序集名称创建对象实例
        /// </summary>
        /// <param name="assemblyName">应用程序集名称</param>
        /// <param name="typeName">类型</param>
        /// <returns>对象实例</returns>
        public static object CreateInstance(string assemblyName, string typeName)
        {
            return CreateInstance(assemblyName, typeName, new object[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, object[] args)
        {
            return CreateInstance(type, args, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, BindingFlags flags)
        {
            object[] args = new object[0];
            return CreateInstance(type, args, flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(string assemblyName, string typeName, object[] args)
        {
            return CreateInstance(assemblyName, typeName, args, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, object[] args, BindingFlags flags)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            Type[] types = ConvertTo(args);
            ConstructorInfo info = type.GetConstructor(flags, null, types, null);
            if (info == null)
            {
                throw new NullReferenceException(string.Format("invaild constructor for name \"{0}\"", info));
            }
            if (args == null)
            {
                return info.Invoke(new object[0]);
            }
            return info.Invoke(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static object CreateInstance(string assemblyName, string typeName, object[] args, BindingFlags flags)
        {
            if (assemblyName == null)
            {
                throw new ArgumentNullException("assemblyName");
            }
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }
            return CreateInstance(GetType(assemblyName, typeName), args, flags);
        }

        #endregion

        #region FindInterface

        public static bool FindInterface(Type type, string interfaceName)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (interfaceName == null)
            {
                throw new ArgumentNullException("interfaceName");
            }
            return (type.FindInterfaces(new TypeFilter(FindInterfaceFilter), interfaceName).Length > 0);
        }

        public static bool FindInterface(Type type, Type @interface)
        {
            if (@interface == null)
            {
                throw new ArgumentNullException("@interface");
            }
            return FindInterface(type, @interface.FullName);
        }

        public static bool FindInterfaceFilter(Type typeObj, object criteriaObj)
        {
            return (typeObj.ToString() == criteriaObj.ToString());
        }

        #endregion

        #region GetType

        public static Type GetType(string fullName)
        {
            string str;
            string str2;
            if (fullName == null)
            {
                throw new ArgumentNullException("fullName");
            }
            ParseTypeName(fullName, out str, out str2);
            return GetType(str, str2);
        }

        public static Type GetType(string assemblyName, string typeName)
        {
            if (assemblyName == null)
            {
                throw new ArgumentNullException("assemblyName");
            }
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly == null)
            {
                throw new NullReferenceException(string.Format("invaild assembly for name \"{0}\"", assemblyName));
            }
            Type type = assembly.GetType(typeName, false);
            if (type == null)
            {
                throw new NullReferenceException(string.Format("invaild type for type \"{0}\"", type));
            }
            return type;
        }

        #endregion

        #region ParseTypeName

        public static void ParseTypeName(string fullName, out string assemblyName, out string typeName)
        {
            if (fullName == null)
            {
                throw new ArgumentNullException("fullName");
            }
            if (fullName == string.Empty)
            {
                throw new ArgumentException("fullName");
            }
            string[] strArray = fullName.Split(new char[] { ',' });
            if (strArray.Length == 1)
            {
                throw new ArgumentException("Invaild fullName");
            }
            typeName = strArray[0].Trim();
            assemblyName = string.Join(",", strArray, 1, strArray.Length - 1).Trim();
        }

        #endregion


        /// <summary>
        /// 获取对象的属性的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            PropertyInfo prop = GetProperty(obj, propertyName);
            if (!PropertyHasValue(obj, prop))
                return "No value";
            return prop.GetValue(obj, null);
        }

        /// <summary>
        /// 获取对象的属性
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        private static PropertyInfo GetProperty(object obj, string propertyName)
        {
            Type type = obj.GetType();
            return type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the FieldInfo thus named
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <param name="field">Field.</param>
        /// <returns></returns>
        private static FieldInfo GetField(object obj, string field)
        {
            Type type = obj.GetType();
            return type.GetField(field, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase);
        }

        /// <summary>
        /// Check if the property is not null and can be read and is no indexed.
        /// This is done to know if it can be read safely.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <param name="prop">Prop.</param>
        /// <returns></returns>
        private static bool PropertyHasValue(object obj, PropertyInfo prop)
        {
            if (obj == null || prop == null || !prop.CanRead || prop.GetIndexParameters().Length > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether type is simple enough to need just ToString()
        /// to show its state.
        /// (string,int, bool, enums are simple.
        /// Anything else is false.
        /// </summary>
        public static bool IsSimpleType(Type type)
        {
            if (type.IsEnum || type.IsPrimitive || type == typeof(string)
                || type == typeof(DateTime))
                return true;

            return false;
        }

        /// <summary>
        /// Determines whether the object is simple.
        /// An object is simple if its type is simple or if it's null.
        /// </summary>
        public static bool IsSimpleObject(object obj)
        {
            if (obj == null) return true;
            return IsSimpleType(obj.GetType());
        }

        /// <summary>
        /// Gets the name of an object.
        /// The name of the object is it's type name or the value of
        /// its Name property or field
        /// </summary>
        public static string GetName(object obj)
        {
            string s = GetNameOrEmpty(obj);
            if (s != "")
                return s;

            return "{" + obj.GetType().Name + "}";
        }

        /// <summary>
        /// Gets the field value from object, and return 
        /// </summary>
        public static object GetFieldValue(object obj, FieldInfo field)
        {
            if (obj == null || field == null)
                return "No value";
            return field.GetValue(obj);
        }

        /// <summary>
        /// Gets the value of the object, if the object is simple, the returned string is
        /// the object ToString(), otherwise, it's the object name (if it has one) or the object type.
        /// </summary>
        public static string GetValue(object obj)
        {
            if (obj == null)
                return "null";
            if (IsSimpleObject(obj))
                return obj.ToString();

            return GetName(obj);
        }



        /// <summary>
        /// Converts from string to the type.
        /// Can covert from string, enums booleans, bytes, int32 and datetime
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="type">Type.</param>
        /// <returns></returns>
        public static object ConvertTo(string text, Type type)
        {
            if (type == typeof(string))
                return text == "" ? null : text;
            if (type.IsEnum)
                return Enum.Parse(type, text);
            if (type == typeof(Boolean))
                return bool.Parse(text);
            if (type == typeof(byte))
                return byte.Parse(text);
            if (type == typeof(Int32))
                return Int32.Parse(text);
            if (type == typeof(DateTime))
                return DateTime.Parse(text);

            throw new NotSupportedException("Converting type " + type.FullName + " is not supported.");
        }

        public static void AddToArray(FieldInfo field, object instance, object val)
        {
            if (!field.FieldType.IsArray)
                throw new InvalidOperationException("Field's type is not an array!");
            Array c = (Array)field.GetValue(instance);
            ArrayList list = new ArrayList();
            if (c != null)
                list.AddRange(c);
            list.Add(val);
            field.SetValue(instance, list.ToArray(field.FieldType.GetElementType()));
        }



        /// <summary>
        /// Gets the value of a property or field name in the object.
        /// Or return empty string if there aren't any.
        /// </summary>
        public static string GetNameOrEmpty(object obj)
        {
            if (obj == null)
                return "null";
            PropertyInfo prop = GetProperty(obj, "Name");
            object val = null;
            if (PropertyHasValue(obj, prop))
                val = prop.GetValue(obj, null);
            else
            {
                FieldInfo field = GetField(obj, "Name");
                if (field != null)
                    val = field.GetValue(obj);
            }
            return val != null ? val.ToString() : "";
        }

        /// <summary>
        /// Sets the name property or value of an object to the value of name.
        /// Does nothing if the object doesn't have any fields or properties named 'name'
        /// </summary>
        public static void SetName(object obj, string name)
        {
            PropertyInfo prop = GetProperty(obj, "Name");
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, name, null);
            else
            {
                FieldInfo field = GetField(obj, "Name");
                if (field != null)
                    field.SetValue(obj, name);
            }
        }

        public static void RemoveFromArray(FieldInfo field, object instance, int index)
        {
            Array c = (Array)field.GetValue(instance);
            ArrayList list = new ArrayList(c.Length - 1);
            for (int i = 0; i < c.Length; i++)
            {
                if (i != index)
                    list.Add(c.GetValue(i));
            }
            field.SetValue(instance, list.ToArray(field.FieldType.GetElementType()));
        }

        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().
                GetProperties(BindingFlags.Instance |
                              BindingFlags.GetProperty | BindingFlags.Public |
                              BindingFlags.NonPublic);
        }

        public static object GetPropertyValue(PropertyInfo property, object obj)
        {
            if (property.CanRead && property.GetIndexParameters().Length == 0)
            {
                if (ReflectionUtil.IsSimpleType(property.PropertyType))
                    return property.GetValue(obj, null);

                return property.GetValue(obj, null);
            }
            return "{indexed or write only property}";
        }

        /// <summary>
        /// Gets the readable (non indexed) properties names and values.
        /// The keys holds the names of the properties.
        /// The values are the values of the properties
        /// </summary>
        public static IDictionary GetPropertiesDictionary(object obj)
        {
            object propertyValue = null;
            Hashtable ht = new Hashtable();
            foreach (PropertyInfo property in obj.GetType().
                GetProperties(BindingFlags.Instance |
                              BindingFlags.GetProperty | BindingFlags.Public |
                              BindingFlags.NonPublic))
            {
                if (property.CanRead && property.GetIndexParameters().Length == 0)
                {
                    if (ReflectionUtil.IsSimpleType(property.PropertyType))
                    {
                        propertyValue = property.GetValue(obj, null);
                        ht[property.Name] = (propertyValue == null ? null : propertyValue.ToString());
                    }
                    else
                        ht[property.Name] = property.GetValue(obj, null);
                }
            }
            return ht;
        }

        /// <summary>
        /// Gets the fields names and values.
        /// The keys holds the names of the fields.
        /// The values hold the value of the field if it's a simple type, 
        /// or the name of the field's type.
        /// </summary>
        public static IDictionary GetFieldsDictionary(object obj)
        {
            Hashtable ht = new Hashtable();
            foreach (FieldInfo field in obj.GetType().GetFields())
            {
                ht[field.Name] = ReflectionUtil.IsSimpleType(field.FieldType) ? field.GetValue(obj) : field.FieldType.Name;
            }
            return ht;
        }

        /// <summary>
        /// An object has value if it's not null, 
        /// an collection containing elements and a non-empty string
        /// </summary>
        public static bool HasValue(object value)
        {
            if (value == null)
                return false;
            ICollection c = value as ICollection;
            if (c != null)
                return c.Count > 0;
            string s = value as string;
            if (s != null)
                return s.Length > 0;
            return true;
        }

        public static void SetStringValueToPorperty<T>(string value, PropertyInfo info, T instance)
        {
            if (info.PropertyType == typeof(string))
            {
                info.SetValue(instance, value, null);
            }
            if (info.PropertyType == typeof(int))
            {
                info.SetValue(instance, int.Parse(value), null);
            }
            if (info.PropertyType == typeof(DateTime))
            {
                info.SetValue(instance, DateTime.Parse(value), null);
            }
            if (info.PropertyType == typeof(decimal))
            {
                info.SetValue(instance, decimal.Parse(value), null);
            }
            if (info.PropertyType == typeof(double))
            {
                info.SetValue(instance, double.Parse(value), null);
            }
            if (info.PropertyType == typeof(bool))
            {
                info.SetValue(instance, bool.Parse(value), null);
            }
        }

        public static Dictionary<string, string> GetDictionaryValues<T>(T obj)
        {
            Type type = typeof(T);

            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>();

            foreach (PropertyInfo dataProperty in propertyInfos)
            {
                object objValue = dataProperty.GetValue(obj, null);
                if (objValue != null)
                {
                    nameValueCollection.Add(dataProperty.Name, objValue.ToString());
                }
                else
                {
                    nameValueCollection.Add(dataProperty.Name, "");
                }
            }

            return nameValueCollection;
        }


        public static Dictionary<string, string> GetEntityDictionaryValues<T, TK>(T obj) where T : BaseTableEntity<TK>
        {
            Type type = typeof(T);

            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>();

            foreach (PropertyInfo dataProperty in propertyInfos)
            {
                object objValue = dataProperty.GetValue(obj, null);
                if (objValue != null)
                {
                    //判断是否是外键字段
                    if (objValue is BaseTableEntity<TK>)
                    {
                        nameValueCollection.Add(dataProperty.Name, ((BaseTableEntity<TK>)objValue).GetDataEntityKey().ToString());
                    }
                    else
                    {
                        nameValueCollection.Add(dataProperty.Name, objValue.ToString());
                    }
                }
                else
                {
                    nameValueCollection.Add(dataProperty.Name, "");
                }
            }

            return nameValueCollection;
        }
    }
}