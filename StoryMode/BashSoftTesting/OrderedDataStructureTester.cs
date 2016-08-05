namespace BashSoftTesting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Executor.Contracts;
    using Executor.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }



        [TestMethod]
        public void TestCtorWithiInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithiAllParams()
        {
            this.names = new SimpleSortedList<string>(30, StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }


        [TestMethod]
        public void TestCtorWithiInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestAddIncreaseSize()
        {
            this.names.Add("Pesho");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            string[] input = { "Rosen", "Georgi", "Balkan", };
            string[] expexted = { "Balkan", "Georgi", "Rosen" };
            this.names.AddAll(input);

            int index = 0;

            foreach (var name in names)
            {
                Assert.AreEqual(expexted[index++], name);
            }

        }


        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            int expectedSize = 17;
            int expectedCapacity = 32;

            for (int i = 0; i < expectedSize; i++)
            {
                this.names.Add("name" + i);
            }

            Assert.AreEqual(expectedSize, this.names.Size);
            Assert.AreEqual(expectedCapacity, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            int expectedSize = 2;
            this.names.AddAll(new List<string> { "one", "two" });
            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {

            this.names.AddAll(null);

        }


        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            var input = new List<string> { "Rosen", "Georgi", "Balkan" };
            this.names.AddAll(input);
            input.Sort();

            var index = 0;

            foreach (var name in names)
            {
                Assert.AreEqual(input[index++], name);
            }

        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            var input = new List<string> { "Rosen", "Georgi", "Balkan" };
            this.names.AddAll(input);

            names.Remove("Rosen");

            Assert.AreEqual(2, names.Size);
        }


        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            this.names.Remove("Ivan");
            var result = names.JoinWith("");

            Assert.AreNotEqual("Nasko", result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            this.names.Remove(null);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            var input = new List<string> { "Rosen", "Georgi", "Balkan" };
            names.AddAll(input);
            names.JoinWith(null);

        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            var expectedResult = "Balkan,Georgi,Rosen";
            var input = new List<string> { "Rosen", "Georgi", "Balkan" };
            names.AddAll(input);
            var result = names.JoinWith(",");

            Assert.AreEqual(expectedResult, result);
        }

    }

}
