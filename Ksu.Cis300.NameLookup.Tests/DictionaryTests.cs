/* DictionaryTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// Gets a dictionary containing seven keys and values.
        /// </summary>
        private Dictionary<int, string> LoadDictionary()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(10, "Ten");
            d.Add(5, "Five");
            d.Add(15, "Fifteen");
            d.Add(3, "Three");
            d.Add(7, "Seven");
            d.Add(13, "Thirteen");
            d.Add(20, "Twenty");
            return d;
        }

        /// <summary>
        /// Tests whether the proper exception is thrown when an attempt is made to remove
        /// a null key.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARemoveNullKey()
        {
            Exception e = null;
            Dictionary<string, string> d = new Dictionary<string, string>();
            try
            {
                d.Remove(null);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentNullException)));
        }

        /// <summary>
        /// Tests that removing from an empty dictionary returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestARemoveFromEmpty()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            Assert.That(d.Remove("x"), Is.False);
        }

        /// <summary>
        /// Tests that after adding one key, it can be removed.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddOneRemoveIt()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            d.Add("one", 1);
            bool removeResult = d.Remove("one");
            int v;
            bool lookupResult = d.TryGetValue("one", out v);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.True);
                Assert.That(lookupResult, Is.False);
            });
        }

        /// <summary>
        /// Builds a tree with 7 nodes, removes a leaf, then looks up all 7 keys.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCRemoveLeaf()
        {
            Dictionary<int, string> d = LoadDictionary();
            bool removeResult = d.Remove(13);
            d.TryGetValue(3, out string lookup3Result);
            d.TryGetValue(5, out string lookup5Result);
            d.TryGetValue(7, out string lookup7Result);
            d.TryGetValue(10, out string lookup10Result);
            d.TryGetValue(13, out string lookup13Result);
            d.TryGetValue(15, out string lookup15Result);
            d.TryGetValue(20, out string lookup20Result);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.True);
                Assert.That(lookup3Result, Is.EqualTo("Three"));
                Assert.That(lookup5Result, Is.EqualTo("Five"));
                Assert.That(lookup7Result, Is.EqualTo("Seven"));
                Assert.That(lookup10Result, Is.EqualTo("Ten"));
                Assert.That(lookup13Result, Is.Null);
                Assert.That(lookup15Result, Is.EqualTo("Fifteen"));
                Assert.That(lookup20Result, Is.EqualTo("Twenty"));
            });
        }

        /// <summary>
        /// Builds a tree with 7 nodes, removes a leaf, then its parent, then looks up all 7 keys.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDRemoveLeafThenItsParent()
        {
            Dictionary<int, string> d = LoadDictionary();
            d.Remove(13);
            bool removeResult = d.Remove(15);
            d.TryGetValue(3, out string lookup3Result);
            d.TryGetValue(5, out string lookup5Result);
            d.TryGetValue(7, out string lookup7Result);
            d.TryGetValue(10, out string lookup10Result);
            d.TryGetValue(13, out string lookup13Result);
            d.TryGetValue(15, out string lookup15Result);
            d.TryGetValue(20, out string lookup20Result);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.True);
                Assert.That(lookup3Result, Is.EqualTo("Three"));
                Assert.That(lookup5Result, Is.EqualTo("Five"));
                Assert.That(lookup7Result, Is.EqualTo("Seven"));
                Assert.That(lookup10Result, Is.EqualTo("Ten"));
                Assert.That(lookup13Result, Is.Null);
                Assert.That(lookup15Result, Is.Null);
                Assert.That(lookup20Result, Is.EqualTo("Twenty"));
            });
        }

        /// <summary>
        /// Builds a tree with 7 nodes, removes a leaf, then its parent, then looks up all 7 keys.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDRemoveOtherLeafThenItsParent()
        {
            Dictionary<int, string> d = LoadDictionary();
            d.Remove(20);
            bool removeResult = d.Remove(15);
            d.TryGetValue(3, out string lookup3Result);
            d.TryGetValue(5, out string lookup5Result);
            d.TryGetValue(7, out string lookup7Result);
            d.TryGetValue(10, out string lookup10Result);
            d.TryGetValue(13, out string lookup13Result);
            d.TryGetValue(15, out string lookup15Result);
            d.TryGetValue(20, out string lookup20Result);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.True);
                Assert.That(lookup3Result, Is.EqualTo("Three"));
                Assert.That(lookup5Result, Is.EqualTo("Five"));
                Assert.That(lookup7Result, Is.EqualTo("Seven"));
                Assert.That(lookup10Result, Is.EqualTo("Ten"));
                Assert.That(lookup13Result, Is.EqualTo("Thirteen"));
                Assert.That(lookup15Result, Is.Null);
                Assert.That(lookup20Result, Is.Null);
            });
        }

        /// <summary>
        /// Builds a tree with 7 nodes, removes the root, then looks up all 7 keys.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestERemoveRoot()
        {
            Dictionary<int, string> d = LoadDictionary();
            bool removeResult = d.Remove(10);
            d.TryGetValue(3, out string lookup3Result);
            d.TryGetValue(5, out string lookup5Result);
            d.TryGetValue(7, out string lookup7Result);
            d.TryGetValue(10, out string lookup10Result);
            d.TryGetValue(13, out string lookup13Result);
            d.TryGetValue(15, out string lookup15Result);
            d.TryGetValue(20, out string lookup20Result);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.True);
                Assert.That(lookup3Result, Is.EqualTo("Three"));
                Assert.That(lookup5Result, Is.EqualTo("Five"));
                Assert.That(lookup7Result, Is.EqualTo("Seven"));
                Assert.That(lookup10Result, Is.Null);
                Assert.That(lookup13Result, Is.EqualTo("Thirteen"));
                Assert.That(lookup15Result, Is.EqualTo("Fifteen"));
                Assert.That(lookup20Result, Is.EqualTo("Twenty"));
            });
        }

        /// <summary>
        /// Builds a tree with 7 nodes, tries to remove a key that is not there, then
        /// looks up all 7 keys.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFRemoveMissing()
        {
            Dictionary<int, string> d = LoadDictionary();
            bool removeResult = d.Remove(9);
            d.TryGetValue(3, out string lookup3Result);
            d.TryGetValue(5, out string lookup5Result);
            d.TryGetValue(7, out string lookup7Result);
            d.TryGetValue(10, out string lookup10Result);
            d.TryGetValue(13, out string lookup13Result);
            d.TryGetValue(15, out string lookup15Result);
            d.TryGetValue(20, out string lookup20Result);
            Assert.Multiple(() =>
            {
                Assert.That(removeResult, Is.False);
                Assert.That(lookup3Result, Is.EqualTo("Three"));
                Assert.That(lookup5Result, Is.EqualTo("Five"));
                Assert.That(lookup7Result, Is.EqualTo("Seven"));
                Assert.That(lookup10Result, Is.EqualTo("Ten"));
                Assert.That(lookup13Result, Is.EqualTo("Thirteen"));
                Assert.That(lookup15Result, Is.EqualTo("Fifteen"));
                Assert.That(lookup20Result, Is.EqualTo("Twenty"));
            });
        }
    }
}