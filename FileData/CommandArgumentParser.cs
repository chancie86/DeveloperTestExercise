using System;

namespace FileData
{
    /*
     * From the spec in the email...
     * 
     * *****
     * We are looking for a production-ready (include testing) piece of code that:
     * Takes in two arguments (argument 1 = functionality to perform, argument 2 = filename)
     * If the first argument is anyone of –v, --v, /v, --version then return the version of the file (use FileDetails.Version to get the version number, don’t worry about accessing the file or checking if it exists etc.)
     * If the second argument is anyone of –s, --s, /s, --size the return the size of the file (use FileDetails.Size)
     * *****
     *
     * Note: I'm assuming that "second argument" here is actually referring to the first argument, since it says above that the 2nd argument is the filename,
     * i.e. we could have:
     *      FileData.exe -v test.txt
     *      FileData.exe -s test.txt
     * and not -FileData.exe -v -s, which makes no sense since there's no file path and only 2 args are allowed.
     */

    public class CommandArgumentParser
    {
        private readonly string[] _args;

        public CommandArgumentParser(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length < 2)
            {
                throw new ArgumentException("Not enough arguments were supplied");
            }

            if (args.Length != 2)
            {
                throw new ArgumentException($"Expected 2 arguments but found {args.Length}");
            }

            this._args = args;
        }

        public Command Command { get; private set; }

        public string FileName { get; private set; }

        #region Methods
        public void Parse()
        {
            if (string.IsNullOrWhiteSpace(_args[1]))
            {
                throw new ArgumentException("Filename not specified");
            }

            var function = _args[0];
            FileName = _args[1];
            
            // Note: decided to make this case sensitive as only lower case was specified in the spec.
            switch (function)
            {
                case "-v":
                case "--v":
                case "/v":
                case "--version":
                    Command = Command.Version;
                    break;
                case "-s":
                case "--s":
                case "/s":
                case "--size":
                    Command = Command.Size;
                    break;
                default:
                    throw new ArgumentException($"Invalid argument {function}");
            }
        }
        #endregion
    }
}
