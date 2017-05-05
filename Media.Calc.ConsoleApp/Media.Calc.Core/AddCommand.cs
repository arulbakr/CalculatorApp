using System.Collections.Generic;

namespace Media.Calc.Core
{
    public class AddCommand : ICalcCommand
    {
        private readonly ResultReceiver _result;
        private readonly List<Number> _numbers;
        public bool IsExecuted { get; set; }

        public AddCommand(ResultReceiver result, List<Number> numbers)
        {
            _result = result;
            _numbers = numbers;
            IsExecuted = false;
        }

        /// <summary>
        /// Method performs the add operation
        /// </summary>
        public void Execute()
        {
            if (!IsExecuted)
            {
                foreach (var operand in _numbers)
                {
                    if (!operand.IsCalculated && !double.IsNaN(operand.EnteredNumber))
                    {
                        _result.Answer += operand.EnteredNumber;
                        operand.IsCalculated = true;
                    }
                }
            }
            IsExecuted = true;
        }
    }
}