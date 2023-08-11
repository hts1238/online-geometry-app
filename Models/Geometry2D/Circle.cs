namespace OnlineGeometryApp.Models.Geometry2D
{
    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle()
        {
            Center = new Point(0, 0);
            Radius = 0;
        }
        public Circle(Point center, double radius)
        {
            center.ShouldExist();

            Center = center;
            Radius = radius;
        }
        public Circle(double x, double y, double radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }

        public static bool operator ==(Circle c1, Circle c2)
        {
            return c1.Center == c2.Center && c1.Radius == c2.Radius;
        }
        public static bool operator !=(Circle c1, Circle c2)
        {
            return !(c1 == c2);
        }

        public static bool operator <(Circle c1, Circle c2)
        {
            return c1.Center < c2.Center || c1.Center == c2.Center && c1.Radius < c2.Radius;
        }
        public static bool operator <=(Circle c1, Circle c2)
        {
            return c1 < c2 || c1 == c2;
        }
        public static bool operator >(Circle c1, Circle c2)
        {
            return !(c1 <= c2);
        }
        public static bool operator >=(Circle c1, Circle c2)
        {
            return !(c1 < c2);
        }
    }
}
