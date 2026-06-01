namespace DevelopmentChallenge.Data.Models
{
    public abstract class GeometricForm
    {
        public abstract string SingularResourceKey { get; }
        public abstract string PluralResourceKey { get; }

        public abstract decimal CalculateArea();
        public abstract decimal CalculatePerimeter();
    }
}
