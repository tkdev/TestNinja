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

        private Mock<IVideoRepository> _videoRepository;

        VideoService _videoService { get; set; }

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
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

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ThreeMoviesInRepository_ReturnStringWithIdsOfUnprocessedVideos()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>() { 
            new Video { Id = 1, IsProcessed = false, Title = "a"},
            new Video { Id = 2, IsProcessed = false, Title = "b"},
            new Video { Id = 3, IsProcessed = false, Title = "c"}
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
