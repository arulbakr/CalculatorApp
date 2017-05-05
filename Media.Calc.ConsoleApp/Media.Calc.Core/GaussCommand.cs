using System;
using System.Collections.Generic;


namespace Media.Calc.Core
{
    public class GaussCommand : ICalcCommand
    {
        private readonly ResultReceiver _result;
        private readonly double _aNumber;
        private readonly double _bNumber;
        private readonly double _cNumber;
        private readonly double _xNumber;
        public bool IsExecuted { get; set; }
        private readonly List<Number> _numbers;
        private readonly List<Number> _bracketNumbers;
        private readonly bool _isBracketClosed;

        public GaussCommand(ResultReceiver result, double aNumber, double bNumber, 
            double cNumber, double xNumber, List<Number> numbers, List<Number> bracketNumbers, bool isBracketClosed)
        {
            _result = result;
            _aNumber = aNumber;
            _bNumber = bNumber;
            _cNumber = cNumber;
            _xNumber = xNumber;
            IsExecuted = false;
            _numbers = numbers;
            _bracketNumbers = bracketNumbers;
            _isBracketClosed = isBracketClosed;
        }

        /// <summary>
        /// Method performs the Gaussian operation
        /// </summary>
        public void Execute()
        {
            if (!IsExecuted)
            {
                double nomination = Math.Pow((_xNumber - _bNumber), 2);
                double denomination = 2*Math.Pow(_cNumber, 2);
                double gaussValue = _aNumber*Math.Exp(-(nomination/denomination));
                if (_isBracketClosed)
                {
                    _numbers.Add(new Number {EnteredNumber = gaussValue, IsCalculated = false});
                }
                else
                {
                    _bracketNumbers.Add(new Number {EnteredNumber = gaussValue, IsCalculated = false});
                }
            }
            IsExecuted = true;
        }
    }
}