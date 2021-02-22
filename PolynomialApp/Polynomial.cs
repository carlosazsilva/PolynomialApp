using System;
using System.Collections.Generic;

namespace PolynomialApp
{
    public class Polynomial
    {
        private enum Op
        {
            Add = '+',
            Subtract = '-'
        };

        #region Public Properties

        /// <summary>
        /// Gets the name of the polynomial expression.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the degree of the polynomial expression.
        /// </summary>
        public int Degree
        {
            get
            {
                int degree = 0;
                foreach (Term term in Terms)
                {
                    if (term.Degree > degree)
                    {
                        degree = term.Degree;
                    }
                }
                return degree;
            }
        }

        /// <summary>
        /// Gets the number of terms of the polynomial expression.
        /// </summary>
        public int NumTerms => Terms.Count;

        /// <summary>
        /// Gets whether the polynomial expression is complete or not.
        /// </summary>
        public bool IsComplete => Degree == Terms.Count - 1;

        /// <summary>
        /// Gets the list of <see cref="Terms"/> of the polynomial expression.
        /// </summary>
        public List<Term> Terms { get; set; }

        #endregion

        #region Constuctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        public Polynomial()
        {
            Terms = new List<Term>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class from an array.
        /// </summary>
        /// <param name="coef">An array of coefficient values where the index is the degree.</param>
        public Polynomial(params int[] coef) : this()
        {
            if (coef.Length <= 1)
            {
                throw new Exception("A polynomial expression must have at least 2 terms.");
            }

            for (int i = 0, l = coef.Length; i < l; i++)
            {
                if (coef[i] == 0)
                {
                    throw new Exception();
                }
                Term term = new Term(i, coef[i]);
                Terms.Insert(0, term);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class from a string.
        /// </summary>
        /// <param name="polynomial">The polynomial expression.</param>
        public Polynomial(string polynomial, string name = null) : this()
        {
            if (name != null)
            {
                Name = name;
            }

            try
            {
                char separator = '|';

                polynomial = polynomial
                    .Replace("+", separator + "+")
                    .Replace("-", separator + "-");

                polynomial = polynomial[0] == separator ? polynomial.TrimStart(separator) : polynomial;

                string[] terms = polynomial.Split(separator);

                foreach (string term in terms)
                {
                    int degree, coef;

                    if (term.Contains("+x^") || term.Contains("-x^"))
                    {
                        degree = int.Parse(term[3..]);
                        coef = term.Contains('+') ? 1 : -1;
                    }
                    else if (term.Contains("x^"))
                    {
                        degree = int.Parse(term[(term.IndexOf('^') + 1)..]);
                        coef = int.Parse(term.Substring(0, term.IndexOf('x')));
                    }
                    else if (term.Contains('x'))
                    {
                        degree = 1;

                        if (term == "+x" || term == "-x")
                        {
                            coef = term == "+x" ? 1 : -1;
                        }
                        else
                        {
                            coef = int.Parse(term.Remove(term.IndexOf('x')));
                        }
                    }
                    else
                    {
                        degree = 0;
                        coef = int.Parse(term);
                    }

                    Terms.Add(new Term(degree, coef));
                }

                if (NumTerms <= 1)
                {
                    Exception ex = new Exception
                    {
                        Source = "Monomial"
                    };

                    throw ex;
                }
            }
            catch (Exception ex)
            {
                if (ex.Source == "Monomial")
                {
                    throw new Exception("A polynomial expression must have at least 2 terms.");
                }
                else
                {
                    throw new Exception("The input string is not a valid polynomial expression.");
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new <see cref="Term"/> to an instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="degree">The value of the new term.</param>
        /// <param name="coef">The value of the coefficient of the new term.</param>
        public void AddTerm(int degree, int coef)
        {
            if (coef == 0)
            {
                throw new Exception("The coefficient of a term cannot be 0.");
            }

            Term newTerm = new Term(degree, coef);

            if (NumTerms == 0)
            {
                Terms.Add(newTerm);
            }
            else
            {
                bool success = false;

                for (int i = 0, l = NumTerms; i < l; i++)
                {
                    if (degree > Terms[i].Degree)
                    {
                        Terms.Insert(i, newTerm);
                        success = true;
                        break;
                    }
                    else if (degree == Terms[i].Degree)
                    {
                        throw new Exception("There's already a term with that degree.");
                    }
                }

                if (!success)
                {
                    Terms.Add(newTerm);
                }
            }
        }

        /// <summary>
        /// Removes one term from a polynomial expression.
        /// </summary>
        /// <param name="degree">The degree of the term to be removed.</param>
        public void RemoveTerm(int degree)
        {
            bool hasDegree = false;

            foreach (Term term in Terms)
            {
                if (term.Degree == degree)
                {
                    hasDegree = Terms.Remove(term);
                    break;
                }
            }

            if (!hasDegree)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Calculates the result of the polynomial expression.
        /// </summary>
        /// <param name="x">The value of x.</param>
        /// <returns>The result.</returns>
        public double Value(double x)
        {
            double value = 0;

            foreach (Term term in Terms)
            {
                value += term.Coefficient * Math.Pow(x, term.Degree);
            }

            return value;
        }

        /// <summary>
        /// Converts a <see cref="Polynomial"/> into a string.
        /// </summary>
        /// <returns>The polynomial expression as a string.</returns>
        public override string ToString()
        {
            string polynomial = string.Empty;

            if (NumTerms != 0)
            {
                foreach (Term term in Terms)
                {
                    polynomial += term.ToString();
                }

                return polynomial[0] == '+' ? polynomial.TrimStart('+') : polynomial;
            }

            return "0";
        }

        /// <summary>
        /// Makes a copy of the polynomial expression.
        /// </summary>
        /// <returns>A new polynomial expression with the same terms.</returns>
        public Polynomial Clone()
        {
            Polynomial p1 = new Polynomial();

            foreach (Term term in Terms)
            {
                p1.AddTerm(term.Degree, term.Coefficient);
            }

            return p1;
        }

        /// <summary>
        /// Calculates the sum of 2 polynomial expressions.
        /// </summary>
        /// <param name="p1">The first polynomial expression.</param>
        /// <param name="p2">The second polynomial expression.</param>
        /// <returns>The resulting polynomial expression.</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            return SumOrSubtractOperation(Op.Add, p1, p2);
        }

        /// <summary>
        /// Subtracts 2 polynomial expressions.
        /// </summary>
        /// <param name="p1">The first polynomial expression.</param>
        /// <param name="p2">The second polynomial expression.</param>
        /// <returns>The resulting polynomial expression.</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return SumOrSubtractOperation(Op.Subtract, p1, p2);
        }

        /// <summary>
        /// Multiplies 2 polynomial expressions.
        /// </summary>
        /// <param name="p1">The first polynomial expression.</param>
        /// <param name="p2">The second polynomial expression.</param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Polynomial p3 = new Polynomial();

            foreach (Term t1 in p1.Terms)
            {
                int degree, coef;

                bool reduction;

                foreach (Term t2 in p2.Terms)
                {
                    reduction = false;

                    degree = t1.Degree + t2.Degree;
                    coef = t1.Coefficient * t2.Coefficient ;

                    foreach (Term t3 in p3.Terms)
                    {
                        if (degree == t3.Degree)
                        {
                            coef += t3.Coefficient;
                            p3.RemoveTerm(degree);
                            p3.AddTerm(degree, coef);
                            reduction = true;
                            break;
                        }
                    }

                    if (!reduction)
                    {
                        p3.AddTerm(degree, coef);
                    }
                }
            }

            return p3;
        }

        /// <summary>
        /// Multiplies a polynomial expression with a scalar parameter.
        /// </summary>
        /// <param name="p1">The polynomial expression.</param>
        /// <param name="scalar">The scalar parameter.</param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, int scalar)
        {
            Polynomial p3 = new Polynomial();

            int coef;

            foreach (Term term in p1.Terms)
            {
                coef = term.Coefficient * scalar;
                p3.AddTerm(term.Degree, coef);
            }

            return p3;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Auxiliar method to either sum or subtract 2 polynomial expressions.
        /// </summary>
        /// <param name="op">The type of operation.</param>
        /// <param name="p1">The first polynomial expression.</param>
        /// <param name="p2">The second polynomial expression.</param>
        /// <returns>The resulting polynomial expression.</returns>
        private static Polynomial SumOrSubtractOperation(Op op, Polynomial p1, Polynomial p2)
        {
            Polynomial p3 = new Polynomial();

            bool hasDegree;

            List<int> termsToRemove = new List<int>();

            foreach (Term t1 in p1.Terms)
            {
                hasDegree = false;

                foreach (Term t2 in p2.Terms)
                {
                    if (t1.Degree == t2.Degree)
                    {
                        int coef = op == Op.Add ? t1.Coefficient + t2.Coefficient : t1.Coefficient - t2.Coefficient;

                        if (coef == 0)
                        {
                            termsToRemove.Add(t1.Degree);
                        }
                        else
                        {
                            p3.AddTerm(t1.Degree, coef);
                        }

                        hasDegree = true;

                        break;
                    }
                }

                if (!hasDegree)
                {
                    p3.AddTerm(t1.Degree, t1.Coefficient);
                }
            }

            foreach (Term t2 in p2.Terms)
            {
                hasDegree = false;

                foreach (Term t3 in p3.Terms)
                {
                    if (t2.Degree == t3.Degree)
                    {
                        hasDegree = true;
                        break;
                    }
                }

                if (!hasDegree)
                {
                    p3.AddTerm(t2.Degree, op == Op.Add ? t2.Coefficient : -t2.Coefficient);
                }
            }

            if (termsToRemove.Count > 0)
            {
                foreach (int term in termsToRemove)
                {
                    p3.RemoveTerm(term);
                }
            }

            return p3;
        }

        #endregion
    }
}
