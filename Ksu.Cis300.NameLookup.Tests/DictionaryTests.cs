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
        /// Tests that a correct exception is thrown when a null key is added.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAAddNullKey()
        {
            Exception ex = null;
            try
            {
                Dictionary<string, float> d = new Dictionary<string, float>();
                d.Add(null, 0);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.That(ex, Is.Not.Null.And.TypeOf(typeof(ArgumentNullException)));
        }

        /// <summary>
        /// Tests that a correct exception is thrown when a null key is looked up.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestALookUpNullKey()
        {
            Dictionary<string, double> d = new Dictionary<string, double>();
            double x;
            Exception ex = null;
            try
            {
                d.TryGetValue(null, out x);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.That(ex, Is.Not.Null.And.TypeOf(typeof(ArgumentNullException)));
        }

        /// <summary>
        /// Tests a lookup on an empty dictionary. TryGetValue should return false
        /// and set its out parameter to null.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBLookUpEmpty()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(7, out s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds one key and value, then looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddOneLookItUp()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            d.Add("one", 1);
            int i;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue("one", out i), Is.True);
                Assert.That(i, Is.EqualTo(1));
            });
        }

        /// <summary>
        /// Tests that the proper exception is thrown if a duplicate key is added.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddDuplicate()
        {
            Exception ex = null;
            try
            {
                Dictionary<string, int> d = new Dictionary<string, int>();
                d.Add("two", 2);
                d.Add("one", 1);
                d.Add("two", 2);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.That(ex, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// first in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFirst()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(3, out s), Is.True);
                Assert.That(s, Is.EqualTo("Three"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// second in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSecond()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(5, out s), Is.True);
                Assert.That(s, Is.EqualTo("Five"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// third in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpThird()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(7, out s), Is.True);
                Assert.That(s, Is.EqualTo("Seven"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// fourth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFourth()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(10, out s), Is.True);
                Assert.That(s, Is.EqualTo("Ten"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// fifth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFifth()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(13, out s), Is.True);
                Assert.That(s, Is.EqualTo("Thirteen"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// sixth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSixth()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(15, out s), Is.True);
                Assert.That(s, Is.EqualTo("Fifteen"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be last
        /// in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpLast()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(20, out s), Is.True);
                Assert.That(s, Is.EqualTo("Twenty"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up a key smaller than any in the dictionary.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSmaller()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(2, out s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up a nonexistent key belonging in the
        /// middle of the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpMiddle()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(12, out s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds five keys and values, then looks up a key larger than any in the dictionary.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpGreater()
        {
            Dictionary<int, string> d = LoadDictionary();
            string s;
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(25, out s), Is.False);
                Assert.That(s, Is.Null);
            });
        }
    }
}