using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_PassNullArgument_ThrowsAnArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Count_StackIsEmpty_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_PassValidArgument_AddsObjectTotheStack()
        {
            _stack.Push("abc");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowsAnInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackHasElement_ReturnElement()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Pop();

            //Assert.That(_stack.Count, Is.EqualTo(1)); //Let's move this to the separate test
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackHasElement_ReturnElementAndStackCountIsZero()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowsAnInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasTwoElements_ReturnObjectOnTheTopOfTheStack()
        {
            _stack.Push("a");
            _stack.Push("b");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_StackHasTwoElements_DoesNotRemoveObjectFromTheStactAndStackCountIsTwo()
        {
            _stack.Push("a");
            _stack.Push("b");

            var result = _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
