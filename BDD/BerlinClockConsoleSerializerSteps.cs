using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    [Binding]
    public class BerlinClockConsoleSerializerSteps
    {
        private BerlinClockState state;
        private readonly BerlinClockConsoleSerializer serializer = new BerlinClockConsoleSerializer();
        private string result;

        [Given(@"I have all lights turned on")]
        public void GivenIHaveAllLightsTurnedOn()
        {
            state = new BerlinClockState();
            state.Set
                .TopLight(LightState.On)
                .Line1(new System.Collections.Generic.List<LightState>(){ LightState.On, LightState.On, LightState.On, LightState.On })
                .Line2(new System.Collections.Generic.List<LightState>() { LightState.On, LightState.On, LightState.On, LightState.On })
                .Line3(new System.Collections.Generic.List<LightState>()
                {
                    LightState.On, LightState.On, LightState.On, LightState.On,
                    LightState.On, LightState.On, LightState.On, LightState.On,
                    LightState.On, LightState.On, LightState.On
                })
                .Line4(new System.Collections.Generic.List<LightState>() { LightState.On, LightState.On, LightState.On, LightState.On });
        }
        
        [Given(@"I have all lights turned off")]
        public void GivenIHaveAllLightsTurnedOff()
        {
            state = new BerlinClockState();
            state.Set
                .TopLight(LightState.Off)
                .Line1(new System.Collections.Generic.List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off })
                .Line2(new System.Collections.Generic.List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off })
                .Line3(new System.Collections.Generic.List<LightState>()
                {
                    LightState.Off, LightState.Off, LightState.Off, LightState.Off,
                    LightState.Off, LightState.Off, LightState.Off, LightState.Off,
                    LightState.Off, LightState.Off, LightState.Off
                })
                .Line4(new System.Collections.Generic.List<LightState>() { LightState.Off, LightState.Off, LightState.Off, LightState.Off });
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
