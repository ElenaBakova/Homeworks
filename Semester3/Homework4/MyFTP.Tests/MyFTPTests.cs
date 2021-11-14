using System.IO;
using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using System.Threading;

namespace MyFTP.Tests
{
    public class Tests
    {
        private Server server;
        private Client client;
        private readonly IPAddress ip = IPAddress.Parse("127.0.0.1");
        private const int port = 8888;
        private const string path = "../../../Test/";
        private CancellationTokenSource cts = new();

        [SetUp]
        public void SetupAsync()
        {
            server = new Server(port, ip);
            client = new Client(port, ip);
            server.Start();
        }

        [TearDown]
        public void Teardown()
            => server.Shutdown();

        [Test]
        public void IncorrectPathGetShouldThrowException()
        {
            var exceptionCheck = new ResolvableConstraintExpression().InnerException.TypeOf<FileNotFoundException>();
            Assert.Throws(exceptionCheck, () => client.Get("Test/text.txt", cts).Wait());
        }

        [Test]
        public void IncorrectPathListShouldThrowException()
        {
            var exceptionCheck = new ResolvableConstraintExpression().InnerException.TypeOf<DirectoryNotFoundException>();
            Assert.Throws(exceptionCheck, () => client.List("Test", cts).Wait());
        }

        [TestCase(path + "file.txt")]
        [TestCase(path + "Files/textFile.txt")]
        public async Task GetTest(string filePath)
        {
            using var stream = await client.Get(filePath, cts);
            using var streamReader = new StreamReader(stream);
            var file = await streamReader.ReadToEndAsync();

            using var fileStream = File.OpenRead(filePath);
            using var reader = new StreamReader(fileStream);
            var answerFile = await reader.ReadToEndAsync();

            Assert.AreEqual(answerFile, file);
        }
        
        [TestCase(path)]
        [TestCase(path + "Files")]
        public async Task ListTest(string filePath)
        {
            var directory = new DirectoryInfo(filePath);
            var directories = directory.GetDirectories();
            var files = directory.GetFiles();
            var response = await client.List(filePath, cts);
            Assert.AreEqual(files.Length + directories.Length, response.Count);

            int index = 0;
            foreach (var folder in directories)
            {
                Assert.AreEqual(response[index], (folder.Name.ToString(), true));
                index++;
            }
            foreach (var file in files)
            {
                Assert.AreEqual(response[index], (file.Name.ToString(), false));
                index++;
            }
        }
    }
}