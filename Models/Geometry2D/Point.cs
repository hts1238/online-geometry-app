namespace OnlineGeometryApp.Models.Geometry2D
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        private bool _ex { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
            _ex = false;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
            _ex = true;
        }
        public Point(double x, double y, bool ex)
        {
            X = x;
            Y = y;
            _ex = ex;
        }

        /// <summary>
        /// Вызывает ошибку, если вектор не существует
        /// </summary>
        /// <exception cref="NonExistentPoint"></exception>
        public void ShouldExist()
        {
            if (!_ex)
            {
                throw new NonExistentPoint();
            }
        }

        /// <summary>
        /// Существует ли вектор
        /// </summary>
        public bool Exist {
            get { return _ex; }
        }

        /// <summary>
        /// Проверка, является ли вектор нулевым
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            return Math.Abs(X) < Constants.Eps && Math.Abs(Y) < Constants.Eps;
        }

        /// <summary>
        /// Длина вектора
        /// </summary>
        public double Len
        {
            get
            {
                this.ShouldExist();

                return Math.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Длина вектора в квадрате
        /// </summary>
        public double Len2
        {
            get
            {
                this.ShouldExist();

                return X * X + Y * Y;
            }
        }

        /// <summary>
        /// Повернуть вектор на <paramref name="angle"/> радиан (против часовой стрелки)
        /// </summary>
        /// <param name="angle">Угол поворота (в радианах)</param>
        /// <returns>Повернутый вектор</returns>
        /// <seealso cref="Rotate(double)"/>
        public Point RotateRad(double angle)
        {
            this.ShouldExist();

            return new Point(X * Math.Cos(angle) - Y * Math.Sin(angle), X * Math.Sin(angle) + Y * Math.Cos(angle));
        }

        /// <summary>
        /// Повернуть вектор на <paramref name="angle"/> градусов (против часовой стрелки)
        /// </summary>
        /// <param name="angle">Угол поворота (в градусах)</param>
        /// <returns>Повернутый вектор</returns>
        /// <seealso cref="RotateRad(double)"/>
        public Point Rotate(double angle)
        {
            return RotateRad(Tools.ToRadians(angle));
        }

        /// <summary>
        /// Угол поворота до вектора <paramref name="p"/> в радианах против часовой стрелки
        /// </summary>
        /// <param name="p">Вектор</param>
        /// <returns>Угол поворота в радианах</returns>
        /// <seealso cref="Tools.ToDegrees(double)"/>
        /// <seealso cref="Tools.ToRadians(double)"/>
        public double getAngle(Point p) {
            p.ShouldExist();

            double len1 = this.Len;
            double len2 = p.Len;

            if (Math.Abs(len1 * len2) < Constants.Eps) {
                return 0;
            }

            double sin = (this % p) / len1 / len2;
            int sin_sgn = Tools.Sgn(sin);
            int cos_sgn = Tools.Sgn((this * p) / this.Len / p.Len);

            if (cos_sgn == 0 && sin_sgn == 1) return Constants.Pi / 2;
            if (cos_sgn == 0 && sin_sgn == -1) return -Constants.Pi / 2;
            if (sin_sgn == 0 && cos_sgn == 1) return 0;
            if (sin_sgn == 0 && cos_sgn == -1) return Constants.Pi;

            if (cos_sgn == 1) return Math.Asin(sin);
            if (cos_sgn == -1) return Constants.Pi *sin_sgn - Math.Asin(sin);

            return 0;
        }

        /// <summary>
        /// Единичный вектор
        /// </summary>
        public Point UnitVector
        {
            get
            {
                this.ShouldExist();

                double len = this.Len;
                if (this.IsZero())
                {
                    return new Point(0, 0);
                }

                return new Point(X / len, Y / len);
            }
        }

        /// <summary>
        /// Перпендикулярный вектор
        /// </summary>
        public Point PerpendicularVector
        {
            get
            {
                this.ShouldExist();

                return new Point(Y, -X);
            }
        }

        public static Point operator +(Point p)
        {
            p.ShouldExist();

            return p;
        }
        public static Point operator +(Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator +(Point p, double a)
        {
            p.ShouldExist();

            return new Point(p.X + a, p.Y + a);
        }
        public static Point operator +(double a, Point p)
        {
            p.ShouldExist();

            return new Point(p.X + a, p.Y + a);
        }

        public static Point operator -(Point p)
        {
            p.ShouldExist();

            return new Point(-p.X, -p.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator -(Point p, double a)
        {
            p.ShouldExist();

            return new Point(p.X - a, p.Y - a);
        }
        public static Point operator -(double a, Point p)
        {
            p.ShouldExist();

            return new Point(a - p.X, a - p.Y);
        }

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double operator *(Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return p1.X * p2.X + p1.Y * p2.Y;
        }
        public static Point operator *(Point p, double a)
        {
            p.ShouldExist();

            return new Point(p.X * a, p.Y * a);
        }
        public static Point operator *(double a, Point p)
        {
            p.ShouldExist();

            return new Point(a * p.X, a * p.Y);
        }

        public static Point operator /(Point p, double a)
        {
            p.ShouldExist();

            return new Point(p.X / a, p.Y / a);
        }
        public static Point operator /(double a, Point p)
        {
            p.ShouldExist();

            return new Point(a / p.X, a / p.Y);
        }

        /// <summary>
        /// Векторное произведение векторов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Направленная длина результирующего вектора (знак соответствует знаку угла поворота от <paramref name="p1"/> до <paramref name="p2"/>)</returns>
        public static double operator %(Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return p1.X * p2.Y - p1.Y * p2.X;
        }

        /// <summary>
        /// Проверка векторов на коллинеарность 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator | (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return p1.IsZero() || p2.IsZero() || Math.Abs(p1.X * p2.Y - p2.X * p1.Y) < Constants.Eps;
        }
        public static bool operator == (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return Math.Abs(p1.X - p2.X) < Constants.Eps && Math.Abs(p1.Y - p2.Y) < Constants.Eps;
        }
        public static bool operator != (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return !(p1 == p2);
        }
        public static bool operator < (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return p1.X - p2.X < -Constants.Eps || (Math.Abs(p1.X - p2.X) < Constants.Eps && p1.Y - p2.Y < -Constants.Eps);
        }
        public static bool operator <= (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return p1 < p2 || p1 == p2;
        }
        public static bool operator > (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return !(p1 < p2) && !(p1 == p2);
        }
        public static bool operator >= (Point p1, Point p2)
        {
            p1.ShouldExist();
            p2.ShouldExist();

            return !(p1 < p2);
        }

        public override string ToString()
        {
            this.ShouldExist();
            return Constants.__point_description__ + Constants.__beg__ + X.ToString() + Constants.__sep__ + Y.ToString() + Constants.__end__;
        }
    }
}
