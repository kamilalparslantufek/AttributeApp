using System.Reflection;

public class AttributeExample : Attribute
{
    public string AttributeName { get; set; }
    public AttributeExample(string AttributeName)
    {
        this.AttributeName = AttributeName;
    }
}

public class MyClass
{
    [AttributeExample("OgrenciId")]
    public int Id { get; set; }

    public string Name { get; set; }
}

class AttributeApp
{
    static void Main(string[] args)
    {
        var cls = new MyClass
        {
            Id = 12,
            Name = "İsim"
        };
        var type = cls.GetType()
            .GetProperties()
            .First()
            .GetCustomAttribute<AttributeExample>();
        foreach(var i in cls.GetType().GetProperties())
        {
            Console.WriteLine(i.GetValue(cls));
            Console.WriteLine(i.GetCustomAttribute<AttributeExample>() != null ? i.GetCustomAttribute<AttributeExample>()?.AttributeName : i.Name);
        }
    }
}