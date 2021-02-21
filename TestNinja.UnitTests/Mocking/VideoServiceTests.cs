using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {

        Mock<IFileReader> _fileReader { get; set; }
        VideoService _videoService { get; set; }

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        //Testing with Moq
        // For Dependency Injection Via Constructor
        [Test]
        public void ReadVideoTitleDependencyInjectionViaConstructorUsingMock_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitleDependencyInjectionViaConstructor();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        #region different dependeny injection examples: by Method parameter, by Property & by Constructor
        ////[Test]
        ////public void ReadVideoTitleDependencyInjectionViaMethodParameter_EmptyFile_ReturnError()
        ////{
        ////    var service = new VideoService();

        ////    var result = service.ReadVideoTitleDependencyInjectionViaMethodParameter(new FakeFileReader());

        ////    Assert.That(result, Does.Contain("error").IgnoreCase);
        ////}

        //////For Dependency Injection Via Property
        //////[Test]
        //////public void ReadVideoTitleDependencyInjectionViaProperty_EmptyFile_ReturnError()
        //////{
        //////    var service = new VideoService();
        //////    service.FileReader = new FakeFileReader();

        //////    var result = service.ReadVideoTitleInjectionViaProperty();

        //////    Assert.That(result, Does.Contain("error").IgnoreCase);
        //////}

        ////// For Dependency Injection Via Constructor
        ////[Test]
        ////public void ReadVideoTitleDependencyInjectionViaConstructor_EmptyFile_ReturnError()
        ////{
        ////    var service = new VideoService(new FakeFileReader());

        ////    var result = service.ReadVideoTitleDependencyInjectionViaConstructor();

        ////    Assert.That(result, Does.Contain("error").IgnoreCase);
        ////}
        #endregion
    }
}
