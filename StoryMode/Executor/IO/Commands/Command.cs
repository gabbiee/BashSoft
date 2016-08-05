namespace Executor.IO.Commands
{
    using System;
    using Contracts;
    using Exceptions;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;


        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        public string Input
        {
            get { return this.input; }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException(value);
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new InvalidCommandException(this.Input);
                }

                this.data = value;
            }
        }

        //protected IDatabase Repository
        //{
        //    get { return this.repository; }
        //}

        //protected IContentComparer Tester
        //{
        //    get { return this.tester; }
        //}

        //protected IDirectoryManager InputOutputManager
        //{
        //    get { return this.inputOutputManager; }
        //}

        //protected IDownloadManager DownloadManager
        //{
        //    get { return this.downloadManager; }
        //}

        public abstract void Execute();
    }
}
