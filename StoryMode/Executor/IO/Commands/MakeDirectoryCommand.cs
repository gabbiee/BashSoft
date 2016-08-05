namespace Executor.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;
    using Judge;
    using Network;
    using Repository;


    [Alias("mkdir")]
    class MakeDirectoryCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
