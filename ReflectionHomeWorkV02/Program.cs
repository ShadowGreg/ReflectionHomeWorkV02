using ClassLibraryFromSeminar;
using ReflectionHomeWorkV02;

public static class Program {
    public static void Main() {
        MyClass myClass = MyClassCreator();
        var myClassType = StringController.ObjectToString(myClass);
        Console.WriteLine(myClassType);
        try {
            var myObj = StringController.StringToObject<MyClass>(myClassType);
            Console.WriteLine(myObj + "\n");
            (myObj as MyClass)?.Do();
            Console.WriteLine(myObj);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public static MyClass MyClassCreator() {
        var myClassType = typeof(MyClass);

        var outputClass = Activator.CreateInstance(
            myClassType,
            new object[] {
                1,
                "2"
            }
        ) as MyClass;
        return outputClass!;
    }
}