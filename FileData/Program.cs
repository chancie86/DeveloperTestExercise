using System;
using System.Text;

using FileData.Interfaces;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var parser = new CommandArgumentParser(args);
                parser.Parse();

                var fileService = new FileService();

                switch (parser.Command)
                {
                    case Command.Size:
                        var size = fileService.ReadFileSize(parser.FileName);
                        Console.WriteLine(size);
                        break;
                    case Command.Version:
                        var version = fileService.ReadFileVersion(parser.FileName);
                        Console.WriteLine(version.ToString());
                        break;
                }
            }
            catch (ArgumentNullException ane)
            {
                Console.Error.WriteLine("No arguments were supplied.");
                WriteHelp();
            }
            catch (ArgumentException ae)
            {
                Console.Error.WriteLine(ae.Message);
                WriteHelp();
            }

            Console.ReadLine();
        }

        private static void WriteHelp()
        {
            var helpTextBuilder = new StringBuilder();

            helpTextBuilder.AppendLine("\nDisplays information about a specified file.\n");
            helpTextBuilder.AppendLine("\tFileData [-v] [-s] path\n");
            helpTextBuilder.AppendLine("-v\tDisplay file version. Alternatives: --v, /v, --version");
            helpTextBuilder.AppendLine("-s\tDisplay file size. Alternatives: --s, /s --version");

            Console.WriteLine(helpTextBuilder.ToString());
        }
    }
}
    