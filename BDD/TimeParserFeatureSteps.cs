using BerlinClock.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    [Binding]
    public class TimeParserSteps
    {
        private ITimeParser timeParser = new TimeParser(new TimeValidator());

        private Exception exception;
        private Time result;

        [When(@"I parse ""(.*)""")]
        public void WhenIParse(string timeString)
        {
            try
            {
                result = timeParser.Parse(timeString);
            }
            catch (Exception e)
            {
                exception = e;
            }
        }
        
        [Then(@"the hour should be (.*)")]
        public void ThenTheHourShouldBe(int expectedHours)
        {
            Assert.AreEqual(expectedHours, result.Hours);
        }
        
        [Then(@"the minutes should be (.*)")]
        public void ThenTheMinutesShouldBe(int expectedMinutes)
        {
            Assert.AreEqual(expectedMinutes, result.Minutes);
        }
        
        [Then(@"the seconds should be (.*)")]
        public void ThenTheSecondsShouldBe(int expectedSeconds)
        {
            Assert.AreEqual(expectedSeconds, result.Seconds);
        }
        
        [Then(@"exception should be thrown")]
        public void ThenExceptionShouldBeThrown()
        {
            Assert.IsTrue(typeof(ArgumentException).IsAssignableFrom(exception.GetType()));
        }
    }
}
