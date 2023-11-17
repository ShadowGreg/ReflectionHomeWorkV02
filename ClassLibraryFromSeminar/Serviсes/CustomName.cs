namespace ReflectionHomeWorkV02.Serviсes; 

[AttributeUsage(AttributeTargets.Field |  AttributeTargets.Property)]
public class CustomName(string name): Attribute {
    public string Name { get; } = name;
}