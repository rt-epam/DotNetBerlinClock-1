using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class BerlinClockState
    {
        internal const int Line1Length = 4;
        internal const int Line2Length = 4;
        internal const int Line3Length = 11;
        internal const int Line4Length = 4;

        public BerlinClockState()
        {
            Set = new BerlinClockStateFluentInterface(this);
        }

        public LightState TopLight { get; set; }
        public List<LightState> Line1 { get; } = new List<LightState>(new LightState[Line1Length]);
        public List<LightState> Line2 { get; } = new List<LightState>(new LightState[Line2Length]);
        public List<LightState> Line3 { get; } = new List<LightState>(new LightState[Line3Length]);
        public List<LightState> Line4 { get; } = new List<LightState>(new LightState[Line4Length]);

        public BerlinClockStateFluentInterface Set { get; }
    }

    public class BerlinClockStateFluentInterface
    {
        private const string IncorrectLineLenghtMessage = "Number of elements is not correct";
        private readonly BerlinClockState state;

        public BerlinClockStateFluentInterface(BerlinClockState state)
        {
            this.state = state;
        }

        public BerlinClockStateFluentInterface TopLight(LightState lightState)
        {
            state.TopLight = lightState;
            return this;
        }

        public BerlinClockStateFluentInterface Line1(List<LightState> line1)
        {
            if (line1.Count != BerlinClockState.Line1Length)
            {
                throw new ArgumentException(IncorrectLineLenghtMessage);
            }
            for (int i=0; i < line1.Count; i++)
            {
                state.Line1[i] = line1[i];
            }
            return this;
        }

        public BerlinClockStateFluentInterface Line2(List<LightState> line2)
        {
            if (line2.Count != BerlinClockState.Line2Length)
            {
                throw new ArgumentException(IncorrectLineLenghtMessage);
            }
            for (int i = 0; i < line2.Count; i++)
            {
                state.Line2[i] = line2[i];
            }
            return this;
        }

        public BerlinClockStateFluentInterface Line3(List<LightState> line3)
        {
            if (line3.Count != BerlinClockState.Line3Length)
            {
                throw new ArgumentException(IncorrectLineLenghtMessage);
            }
            for (int i = 0; i < line3.Count; i++)
            {
                state.Line3[i] = line3[i];
            }
            return this;
        }

        public BerlinClockStateFluentInterface Line4(List<LightState> line4)
        {
            if (line4.Count != BerlinClockState.Line4Length)
            {
                throw new ArgumentException(IncorrectLineLenghtMessage);
            }
            for (int i = 0; i < line4.Count; i++)
            {
                state.Line4[i] = line4[i];
            }
            return this;
        }
    }
}
