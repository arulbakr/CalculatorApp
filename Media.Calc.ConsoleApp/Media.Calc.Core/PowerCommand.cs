using System;
using System.Collections.Generic;


namespace Media.Calc.Core
{
    public class PowerCommand : ICalcCommand
    {
        private readonly ResultReceiver _result;
        private readonly List<Number> _numbers;
        public bool IsExecuted { get; set; }

        public PowerCommand(ResultReceiver result, List<Number> numbers)
        {
            _result = result;
            _numbers = numbers;
            IsExecuted = false;
        }

        /// <summary>
        /// Method performs the PowerOf operation
        /// </summary>
        public void Execute()
        {
            if (!IsExecuted)
            {
                int count = 0;
                foreach (var operand in _numbers)
                {
                    if (!operand.IsCalculated)
                    {
                        _result.Answer = count == 0 ? operand.EnteredNumber : Math.Pow(_result.Answer, operand.EnteredNumber);
                        count++;
                        operand.IsCalculated = true;
                    }
                }
            }
            IsExecuted = true;
        }
    }
}