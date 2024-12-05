using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using lab11;
using System.IO;

namespace lab11
{
    static class Reflector
    {
        private static string fileName = "File.txt";
        public static void getNameAssembly(string className)
        {
            Type classType = Type.GetType(className, true, true);
            using (StreamWriter sw = new StreamWriter(fileName, append: false))
            {
                sw.WriteLine($"\nСборка: {classType.Assembly.FullName}");
            }
        }
        public static void publicConstructor(string className)
        {
            Type classType = Type.GetType(className, true, true);

            if (classType.IsPublic)
            {
                using (StreamWriter sw = new StreamWriter(fileName, append: true))
                {
                    sw.WriteLine("\nПубличный конструктор присутствует");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(fileName, append: true))
                {
                    sw.WriteLine("\nПубличный конструктор отсутствует");
                }
            }
        }
        public static void publicMethod(string className)
        {
            Type classType = Type.GetType(className, true, true);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine($"\nКоличество публичных методов в классе {className}: {classType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Length}");
                foreach (MethodInfo item in classType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    sw.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
            }
            
        }
        public static void fieldsAndProperties(string className)
        {
            Type classType = Type.GetType(className, true, true);
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine($"\nИнформация о полях и свойствах класса {className}");
                sw.WriteLine($"Количество свойств: {classType.GetProperties().Length}");
                sw.WriteLine($"Количество полей: {classType.GetFields().Length}");
                sw.WriteLine("Поля:");
                foreach (FieldInfo item in classType.GetFields())
                    sw.WriteLine($"Тип: {item.FieldType}\t Имя: {item.Name}");

                sw.WriteLine("Свойства:");
                foreach (PropertyInfo item in classType.GetProperties())
                    sw.WriteLine($"Тип: {item.PropertyType}\t Имя: {item.Name}");
            }
        }
        public static void getInterface(string className)
        {
            Type classType = Type.GetType(className, true, true);
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine($"\nКоличество интерфейсов в классе {className}: {classType.GetInterfaces().Length}");
                foreach (MemberInfo item in classType.GetInterfaces())
                    sw.WriteLine($"Тип: {item.MemberType}\t Имя: {item.Name}");
            }
        }
        public static void getNameOfMethods(string className, string paramType)
        {
            Type classType = Type.GetType(className, true, true);
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine($"\nМетоды класса {className}");
                int count = 0;
                foreach (MethodInfo method in classType.GetMethods())
                    foreach (ParameterInfo p in method.GetParameters())
                        if (paramType.Equals(p.ParameterType.Name))
                            count++;

                sw.WriteLine($"Количество методов с параметром типа {paramType}: {count}");

                if (count != 0)
                {
                    foreach (MethodInfo method in classType.GetMethods())
                    {
                        string modificator = "";
                        if (method.IsPrivate)
                            modificator += "private ";
                        if (method.IsAbstract)
                            modificator += "abstract ";
                        if (method.IsPublic)
                            modificator += "public ";
                        if (method.IsStatic)
                            modificator += "static ";
                        if (method.IsVirtual)
                            modificator += "virtual ";

                        bool isConsiste = false;
                        foreach (ParameterInfo param in method.GetParameters())
                        {
                            if (paramType.Equals(param.ParameterType.Name))
                            {
                                isConsiste = true;
                                break;
                            }
                        }

                        if (isConsiste)
                        {
                            sw.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");

                            ParameterInfo[] parameters = method.GetParameters();
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                sw.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                                if (i + 1 < parameters.Length) sw.Write(", ");
                            }
                            sw.WriteLine(")");
                            isConsiste = false;
                        }
                    }
                }
            }
        }
        public static void methodInvoke(object obj, string methodName, object[] fileParameters = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Объект не может быть null.");
            }

            Type classType = obj.GetType();
            MethodInfo method = classType.GetMethod(methodName);
            if (method == null)
            {
                throw new ArgumentException($"Метод {methodName} не найден в классе {classType.Name}.");
            }

            ParameterInfo[] parametersInfo = method.GetParameters();
            object[] parameters = new object[parametersInfo.Length];

            if (fileParameters != null && fileParameters.Length > 0)
            {
                for (int i = 0; i < parametersInfo.Length; i++)
                {
                    if (i < fileParameters.Length)
                    {
                        parameters[i] = Convert.ChangeType(fileParameters[i], parametersInfo[i].ParameterType);
                    }
                    else
                    {
                        parameters[i] = GenerateValue(parametersInfo[i].ParameterType);
                    }
                }
            }
            else
            {
                for (int i = 0; i < parametersInfo.Length; i++)
                {
                    parameters[i] = GenerateValue(parametersInfo[i].ParameterType);
                }
            }

            object result = method.Invoke(obj, parameters);

            if (method.ReturnType != typeof(void))
            {
                Console.WriteLine($"Результат выполнения метода {methodName}: {result}");
            }
            else
            {
                Console.WriteLine($"Метод {methodName} выполнен успешно.");
            }
        }


        public static T Create<T>()
        {
            Type type = typeof(T);
            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 0)
            {
                throw new InvalidOperationException("У типа нет публичных конструкторов.");
            }

            ConstructorInfo constructor = constructors[0];

            ParameterInfo[] parameters = constructor.GetParameters();
            object[] constructorParameters = new object[parameters.Length];
            for(int i=0;i<parameters.Length; i++)
            {
                constructorParameters[i] = GenerateValue(parameters[i].ParameterType);
            }

            T instance = (T)constructor.Invoke(constructorParameters);
            return instance;
        }

        private static object GenerateValue(Type type)
        {
            if (type == typeof(int))
            {
                return new Random().Next(1, 100);
            }
            else if (type == typeof(string))
            {
                return "Сгенерированная строка";
            }
            else if (type == typeof(bool))
            {
                return true;
            }
            else if (type == typeof(double))
            {
                return new Random().NextDouble() * 100;
            }
            else if (type == typeof(DateTime))
            {
                return DateTime.Now;
            }
            else
            {
                ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
                if (ctor != null)
                {
                    return Activator.CreateInstance(type);
                }

                throw new NotSupportedException($"Неизвестный тип: {type.FullName}");
            }
        }

    }
}
