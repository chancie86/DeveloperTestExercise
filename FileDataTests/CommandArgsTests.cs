using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FileData;

namespace FileDataTests
{
    [TestClass]
    public class CommandArgsTests
    {
        [TestMethod]
        public void AcceptsValidVersionArguments()
        {
            var validFunctionArgs = new[]
            {
                "-v",
                "--v",
                "/v",
                "--version"
            };

            foreach (var functionArg in validFunctionArgs)
            {
                var filePath = "test.txt";

                var args = new[]
                {
                    functionArg,
                    filePath
                };
                var parser = new CommandArgumentParser(args);
                parser.Parse();

                Assert.AreEqual(parser.Command, Command.Version);
                Assert.AreEqual(parser.FileName, filePath);
            }
        }

        [TestMethod]
        public void AcceptsValidSizeArguments()
        {
            var validFunctionArgs = new[]
            {
                "-s",
                "--s",
                "/s",
                "--size"
            };

            foreach (var functionArg in validFunctionArgs)
            {
                var filePath = "test.txt";

                var args = new[]
                {
                    functionArg,
                    filePath
                };
                var parser = new CommandArgumentParser(args);
                parser.Parse();

                Assert.AreEqual(parser.Command, Command.Size);
                Assert.AreEqual(parser.FileName, filePath);
            }
        }

        [TestMethod]
        public void RejectsInvalidSizeArguments()
        {
            // Just chose some boundary values (empty), incorrect casings, strings with white space, etc.
            // Could use techniques such as fuzz testing to throw at the parser which might be sensible
            // since this data is coming from an external source.
            var validFunctionArgs = new[]
            {
                "-S",
                "--S",
                "/S",
                "--sIzE",
                "foo",
                "s",
                "/s/s",
                "-s ",
                " /s"
            };

            foreach (var functionArg in validFunctionArgs)
            {
                var filePath = "test.txt";

                var args = new[]
                {
                    functionArg,
                    filePath
                };
                var parser = new CommandArgumentParser(args);

                Assert.ThrowsException<ArgumentException>(() => parser.Parse());
            }
        }

        [TestMethod]
        public void RejectsInvalidVersionArguments()
        {
            // Just chose some boundary values (empty), incorrect casings, strings with white space, etc.
            // Could use techniques such as fuzz testing to throw at the parser which might be sensible
            // since this data is coming from an external source.
            var validFunctionArgs = new[]
            {
                "-V",
                "--V",
                "/V",
                "--VeRsioN",
                "bar",
                "v",
                "/vs",
                "-v ",
                " /v"
            };

            foreach (var functionArg in validFunctionArgs)
            {
                var filePath = "test.txt";

                var args = new[]
                {
                    functionArg,
                    filePath
                };
                var parser = new CommandArgumentParser(args);

                Assert.ThrowsException<ArgumentException>(() => parser.Parse());
            }
        }

        [TestMethod]
        public void RequiresFilePath()
        {
            Assert.ThrowsException<ArgumentException>(() => new CommandArgumentParser(new[] { "-v" }));
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var parser = new CommandArgumentParser(new[] {"-v", null});
                parser.Parse();
            });
            Assert.ThrowsException<ArgumentException>(() => new CommandArgumentParser(new[] { "-s" }));
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var parser = new CommandArgumentParser(new[] {"-s", null});
                parser.Parse();
            });
        }

        [TestMethod]
        public void RequiresTwoArguments()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CommandArgumentParser(null));
            Assert.ThrowsException<ArgumentException>(() => new CommandArgumentParser(new string[0]));
            Assert.ThrowsException<ArgumentException>(() => new CommandArgumentParser(new[] { "1", "2", "3" }));
        }
    }
}
