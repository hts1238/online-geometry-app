namespace OnlineGeometryApp.Models.Geometry2D
{
    public class NonExistentPoint : Exception
    {
        public NonExistentPoint()
            : base("Error: Point does not exist")
        {

        }
    }
}
