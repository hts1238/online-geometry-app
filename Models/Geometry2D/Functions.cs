namespace OnlineGeometryApp.Models.Geometry2D
{
    /// <summary>
    /// Набор функций для работы с геометрическими объектами
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Точка пересечения прямых
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>
        /// Несуществующая точка, если такой точки не существует
        /// </returns>
        public static Point CrossLines(Line l1, Line l2)
        {
            Point w = new(0, 0);
            double d = l1.A * l2.B - l1.B * l2.A; // Точек пересечения 0 или бесконечность при d ~ 0

            if (Math.Abs(d) < Constants.Eps)
            {
                return Constants.NonExistenPoint;
            }

            w.X = (l2.C * l1.B - l1.C * l2.B) / d;
            w.Y = (l1.C * l2.A - l1.A * l2.C) / d;
            return w;
        }

        /// <summary>
        /// Построить вектор из точки до прямой
        /// </summary>
        /// <param name="p"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Point FromPointToLine(Point p, Line l)
        {
            if (l.IsZero())
            {
                return Constants.NonExistenPoint;
            }

            double len = Math.Abs(l.Calc(p)) / Math.Sqrt(l.A * l.A + l.B * l.B);
            Point w = l.PerpendicularVector.UnitVector * len;
            if (Math.Abs(l.Calc(p + w)) > Constants.Eps)
            {
                return new Point(0, 0) - w;
            }
            return w;
        }

        /// <summary>
        /// Определить, лежат ли точки по одну сторону от прямой (включая прямую)
        /// </summary>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsInSameSide(Line l, Point a, Point b)
        {
            return l.Calc(a) * l.Calc(b) > -Constants.Eps;
        }

        /// <summary>
        /// Определить, лежат ли точки по одну сторону от прямой (не включая прямую)
        /// </summary>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsInSameSideExcluding(Line l, Point a, Point b)
        {
            return l.Calc(a) * l.Calc(b) > Constants.Eps;
        }

        /// <summary>
        /// Определить, лежит ли точка на окружности или внутри круга
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsPointInCircle(Point p, Circle c)
        {
            return (p - c.Center).Len - c.Radius < Constants.Eps;
        }

        /// <summary>
        /// Определить, пересекаются ли прямая и окружность
        /// </summary>
        /// <param name="c"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool IsCrossingCircleAndLine(Circle c, Line l)
        {
            return FromPointToLine(c.Center, l).Len - c.Radius < Constants.Eps;
        }

        /// <summary>
        /// Точки пересечения окружности и прямой
        /// </summary>
        /// <param name="c"></param>
        /// <param name="l"></param>
        /// <returns>
        /// Две несуществующие точки, если пересечений не существует;<br/>
        /// Две одинаковые точки, если точка пересечения одна (точка касания)
        /// </returns>
        public static Tuple<Point, Point> CrossCircleAndLine(Circle c, Line l)
        {
            if (!IsCrossingCircleAndLine(c, l))
            {
                return new(Constants.NonExistenPoint, Constants.NonExistenPoint);
            }

            Point h = FromPointToLine(c.Center, l);
            double x = Math.Sqrt(c.Radius * c.Radius - h.Len * h.Len);
            Point x1 = l.GuideVector.UnitVector * x;
            Point x2 = l.GuideVector.UnitVector * -x;
            return new(c.Center + h + x1, c.Center + h + x2);
        }

        /// <summary>
        /// Определить, пересекаются ли окружности
        /// </summary>
        /// <param name="с1"></param>
        /// <param name="с2"></param>
        /// <returns></returns>
        public static bool IsCrossingCircles(Circle с1, Circle с2)
        {
            double l = (с1.Center - с2.Center).Len;
            return (с2.Radius - l - с1.Radius < Constants.Eps)
                   && (с1.Radius - l - с2.Radius < Constants.Eps)
                   && (с1.Radius + с2.Radius - l > Constants.Eps);
        }

        /// <summary>
        /// Точки пересечения окружностей
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>
        /// Две несуществующие точки, если пересечений не существует;<br/>
        /// Две одинаковые точки, если точка пересечения одна (точка касания)
        /// </returns>
        public static Tuple<Point,Point> CrossCircles(Circle c1, Circle c2) {
            if (!IsCrossingCircles(c1, c2))
            {
                return new(Constants.NonExistenPoint, Constants.NonExistenPoint);
            }

            Point d = c1.Center - c2.Center;
            // a - угол между вектором d и вектором, идущим из центра с2 в точку пересечения
            double cos_a = (d.Len * d.Len + c2.Radius * c2.Radius - c1.Radius * c1.Radius) / (2 * d.Len * c2.Radius);
            Point d1 = d.UnitVector * c2.Radius * cos_a;
            double x = Math.Sqrt(c2.Radius * c2.Radius - d1.Len * d1.Len);
            return new(c2.Center + d1 + d.PerpendicularVector.UnitVector * x,
                       c2.Center + d1 - d.PerpendicularVector.UnitVector * x);
        }
    }
}
