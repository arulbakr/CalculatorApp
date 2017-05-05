using System.Collections.Generic;


namespace Media.Calc.Core
{
    public class CommandInvoker
    {
        public readonly List<ICalcCommand> Operations = new List<ICalcCommand>();

        /// <summary>
        /// Method to add sequence of operations
        /// </summary>
        /// <param name="operation">Calculator command</param>
        public void IncludeOperations(ICalcCommand operation)
        {
            Operations.Add(operation);
        }

        /// <summary>
        /// Method calculates the final answer
        /// </summary>
        public void CalculatingOperations()
        {
            foreach (var operation in Operations)
            {
                operation.Execute();
            }
        }

        /// <summary>
        /// Method removes the executed operation.
        /// </summary>
        /// <param name="operation">Operation  to be removed</param>
        public void RemoveOperation(ICalcCommand operation)
        {
            Operations.Remove(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void Execute(ICalcCommand operation)
        {
            operation.Execute();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemovesAllOperations()
        {
            Operations.RemoveAll(op => op.IsExecuted || !op.IsExecuted);
        }
    }
}