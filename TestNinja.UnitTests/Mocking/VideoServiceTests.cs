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
        [Test]
        public void ReadVideoTitleDependencyInjectionViaMethodParameter_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            var result = service.ReadVideoTitleDependencyInjectionViaMethodParameter(new FakeFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        //For Dependency Injection Via Property
        //[Test]
        //public void ReadVideoTitleDependencyInjectionViaProperty_EmptyFile_ReturnError()
        //{
        //    var service = new VideoService();
        //    service.FileReader = new FakeFileReader();

        //    var result = service.ReadVideoTitleInjectionViaProperty();

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        // For Dependency Injection Via Constructor
        [Test]
        public void ReadVideoTitleDependencyInjectionViaConstructor_EmptyFile_ReturnError()
        {
            var service = new VideoService(new FakeFileReader());

            var result = service.ReadVideoTitleDependencyInjectionViaConstructor();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
