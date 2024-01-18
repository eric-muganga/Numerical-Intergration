
/// divide the limits into intervals of a length not more than 0.1
/// if the interval length l is greater than 5 then 5/0.1 else  50 intervals


double Integrate(Func<double, double> f, double a, double b, string rule = "simpsons")
{
    /* Replace this with your code */
    if (b < a) throw new Exception("Error: improper limits");

    double intervalWidth = b - a;
    double numberOfSubintervals = 0;
    
    if (intervalWidth >= 5)
    {
        numberOfSubintervals = intervalWidth / 0.1;
    }
    else
    {
        numberOfSubintervals = 5 / 0.1;
    }

    double subintervalWidth = intervalWidth / numberOfSubintervals;

    double result = 0;
    if (rule.Equals("simpsons"))
    {
        result = SimpsonsRule(a, b, f);
    }
    else if (rule.Equals("trapezoid"))
    {
        result = TrapezoidRule(a, b, f);
    }
    else if (rule.Equals("rectangle-right"))
    {
        result = RectangleRightRule(a, b, f);
    }
    else if (rule.Equals("rectangle-mid"))
    {
        result = RectangleMidRule(a, b, f);
    }
    else if (rule.Equals("rectangle-left"))
    {
        result = RectangleLeftRule(a, b, f);
    }

    // Simpson's Rule
    double SimpsonsRule(double a , double b, Func<double, double> func)
    {
        double fx = func(a) + func(b);

        for (int i = 0; i < numberOfSubintervals; i++)
        {
            double x = a + i * subintervalWidth;
            fx += 2 * (i % 2 == 0 ? 1 : 2) * func(x);
        }

        return fx * subintervalWidth / 3;
    }

    //Trapezoid Rule
    double TrapezoidRule(double a, double b, Func<double, double> function)
    {
        double fx = (function(a) + function(b)) / 2.0;

        for (int i = 1; i < numberOfSubintervals; i++)
        {
            double x = a + subintervalWidth * i;
            fx += function(x);
        }

        return fx * subintervalWidth;
    }

    //Rectangle-Left Rule
    double RectangleLeftRule(double a, double b, Func<double, double> function)
    {;
        double fx = 0;

        for (int i = 0; i < numberOfSubintervals; i++)
        {
            double x = a + subintervalWidth * i;
            fx += function(x);
        }

        return result * subintervalWidth;
    }
    

    //Rectangle-Mid Rule
    double RectangleMidRule(double a, double b, Func<double, double> function)
    {
        double fx = 0;

        for (int i = 0; i < numberOfSubintervals; i++)
        {
            double x = a + subintervalWidth * (i * 0.5);
            fx += function(x);
        }

        return result * subintervalWidth;
    }

    //Rectangle-Right Rule
    double RectangleRightRule(double a, double b, Func<double, double> function)
    {
        double fx = 0;

        for (int i = 0; i < numberOfSubintervals; i++)
        {
            double x = a + subintervalWidth * (i * 1);
            fx += function(x);
        }

        return result * subintervalWidth;
    }


    return result;
}

Func<double, double> f = (x) => {
    return Math.Exp(x) + 1;
};

Console.WriteLine(Integrate(f, 0, 1));