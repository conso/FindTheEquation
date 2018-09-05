using System.Collections.Generic;

namespace FindTheEquation.App
{
    public interface ICalculateExpressions
    {
        KeyValuePair<string, int>[] Calculate(string[] allExpressions);
    }
}