using ReflectionHomeWorkV02.Serviсes;

namespace ReflectionHomeWorkV02;

public class MyClass: MyBaseClass, IDoo {
    
    [CustomName("SomePropertyNumber")]
    public int MyProperty { get; }
    
    [CustomName("SomePropertyText")]
    public string MyProperty2 { get; }
    private int MyProperty3 { get; set; }
    private int ID { get; set; }
    
    [CustomName("SomeFieldWithNumber")]
    private const long SomeNumber = 872350972309845720;

    public MyClass(int myProperty, string myProperty2) {
        
        MyProperty = myProperty;
        MyProperty2 = myProperty2;
        MyProperty3 = 123;

        ID = MyProperty3 * 2;
        GUID = DateTime.Now.ToString("h:mm:ss tt zz");
    }

    public void Do() {
        MyProperty3 = 321;
    }
    
    public override string ToString() {
        return "MyClass " 
               + MyProperty + " \n "
               + MyProperty2 + " \n " 
               + MyProperty3 + " \n "
               + ID + " \n "
               + GUID + " \n "
               + SomeNumber;
    }
}