using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    [Binding]
    public class BerlinClockConsoleSerializerSteps
    {
        private ClockState state;
        private readonly ClockConsoleSerializer serializer = new ClockConsoleSerializer();
        private string result;

        [Given(@"I have all lights turned on")]
        public void GivenIHaveAllLightsTurnedOn()
        {
            state = new ClockState();
            state.Set
                .TopLight(LightState.On)
                .Line1(new List<LightState>(){ LightState.On, LightState.On, LightState.On, LightState.On })
                .Line2(new List<LightState>() { LightState.On, LightState.On, LightState.On, LightState.On })
                .Line3(new List<LightState>()
                {
                    LightState.On, LightState.On, LightState.On, LightState.On,
                    LightState.On, LightState.On, LightState.On, LightState.On,
                    LightState.On, LightState.On, LightState.On
                })
                .Line4(new List<LightState>() { LightState.On, LightState.On, LightState.On, LightState.On });
        }
        
        [Given(@"I have all lights turned off")]
        public void GivenIHaveAllLightsTurnedOff()
        {
            state = new ClockState();
            state.Set
                .TopLight(LightState.Off)
                .Line1(new List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off })
                .Line2(new List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off })
                .Line3(new List<LightState>()
                {
                    LightState.Off, LightState.Off, LightState.Off, LightState.Off,
                    LightState.Off, LightState.Off, LightState.Off, LightState.Off,
                    LightState.Off, LightState.Off, LightState.Off
                })
                .Line4(new List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off });
        }
        
        [When(@"I serialize the state")]
        public void WhenISerializeTheState()
        {
            result = serializer.Serialize(state);
        }
        
        [Then(@"the output should look like")]
        public void ThenTheOutputShouldLookLike(string multilineText)
        {
            Assert.AreEqual(multilineText, result);
        }
    }
}
