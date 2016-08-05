﻿namespace Executor.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    [Alias("readdb")]
    class ReadDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(string input, string[] data)
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
            this.repository.LoadData(fileName);
        }
    }
}
