using System;
using System.Reflection;

public class MyClass
{
    private int privateField;

    public MyClass()
    {
    }

    public MyClass(int value)
    {
        privateField = value;
    }

    public int PublicProperty { get; set; }

    private void PrivateMethod()
    {
        Console.WriteLine("Private method called.");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public method called.");
    }
}

class Program
{
    static void Main()
    {
        Type myClassType = typeof(MyClass);

        // Имя класса
        Console.WriteLine($"Имя класса: {myClassType.Name}");

        // Конструкторы
        Console.WriteLine("Конструкторы:");
        foreach (ConstructorInfo constructor in myClassType.GetConstructors())
        {
            Console.WriteLine($"{constructor.Name}, Модификатор доступа: {constructor.Attributes}");
        }

        // Поля и свойства
        Console.WriteLine("\nПоля и свойства:");
        foreach (FieldInfo field in myClassType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine($"{field.Name}, Тип: {field.FieldType}, Модификатор доступа: {field.Attributes}");
        }

        foreach (PropertyInfo property in myClassType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            Console.WriteLine($"{property.Name}, Тип: {property.PropertyType}, Модификатор доступа: {property.Attributes}");
        }

        // Методы
        Console.WriteLine("\nМетоды:");
        foreach (MethodInfo method in myClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
        {
            Console.WriteLine($"{method.Name}, Возвращаемый тип: {method.ReturnType}, Модификатор доступа: {method.Attributes}");
        }
    }
}
