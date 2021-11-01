using MyFTP;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace MyFTP.Tests
{
    public class Tests
    {
        private Server server;
        private Client client;
        private readonly IPAddress iP = IPAddress.Parse("127.0.0.1");
        private const int port = 8888;
        private const string path = "../../../Test/";

        [SetUp]
        public void SetupAsync()
        {
            server = new Server(port, iP);
            client = new Client(port, iP);
            server.Start();
        }

        [TearDown]
        public void Teardown()
            => server.Shutdown();

        [Test]
        public void IncorrectPathGetShouldThrowException()
        {
            var exceptionCheck = new ResolvableConstraintExpression().InnerException.TypeOf<FileNotFoundException>();
            Assert.Throws(exceptionCheck, () => client.Get("Test/text.txt").Wait());
        }

        [Test]
        public void IncorrectPathListShouldThrowException()
        {
            var exceptionCheck = new ResolvableConstraintExpression().InnerException.TypeOf<DirectoryNotFoundException>();
            Assert.Throws(exceptionCheck, () => client.List("Test").Wait());
        }

        [Test]
        public async Task GetTest()
        {
            var filePath = path + "file.txt";
            var response = await client.Get(filePath);
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(fileBytes, response.File);
        }
    }
}