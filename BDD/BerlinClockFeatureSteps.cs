using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BerlinClock.Validation;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly IBerlinClockConsoleSerializer consoleSerializer;
        private readonly ITimeParser timeParser;
        private readonly ITimeConverter berlinClock;
        private String theTime;

        public TheBerlinClockSteps()
        {
            timeParser = new TimeParser(new TimeValidator());
            consoleSerializer = new BerlinClockConsoleSerializer();
            berlinClock = new TimeConverter(timeParser, consoleSerializer);
        }
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
