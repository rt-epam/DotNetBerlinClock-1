using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class ClockState
    {
        internal const int Line1Length = 4;
        internal const int Line2Length = 4;
        internal const int Line3Length = 11;
        internal const int Line4Length = 4;

        public ClockState()
        {
            Set = new ClockStateFluentInterface(this);
        }

        public LightState TopLight { get; set; }
        public List<LightState> Line1 { get; } = new List<LightState>(new LightState[Line1Length]);
        public List<LightState> Line2 { get; } = new List<LightState>(new LightState[Line2Length]);
        public List<LightState> Line3 { get; } = new List<LightState>(new LightState[Line3Length]);
        public List<LightState> Line4 { get; } = new List<LightState>(new LightState[Line4Length]);

        public ClockStateFluentInterface Set { get; }
    }

    public class ClockStateFluentInterface
    {
        private const string IncorrectLineLenghtMessage = "Number of elements is not correct";
        private readonly ClockState state;

        public ClockStateFluentInterface(ClockState state)
        {
            this.state = state;
        }

        public ClockStateFluentInterface TopLight(LightState lightState)
        {
            state.TopLight = lightState;
            return this;
        }

        public ClockStateFluentInterface Line1(List<LightState> lightStates)
        {
            ValidateLength(ClockState.Line1Length, lightStates);
            SetLineState(state.Line1, lightStates);
            return this;
        }

        public ClockStateFluentInterface Line2(List<LightState> lightStates)
        {
            ValidateLength(ClockState.Line2Length, lightStates);
            SetLineState(state.Line2, lightStates);
            return this;
        }

        public ClockStateFluentInterface Line3(List<LightState> lightStates)
        {
            ValidateLength(ClockState.Line3Length, lightStates);
            SetLineState(state.Line3, lightStates);
            return this;
        }

        public ClockStateFluentInterface Line4(List<LightState> lightStates)
        {
            ValidateLength(ClockState.Line4Length, lightStates);
            SetLineState(state.Line4, lightStates);
            return this;
        }

        private static void ValidateLength(int expectedLenght, List<LightState> lightStates)
        {
            if (lightStates.Count != expectedLenght)
            {
                throw new ArgumentException(IncorrectLineLenghtMessage);
            }
        }

        private static void SetLineState(List<LightState> line, List<LightState> lightStates)
        {
            for (int i = 0; i < lightStates.Count; i++)
            {
                line[i] = lightStates[i];
            }
        }
    }
}
