using System;
using System.Data;


namespace Media.Calc.Core
{
    public class CalcCommand //: ICalcCommand
    {
        /// <summary>
        /// Method executes given command
        /// </summary>
        /// <returns>result in double type</returns>
        public double Execute(string expression)
        {
            var dataTable = new DataTable();
            var result = dataTable.Compute(expression, String.Empty);
            return Convert.ToDouble(result);
        }
    }
}