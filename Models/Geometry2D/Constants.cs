namespace OnlineGeometryApp.Models.Geometry2D
{
    /// <summary>
    /// Константы, необходимые и полезные при работе с геометрией
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Математическое число ПИ
        /// </summary>
        public const double Pi = Math.PI;
        /// <summary>
        /// Величина погрешности при сравнении числовых величин
        /// </summary>
        public const double Eps = 1e-9;

        public static string __beg__ = "(";
        public static string __sep__ = ", ";
        public static string __end__ = ")";

        public static string __point_description__ = "Point";
        public static string __line_description__ = "Line";
        public static bool __debug__ = false;

        /// <summary>
        /// Несуществующий вектор
        /// </summary>
        public static Point NonExistenPoint
        {
            get
            {
                return new Point(0, 0, false);
            }
        }

        /// <summary>
        /// Прямая, лежащая на оси X
        /// </summary>
        public static Line Ox
        {
            get
            {
                return new Line(0, 1, 0);
            }
        }

        /// <summary>
        /// Прямая, лежащая на оси Y
        /// </summary>
        public static Line Oy
        {
            get
            {
                return new Line(1, 0, 0);
            }
        }
    }
}
