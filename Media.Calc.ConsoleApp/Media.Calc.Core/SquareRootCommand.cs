using System;

namespace Media.Calc.Core
{
    public class SquareRootCommand : ICalcCommand
    {
        private readonly ResultReceiver _result;
        private readonly Number _number;
        public bool IsExecuted { get; set; }

        public SquareRootCommand(ResultReceiver result, Number number)
        {
            _result = result;
            _number = number;
            IsExecuted = false;
        }

        /// <summary>
        /// Method performs the SquareRoot operation
        /// </summary>
        public void Execute()
        {
            if (!IsExecuted && !_number.IsCalculated)
            {
                _result.Answer = Math.Sqrt(_number.EnteredNumber);    
            }
            IsExecuted = true;
        }
    }
}