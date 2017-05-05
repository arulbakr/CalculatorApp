

namespace Media.Calc.Core
{
    public interface ICalcCommand
    {
        bool IsExecuted { get; set; }

        /// <summary>
        /// Method executes given command
        /// </summary>
        /// <returns>result in double type</returns>
        void Execute();
    }
}