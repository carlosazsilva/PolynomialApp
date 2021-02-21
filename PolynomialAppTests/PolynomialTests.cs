using Xunit;
using PolynomialApp;
using System;

namespace PolynomialAppTests
{
    public class PolynomialTests
    {
        [Theory]
        [InlineData(1, 2, "+2x")]
        [InlineData(0, -1, "-1")]
        [InlineData(1, -1, "-x")]
        [InlineData(10, 30, "+30x^10")]
        public void TermTest(int degree, int coef, string expected)
        {
            Term term = new Term(degree, coef);
            string result = term.ToString();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, "2x+1")]
        [InlineData(new int[] { -1, 1 }, "x-1")]
        [InlineData(new int[] { 1, -1 }, "-x+1")]
        [InlineData(new int[] { 1, 15, 6, 2 }, "2x^3+6x^2+15x+1")]
        [InlineData(new int[] { -1, 1, -20, -11 }, "-11x^3-20x^2+x-1")]
        public void PolynomialFromArrayTest(int[] coef, string expected)
        {
            Polynomial p1 = new Polynomial(coef);
            string result = p1.ToString();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("40x^3-30x^2+20x-1", "40x^3-30x^2+20x-1")]
        [InlineData("-x^5-20x^4-x^2-x-1", "-x^5-20x^4-x^2-x-1")]
        [InlineData("-6x^5+x^4+12x^2-3x+1", "-6x^5+x^4+12x^2-3x+1")]
        [InlineData("36x^5+20x^4+12x^3-3x^2-9x+50", "36x^5+20x^4+12x^3-3x^2-9x+50")]
        public void PolynomialFromStringTest(string polynomial, string expected)
        {
            Polynomial p1 = new Polynomial(polynomial);
            string result = p1.ToString();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3x^7+1", 7)]
        [InlineData("3x^2+2x+1", 2)]
        [InlineData("2x^3+6x^2+15x+1", 3)]
        [InlineData("-x^5-20x^4-x^2-x-1", 5)]
        public void DegreeTest(string polynomial, int expected)
        {
            Polynomial p1 = new Polynomial(polynomial);
            int result = p1.Degree;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { -1, -5 }, 2)]
        [InlineData(new int[] { 1, 5, 3 }, 3)]
        [InlineData(new int[] { 3, 15, -3, 50 }, 4)]
        [InlineData(new int[] { -1, -5, 10, 1, 2, 3, 4 }, 7)]
        public void NumTermsTest(int[] coef, int expected)
        {
            Polynomial p1 = new Polynomial(coef);
            int result = p1.Terms.Count;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3x^2+2x+1")]
        [InlineData("40x^3-30x^2+20x-1")]
        [InlineData("-40x^5-30x^4+x^3-x^2+20x-1")]
        [InlineData("3x^7+2x^6-2x^5-x^4+x^3-2x^2-x-1")]
        public void IsCompleteTest(string polynomial)
        {
            Polynomial p1 = new Polynomial(polynomial);
            bool expected = p1.IsComplete;
            Assert.True(expected);
        }

        [Theory]
        [InlineData("3x^2+1")]
        [InlineData("40x^3-30x^2-1")]
        [InlineData("-40x^5+x^3-x^2+20x-1")]
        [InlineData("3x^7-x^4+x^3-2x^2-x-1")]
        public void IsIncompleteTest(string polynomial)
        {
            Polynomial p1 = new Polynomial(polynomial);
            bool expected = p1.IsComplete;
            Assert.False(expected);
        }

        [Theory]
        [InlineData(new int[] { -10, 20, -30, 40 }, 2, 230)]
        [InlineData(new int[] { 50, -9, -3, 12, 20, 36 }, 4, 42718)]
        [InlineData(new int[] { -1, 1, -20, -11 }, 5.6, -2554.376)]
        public void ValueFromArrayTest(int[] coef, double x, double expected)
        {
            Polynomial p1 = new Polynomial(coef);
            double result = Math.Round(p1.Value(x), 3);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("40x^3-30x^2+20x-1", 3.2, 1066.52)]
        [InlineData("36x^5+20x^4+12x^3-3x^2-9x+50", 5, 126430)]
        [InlineData("3x^7+2x^6-2x^5-x^4+x^3-2x^2-x-1", 132.1, 2116462809770227.2)]
        public void ValueFromStringTest(string polynomial, double x, double expected)
        {
            Polynomial p1 = new Polynomial(polynomial);
            double result = Math.Round(p1.Value(x), 2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { -10, 20, -30, 40 })]
        [InlineData(new int[] { -1, 100, -2, 20, 10, 50 })]
        public void CloneTest(int[] coef)
        {
            Polynomial p1 = new Polynomial(coef);
            Polynomial p2 = p1.Clone();
            string original = p1.ToString();
            string clone = p2.ToString();
            Assert.Equal(original, clone);
        }

        [Theory]
        [InlineData(new int[] { -10, 20, -30, 40 })]
        [InlineData(new int[] { -1, 100, -2, 20, 10, 50 })]
        public void CloneNotReferenceTest(int[] coef)
        {
            Polynomial p1 = new Polynomial(coef);
            Polynomial p2 = p1.Clone();
            Assert.NotEqual(p1, p2);
        }

        [Theory]
        [InlineData("-36x^5+20x^4", "-40x^8-2", "-40x^8-36x^5+20x^4-2")]
        [InlineData("-40x^8-2", "-36x^5+20x^4", "-40x^8-36x^5+20x^4-2")]
        [InlineData("40x^3-30x^2+20x-10", "4x^2-3x-5", "40x^3-26x^2+17x-15")]
        [InlineData("-40x^10-2x^4", "-36x^5+20x^2", "-40x^10-36x^5-2x^4+20x^2")]
        [InlineData("-36x^5+20x^4+12x^3-3x^2-9x", "-40x^8-2", "-40x^8-36x^5+20x^4+12x^3-3x^2-9x-2")]
        [InlineData("-36x^5+20x^4", "-40x^8-36x^5+20x^4+12x^3-3x^2-9x-2", "-40x^8-72x^5+40x^4+12x^3-3x^2-9x-2")]
        public void SumTest(string p1Str, string p2Str, string expected)
        {
            Polynomial p1 = new Polynomial(p1Str);
            Polynomial p2 = new Polynomial(p2Str);
            Polynomial p3 = p1 + p2;
            Assert.Equal(expected, p3.ToString());
        }

        [Theory]
        [InlineData("-40x^5-x", "-36x^5+20x^2-x+2", "-4x^5-20x^2-2")]
        [InlineData("-36x^5+20x^4", "-40x^8-2", "40x^8-36x^5+20x^4+2")]
        [InlineData("40x^3-30x^2+20x-10", "4x^2-3x-5", "40x^3-34x^2+23x-5")]
        [InlineData("-40x^10-2x^4", "-36x^5+20x^2", "-40x^10+36x^5-2x^4-20x^2")]
        [InlineData("-36x^5+20x^4+12x^3-3x^2-9x-1", "-40x^8-99x^4-2", "40x^8-36x^5+119x^4+12x^3-3x^2-9x+1")]
        public void SubtractTest(string p1Str, string p2Str, string expected)
        {
            Polynomial p1 = new Polynomial(p1Str);
            Polynomial p2 = new Polynomial(p2Str);
            Polynomial p3 = p1 - p2;
            Assert.Equal(expected, p3.ToString());
        }

        [Theory]
        [InlineData("3x-20", "5x^2+2", "15x^3-100x^2+6x-40")]
        [InlineData("4x^5-20", "5x^3+2x^2-2x-20", "20x^8+8x^7-8x^6-80x^5-100x^3-40x^2+40x+400")]
        [InlineData("-13x^9-10x^2-x-1", "5x^2+2", "-65x^11-26x^9-50x^4-5x^3-25x^2-2x-2")]
        public void TimesTest(string p1Str, string p2Str, string expected)
        {
            Polynomial p1 = new Polynomial(p1Str);
            Polynomial p2 = new Polynomial(p2Str);
            Polynomial p3 = p1 * p2;
            Assert.Equal(expected, p3.ToString());
        }

        [Theory]
        [InlineData("-36x^5+20x^4", 300, "-10800x^5+6000x^4")]
        [InlineData("-x^9+20x^4-x+1", 5, "-5x^9+100x^4-5x+5")]
        [InlineData("40x^3-30x^2+20x-10", 2, "80x^3-60x^2+40x-20")]
        [InlineData("-36x^5+20x^4+12x^3-3x^2-9x-1", 10, "-360x^5+200x^4+120x^3-30x^2-90x-10")]
        public void TimesNumberTest(string p1Str, int number, string expected)
        {
            Polynomial p1 = new Polynomial(p1Str);
            Polynomial p2 = p1 * number;
            Assert.Equal(expected, p2.ToString());
        }
    }
}
