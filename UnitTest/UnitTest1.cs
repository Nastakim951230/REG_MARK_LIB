using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using REG_MARK_LIB;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Проверка на корректный номер (выдает верный результат)
        public void CheckMark_IsTrue()
        {
            string mark = "A123BM125";
            bool actual=Class1.CheckMark(mark);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        //Проверка на корректный регистрационный номер (выдает ошибку при неверном регистрационном номере )
        public void CheckMark_RegistrNomerNotCorrectly()
        {
            string mark = "A000BM125";
            bool actual = Class1.CheckMark(mark);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        //Проверка на корректный код региона регистрации (выдает ошибку при неверном коде региона регистрации )
        public void CheckMark_KodRegionaRegistratsiiNotCorrectly()
        {
            string mark = "A124BM000";
            bool actual = Class1.CheckMark(mark);
            Assert.IsFalse(actual);
        }
        // Проверку, что метод который выдаёт следующий номер корректен 
        [TestMethod]
        public void GetNextMarkAfter_Correctly()
        {
            string exception = "B001BA152";
            string mark = "A999BX152";
            string actual = Class1.GetNextMarkAfter(mark);
            Assert.AreEqual(exception, actual);
        }

        // Проверку, что метод который выдаёт следующий номер, выводить результпт который не являетяс верным
        [TestMethod]
        public void GetNextMarkAfter_IsFalse()
        {
            string exception = "B123BA152";
            string mark = "B125BA152";
            string actual = Class1.GetNextMarkAfter(mark);
            Assert.IsFalse(exception==actual);
        }

        //Проверку, что метод который выдаёт следующий номер,выдает следующий номер
        [TestMethod]
        public void GetNextMarkAfter_IsNotNull()
        {
            string exception = "X998XX152";
            string actual = Class1.GetNextMarkAfter(exception);
            Assert.IsNotNull(actual);
        }
        //Проверку, что метод который выдаёт следующий номер находиться в диапозоне введенных номеров
        [TestMethod]
        public void GetNextMarkAfterInRange_IsTrue()
        {
            string exception = "A018AA152";
            string prevMark = "A017AA152";
            string rangeStart = "A016AA152";
            string rangeEnd = "A019AA152";
            string actual = Class1.GetNextMarkAfterInRange(prevMark,rangeStart,rangeEnd);
            Assert.IsTrue(exception == actual);
        }
        // Проверяет, что метод для определения следующего номера в диапозоне высчитывает корректно и выводит результат с правильным типом данных
        [TestMethod]
        public void GetNextMarkAfterInRange_CorrectlyType()
        {
            string prevMark = "A005AA152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Class1.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsInstanceOfType(actual, typeof(string));
        }

        // Проверяет, что метод который выдаёт количество возможных номеров в диапозоне
        [TestMethod]
        public void GetCombinationsCountInRange_Correctly()
        {
            int exception = 1009;
            string mark1 = "B001AA152";
            string mark2 = "B010AB152";
            int actual = Class1.GetCombinationsCountInRange(mark1, mark2);
            Assert.AreEqual(exception, actual);
        }
        // Проверяет, что метод который выдаёт количество возможных номеров в диапозоне, выводит результат значение которого не равно не правильному
        [TestMethod]
        public void GetCombinationsCountInRange_NotCorrectly()
        {
            int exception = 40;
            string mark1 = "B001AA152";
            string mark2 = "B010AA152";
            int actual = Class1.GetCombinationsCountInRange(mark1, mark2);
            Assert.IsTrue(exception != actual);
        }

        // Проверяет, что метод который выдаёт количество возможных номеров в диапозоне возвращает результат с верным типом
        [TestMethod]
        public void GetCombinationsCountInRange_TypeCorrectly()
        {
            string mark1 = "A001AA152";
            string mark2 = "A010AB152";
            int actual =  Class1.GetCombinationsCountInRange(mark1, mark2);
            Assert.IsInstanceOfType(actual, typeof(int));
        }

        // Методы высокой сложности
        // Проверяет, что метод для определения корректности номера выдёт корректное значение если передано не правильное значение
        [TestMethod]
        public void CheckMark_CorrectlyType()
        {
            string mark = "A000AA152";
            bool actual = Class1.CheckMark(mark);
            Assert.IsInstanceOfType(actual, typeof(bool));
        }

        // Проверкa, что метод который выдаёт следующий номер, выведет ошибку при ввыедение последнего номера
        [TestMethod]
        public void GetNextMarkAfter_Error()
        {
            string exception = "X999XX152";
            string mark = "error";
            string actual = Class1.GetNextMarkAfter(exception);
            Assert.AreEqual(mark, actual);
        }

        // Проверкa, что метод для определения следующего номера в диапозоне выводит сообщение, если предыдущий номер не входит в диапозон
        [TestMethod]
        public void GetNextMarkAfterInRange_NotCorrectly()
        {
            string exception = "out of stock";
            string prevMark = "A990AB152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Class1.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsTrue(exception == actual);
        }
    }
}
