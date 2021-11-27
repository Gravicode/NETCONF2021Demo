
//namespace without curly braces
namespace DemoCS10;
public class MyFunctions
{
    //struct record
    public readonly record struct Point3d(double X, double Y, double Z);
    //class record
    public record class Point2d(double X, double Y)
    {
        public double Z { get; init; } = 0;
    }
    //natural type lamda
    public Func<string, int> parseToInt = (string s) => int.Parse(s);
    int parseToInt2(string str)
    {
        //new
        var parse = (string s) => int.Parse(s);
        return parse(str);
    }
    //natural type for method group
    public void WriteLine(string msg)
    {
        Action<string> write = Console.Write;
        write(msg);
    }
    public string ReadLine()
    {
        Func<string?> read = Console.ReadLine;
        return read();
    }
    //Assignment and declaration in same deconstruction

    public (double x, double y ) DekonstructPoint3d(Point2d point)
    {   
        // assignment:
        double x1 = 0;
        double y1 = 0;
   
        (x1, y1) = point;
        return (x1, y1);
    }

    public Point3d GetSamplePoints()
    {
        var rnd = new Random();
        Point3d point = new Point3d();
        var point_clone = point with { X = rnd.Next()*100, Y = rnd.Next() * 100, Z = rnd.Next() * 100 };
        return point_clone;
    }

    public (int x,int y) switchNumber(int x, int y)
    {
        (var x1, var y1) = (y, x); // Works in C# 9
        return (x1, y1);
        //or
        
    }
    //generic attribute
    [GenericAttribute<string>()]
    public string? Method() => default;

}

