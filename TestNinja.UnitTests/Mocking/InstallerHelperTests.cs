using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestNinja.Mocking;
using System.Net;

namespace TestNinja.UnitTests.Mocking
{


    [TestFixture]
    public class InstallerHelperTests
    {
        Mock<IFileDownloader> _fileDownloader { get; set; }

        private InstallerHelper _installerHelper;

        string _customerName { get; set; }
        string _installerName { get; set; }

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
            _customerName = "a";
            _installerName = "b";
        }

        [Test]
        public void DownloadInstaller_WhenCalled_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller(_customerName, _installerName);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_WhenCalledThrowsWebException_ReturnsFalse()
        {
            //this works but we pass complicated string in DownloadFile method, 
            //we do not alwas have that luxury to see what the method expects to get...
            //_fileDownloader.Setup(fd => 
            //                      fd.DownloadFile(string.Format("http://example.com/{0}/{1}", _customerName, _installerName), null))
            //                      .Throws(new WebException());
            //... we can simplify things with Moq build in class It.IsAny<string>()
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new WebException());

            var result = _installerHelper.DownloadInstaller(_customerName, _installerName);

            Assert.That(result, Is.EqualTo(false));
        }

        //What if method Throws other exception?
        //We don't need to write test for any other exception - the method returns flase for the WebException
        //If any other exception will be thrown, it will be caugth by for example a logger in the app
        //if we write test for any other exception we can hide potential problem in the app.

    }
}
