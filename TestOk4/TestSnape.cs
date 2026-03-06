using okfks_4;

namespace TestOk4
{
    public class TestSnape
    {
        [Fact]
        public void Area_ReturnsCorrectValue_WhenDimensionsAreValid()
        {
            // Arrange
            var rectWidth = 5.0;
            var rectHeight = 5.0;
            var expectedResult = rectWidth * rectHeight;

            var target = new Rectangle(rectWidth, rectHeight);
            var actualResult = target.Area();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-5, 5)]
        [InlineData(0, 5)]
        public void Constructor_ThrowsArgumentException_WhenDimensionsAreNonPositive(double w, double h)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(w, h));
        }

        [Theory]
        [InlineData(-5, 5, 5)]
        [InlineData(0, 5, 5)]
        [InlineData(15, 5, 5)]
        public void Constructor_ThrowsArgumentException_WhenSidesDoNotFormTriangle(double s1, double s2, double s3)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(s1, s2, s3));
        }

        [Fact]
        public void RectanglePerimeterCalculateTest()
        {
            const double width = 5;
            const double height = 5;

            double expectedPerimeter = (width * 2) + (height * 2);

            Rectangle rectangle = new(width, height);

            Assert.Equal(expectedPerimeter, rectangle.Perimeter());
        }
        [Fact]
        public void TriangleAreaCalculateTest()
        {
            const double a = 5;
            const double b = 5;
            const double c = 5;

            double p = (a + b + c) / 2;
            double expectedArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Triangle triangle = new(a, b, c);

            Assert.Equal(expectedArea, triangle.Area());
        }
        [Fact]
        public void TrianglePerimeterCalculateTestFailedOnPurpose()
        {
            const double a = 5;
            const double b = 5;
            const double c = 5;

            double expectedPerimeter = a + b + c;

            Triangle triangle = new(a, b, c);

            Assert.Equal(expectedPerimeter, triangle.Perimeter());
        }
    }
}