﻿using NUnit.Framework;
using System;
using System.Linq;
using Template.Components.Logging;
using Template.Data.Core;
using Template.Objects;
using Template.Tests.Data;

namespace Template.Tests.Unit.Components.Logging
{
    [TestFixture]
    public class LoggerTests
    {
        private AContext context;
        private Logger logger;

        [SetUp]
        public void SetUp()
        {
            context = new TestingContext();
            logger = new Logger(context);

            context.Set<Log>().RemoveRange(context.Set<Log>());
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        #region Method: Log(String message)

        [Test]
        public void Log_LogsMessage()
        {
            if (context.Set<Log>().Count() > 0)
                Assert.Inconclusive();

            String expected = new String('L', 10000);
            logger.Log(expected);

            Log actualLog = context.Set<Log>().First();

            Assert.AreEqual(1, context.Set<Log>().Count());
            Assert.AreEqual(expected, actualLog.Message);
        }

        #endregion

        #region Method: Dispose()

        [Test]
        public void Dispose_CanBeCalledMultipleTimes()
        {
            logger.Dispose();
            logger.Dispose();
        }

        #endregion
    }
}