﻿namespace Executor.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("downloadasynch")]
    class DownloadAsynchCommand : Command, IExecutable
    {
        [Inject] private IDownloadManager downloadManager;

        public DownloadAsynchCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string url = this.Data[1];
            this.downloadManager.DownloadAsync(url);
        }
    }
}
