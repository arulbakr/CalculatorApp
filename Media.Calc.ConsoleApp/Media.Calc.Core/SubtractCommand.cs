using System.Collections.Generic;


namespace Media.Calc.Core
{
    public class SubtractCommand : ICalcCommand
    {
        private readonly ResultReceiver _result;
        private readonly List<Number> _numbers;
        public bool IsExecuted { get; set; }

        public SubtractCommand(ResultReceiver result, List<Number> numbers)
        {
            _result = result;
            _numbers = numbers;
            IsExecuted = false;
        }

        /// <summary>
        /// Method performs the subtract operation
        /// </summary>
        public void Execute()
        {
            if (!IsExecuted)
            {
                foreach (var operand in _numbers)
                {
                    if (!operand.IsCalculated)
                    {
                        if (_result.Answer == 0)
                        {
                            _result.Answer = operand.EnteredNumber;
                        }
                        else
                        {
                            _result.Answer = _result.Answer - operand.EnteredNumber;
                        }
                    }
                    operand.IsCalculated = true;
                }
            }
            IsExecuted = true;
        }
    }
}