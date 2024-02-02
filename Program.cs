
using System.Diagnostics;

interface Shape
{
    void accept(ShapeVisitor visitor);
}

// Concrete element: Circle
class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public void accept(ShapeVisitor visitor)
    {
        visitor.visitCircle(this);
    }

    public double getRadius()
    {
        return radius;
    }
}

// Concrete element: Square
class Square : Shape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public void accept(ShapeVisitor visitor)
    {
        visitor.visitSquare(this);
    }

    public double getSide()
    {
        return side;
    }
}

// Concrete element: Triangle
class Triangle : Shape
{
    private double side1, side2, side3;

    public Triangle(double side1, double side2, double side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public void accept(ShapeVisitor visitor)
    {
        visitor.visitTriangle(this);
    }

    public double getSide1()
    {
        return side1;
    }

    public double getSide2()
    {
        return side2;
    }

    public double getSide3()
    {
        return side3;
    }
}

// Visitor interface
interface ShapeVisitor
{
    void visitCircle(Circle circle);
    void visitSquare(Square square);
    void visitTriangle(Triangle triangle);

    void visitRectangle(Rectangle rectangle);
}

// Concrete visitor: Area calculator
class AreaCalculator : ShapeVisitor
{
    public void visitCircle(Circle circle)
    {
        double area = Math.PI * circle.getRadius() * circle.getRadius();
        Console.WriteLine("Area of circle: " + area);
    }

    public void visitSquare(Square square)
    {
        double area = square.getSide() * square.getSide();
        Console.WriteLine("Area of square: " + area);
    }

    public void visitTriangle(Triangle triangle)
    {
        // Using Heron's formula to calculate the area of a triangle
        double s = (triangle.getSide1() + triangle.getSide2() + triangle.getSide3()) / 2;
        double area = Math.Sqrt(s * (s - triangle.getSide1()) * (s - triangle.getSide2()) * (s - triangle.getSide3()));
        Console.WriteLine("Area of triangle: " + area);
    }

    public void visitRectangle(Rectangle rectangle)
    {
        double area = rectangle.getLength() * rectangle.getWidth();
        Console.WriteLine("Area of square: " + area);
    }


}

// Concrete visitor: Perimeter calculator
class PerimeterCalculator : ShapeVisitor
{
    public void visitCircle(Circle circle)
    {
        double perimeter = 2 * Math.PI * circle.getRadius();
        Console.WriteLine("Perimeter of circle: " + perimeter);
    }

    public void visitSquare(Square square)
    {
        double perimeter = 4 * square.getSide();
        Console.WriteLine("Perimeter of square: " + perimeter);
    }

    public void visitTriangle(Triangle triangle)
    {
        double perimeter = triangle.getSide1() + triangle.getSide2() + triangle.getSide3();
        Console.WriteLine("Perimeter of triangle: " + perimeter);
    }

    public void visitRectangle(Rectangle rectangle)
    {
        double perimeter = 2 * rectangle.getLength()+ 2 * rectangle.getWidth();
        Console.WriteLine("Perimeter of rectangle: " + perimeter);
    }

}
// novi element
class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public void accept(ShapeVisitor visitor)
    {
        visitor.visitRectangle(this);
    }

    public double getLength()
    {
        return length;
    }

    public double getWidth()
    {
        return width;
    }
}

// novi visitor
class DiagonalCalculator : ShapeVisitor
{
    public void visitCircle(Circle circle)
    {
        
    }

    public void visitSquare(Square square)
    {
     
    }

    public void visitTriangle(Triangle triangle)
    {
       
    }

    public void visitRectangle(Rectangle rectangle)
    {
        double diagonal = Math.Sqrt(rectangle.getLength() * rectangle.getLength() + rectangle.getWidth() * rectangle.getWidth());
        Console.WriteLine("Dijagonala pravokutnika: " + diagonal);
    }
}


 class Program
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle(4, 5);
        DiagonalCalculator diagonalCalculator = new DiagonalCalculator();
        rectangle.accept(diagonalCalculator);

        Console.ReadLine();

    }

}