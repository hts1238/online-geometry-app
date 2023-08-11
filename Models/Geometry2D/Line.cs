namespace OnlineGeometryApp.Models.Geometry2D
{
    public class Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Line()
        {
            A = 1;
            B = -1;
            C = 0;
        }
        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Line(Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            A = p2.Y - p1.Y;
            B = p1.X - p2.X;
            C = -(A * p1.X + B * p1.Y);
        }

        /// <summary>
        /// Подставить точку <paramref name="p"/> в уравнение прямой
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Числовой результат подстановки</returns>
        public double Calc(Point p)
        {
            p.ShouldExist();
            return A * p.X + B * p.Y + C;
        }

        /// <summary>
        /// Проверка на существование прямой
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            return Math.Abs(A) < Constants.Eps && Math.Abs(B) < Constants.Eps;
        }

        /// <summary>
        /// Вектор, перепендикулярный данной прямой
        /// </summary>
        public Point PerpendicularVector
        {
            get
            {
                return new Point(A, B);
            }
        }

        /// <summary>
        /// Направляющий вектор данной прямой
        /// </summary>
        public Point GuideVector
        {
            get
            {
                return new Point(B, -A);
            }
        }

        public static bool operator == (Line l1, Line l2)
        {
            return Math.Abs(l1.A * l2.B - l2.A * l1.B) < Constants.Eps && Math.Abs(l1.A * l2.C - l2.A * l1.C) < Constants.Eps && Math.Abs(l1.B * l2.C - l2.B * l1.C) < Constants.Eps;
        }
        public static bool operator != (Line l1, Line l2)
        {
            return !(l1 == l2);
        }

        /// <summary>
        /// Проверка на параллельность прямых
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static bool operator | (Line l1, Line l2) {
            return Math.Abs(l1.A * l2.B - l2.A * l1.B) < Constants.Eps;
        }

        public override string ToString()
        {
            return Constants.__line_description__ + Constants.__beg__ + A.ToString() + Constants.__sep__ + B.ToString() + Constants.__sep__ + C.ToString() + Constants.__end__;
        }
    }
}
