namespace Executor.IO.Commands
{
    using System.Diagnostics;
    using Attributes;
    using Contracts;
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    [Alias("open")]
    class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
