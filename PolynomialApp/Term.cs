namespace PolynomialApp
{
    public class Term
    {
        public int Degree { get; }

        public int Coefficient { get; }

        public Term(int degree, int coef)
        {
            Degree = degree;
            Coefficient = coef;
        }

        public override string ToString()
        {
            string coef, x, degree;

            if (Coefficient == 1 || Coefficient == -1)
            {
                coef = Degree == 0 ? (Coefficient == 1 ? "+1" : "-1") : (Coefficient == 1 ? "+" : "-");
            }
            else
            {
                coef = Coefficient > 0 ? "+" + Coefficient.ToString() : Coefficient.ToString();
            }

            if (Degree == 0)
            {
                x = string.Empty;
                degree = string.Empty;
            }
            else if (Degree == 1)
            {
                x = "x";
                degree = string.Empty;
            }
            else
            {
                x = "x^";
                degree = Degree.ToString();
            }

            return coef + x + degree;
        }
    }
}
