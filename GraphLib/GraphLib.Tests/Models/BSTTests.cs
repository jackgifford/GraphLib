using GraphLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Tests.Models
{
    [TestClass]
    public class BSTTests
    {
        [TestMethod]
        public void Blah()
        {
            var binary = new BinarySearchTree<int>();

            binary.Insert(15);
            binary.Insert(10);
            binary.Insert(20);

            Assert.IsTrue(binary.Search(15));
            Assert.IsTrue(binary.Search(10));
            Assert.IsTrue(binary.Search(20));
        }
    }
}
