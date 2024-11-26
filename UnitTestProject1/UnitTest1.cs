using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizRunner;
using System;
using System.IO;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = Directory.GetCurrentDirectory() + @"\statistika.txt";
            string expected = a;
            Form2 f = new Form2();
            string actual = f.test_S(a);
            Assert.AreEqual(expected, actual, "no directory");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string a = "correct_answers / question_count * persent + 60 + run.Next(0, 15)";
            string expected = a;
            Form2 f = new Form2();
            string actual = f.test_IQ(a);
            Assert.AreEqual(expected, actual, "incorrect IQ formula");
        }
    }
}
