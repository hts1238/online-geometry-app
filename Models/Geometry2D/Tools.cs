namespace OnlineGeometryApp.Models.Geometry2D
{
    /// <summary>
    /// Набор функций, необходимых и полезных при работе с геометрией
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Определяет знак числа
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        ///     <para>Возвращает одно из следующих чисел:</para>
        ///     <c>-1</c> - если число отрицательное;<br/>
        ///     <c>0</c> - если число равно нулю;<br/>
        ///     <c>1</c> - если число положительное.
        /// </returns>
        public static int Sgn(double a)
        {
            if (a > Constants.Eps) return 1;
            if (a < -Constants.Eps) return -1;
            return 0;
        }

        /// <summary>
        /// Переводит радианы в градусы
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double ToDegrees(double radians)
        {
            return radians * 180.0 / Constants.Pi;
        }

        /// <summary>
        /// Переводит градусы в радианы
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double ToRadians(double degrees)
        {
            return degrees * Constants.Pi / 180;
        }
    }
}
