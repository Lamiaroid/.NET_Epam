using System;

namespace NET.S._2019.Tkachenko._05
{
    public class Polynomial
    {       
        public int[] Factors { get; private set; }

        public Polynomial(int[] factors)
        {
            if (factors == null)
            {
                throw new ArgumentNullException("There can't be null factors");
            }

            if (factors.Length == 0)
            {
                throw new ArgumentException("There can't be 0 factors");
            }

            Factors = factors;        
        }

        /// <summary>
        /// Returns polynomial in string representation
        /// </summary>
        public override string ToString()
        {
            return GetPolynomialExpression(Factors);
        }

        /// <summary>
        /// Gets hash code of Polynomial
        /// </summary>
        public override int GetHashCode()
        {
            return GetPolynomialExpression(Factors).GetHashCode();
        }

        /// <summary>
        /// Checks if 2 objects are equal
        /// </summary>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(this.GetType()))
            {
                return false;
            }

            Polynomial polynomial = (Polynomial)obj;
            if (polynomial.Factors.Length != this.Factors.Length)
            {
                return false;
            }

            for (int i = 0; i < this.Factors.Length; i++)
            {
                if (this.Factors[i] != polynomial.Factors[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Overload of + operation (by adding Polynomial factors)
        /// </summary>
        public static Polynomial operator +(Polynomial polynomialA, Polynomial polynomialB)
        {
            int[] newFactors;
            if (polynomialA.Factors.Length > polynomialB.Factors.Length)
            {
                newFactors = polynomialA.Factors;
                for (int i = 0; i < polynomialB.Factors.Length; i++)
                {
                    try
                    { 
                        newFactors[i] = checked(newFactors[i] + polynomialB.Factors[i]);
                    }
                    catch (OverflowException exception)
                    {
                        throw new OverflowException();
                    }
                }
            }
            else
            {
                newFactors = polynomialB.Factors;
                for (int i = 0; i < polynomialA.Factors.Length; i++)
                {
                    try
                    {
                        newFactors[i] = checked(newFactors[i] + polynomialA.Factors[i]);
                    }
                    catch (OverflowException exception)
                    {
                        throw new OverflowException();
                    }
                }             
            }

            return new Polynomial(newFactors);
        }

        /// <summary>
        /// Overload of - operation (by subtracting Polynomial factors)
        /// </summary>
        public static Polynomial operator -(Polynomial polynomialA, Polynomial polynomialB)
        {
            int[] newFactors;
            if (polynomialA.Factors.Length > polynomialB.Factors.Length)
            {
                newFactors = polynomialA.Factors;
                for (int i = 0; i < polynomialB.Factors.Length; i++)
                {
                    newFactors[i] -= polynomialB.Factors[i];
                }
            }
            else
            {
                newFactors = polynomialB.Factors;
                for (int i = 0; i < polynomialA.Factors.Length; i++)
                {
                    newFactors[i] -= polynomialA.Factors[i];
                    newFactors[i] = -newFactors[i];                
                }

                for (int i = polynomialA.Factors.Length; i < polynomialB.Factors.Length; i++)
                {
                    newFactors[i] = -newFactors[i];
                }
            }

            return new Polynomial(newFactors);
        }

        /// <summary>
        /// Overload of * operation (by multiplying Polynomial factors)
        /// </summary>
        public static Polynomial operator *(Polynomial polynomialA, Polynomial polynomialB)
        {
            int[] newFactors = new int[polynomialA.Factors.Length + polynomialB.Factors.Length - 1];
            for (int i = 0; i < polynomialA.Factors.Length; i++)
            {
                int counter = i;
                for (int j = 0; j < polynomialB.Factors.Length; j++)
                {
                    try
                    {
                        newFactors[counter] = checked(newFactors[counter] + polynomialA.Factors[i] * polynomialB.Factors[j]);
                    }
                    catch (OverflowException exception)
                    {
                        throw new OverflowException();
                    }
                    
                    counter++;
                }          
            }

            return new Polynomial(newFactors);
        }

        /// <summary>
        /// Overload of == operation (by comparing Polynomial factors)
        /// </summary>
        public static bool operator ==(Polynomial polynomialA, Polynomial polynomialB)
        {
            if (polynomialA.Factors.Length != polynomialB.Factors.Length)
            {
                return false;
            }

            for (int i = 0; i < polynomialA.Factors.Length; i++)
            {
                if (polynomialA.Factors[i] != polynomialB.Factors[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Overload of != operation (by comparing Polynomial factors)
        /// </summary>
        public static bool operator !=(Polynomial polynomialA, Polynomial polynomialB)
        {
            if (polynomialA.Factors.Length != polynomialB.Factors.Length)
            {
                return true;
            }

            for (int i = 0; i < polynomialA.Factors.Length; i++)
            {
                if (polynomialA.Factors[i] != polynomialB.Factors[i])
                {
                    return true;
                }
            }

            return false;
        }

        // Implementation of returning Polynomial in string representation
        private string GetPolynomialExpression(int[] factors)
        {
            string polynomialExpression = factors[factors.Length - 1].ToString() + "x^" + (factors.Length - 1);
            for (int i = factors.Length - 2; i >= 0; i--)
            {
                if (factors[i] > 0)
                {
                    polynomialExpression += " + " + factors[i] + "x^" + i;
                }
                else
                    if (factors[i] < 0)
                    {
                        polynomialExpression += " - " + Math.Abs(factors[i]) + "x^" + i;
                    }
            }

            return polynomialExpression;
        }
    }
}
