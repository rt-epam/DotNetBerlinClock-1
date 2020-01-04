using System.Collections.Generic;

namespace BerlinClock
{
    public class Clock
    {
        private Clock()
        {
            State = new BerlinClockState();
        }

        public static Clock Initialize(Time time)
        {
            var clock = new Clock();
            clock.State.Set
                .TopLight(TurnOnIf(IsEven(time.Seconds)))
                .Line1(new List<LightState>() { TurnOnIf(time.Hours >= 5), TurnOnIf(time.Hours >= 10), TurnOnIf(time.Hours >= 15), TurnOnIf(time.Hours >= 20) })
                .Line2(new List<LightState>() { TurnOnIf(time.Hours % 5 >= 1), TurnOnIf(time.Hours % 5 >= 2), TurnOnIf(time.Hours % 5 >= 3), TurnOnIf(time.Hours % 5 >= 4) })
                .Line3(new List<LightState>()
                {
                    TurnOnIf(time.Minutes >=  5), TurnOnIf(time.Minutes >= 10), TurnOnIf(time.Minutes >= 15), TurnOnIf(time.Minutes >= 20),
                    TurnOnIf(time.Minutes >= 25), TurnOnIf(time.Minutes >= 30), TurnOnIf(time.Minutes >= 35), TurnOnIf(time.Minutes >= 40),
                    TurnOnIf(time.Minutes >= 45), TurnOnIf(time.Minutes >= 50), TurnOnIf(time.Minutes >= 55)
                })
                .Line4(new List<LightState>() { TurnOnIf(time.Minutes % 5 >= 1), TurnOnIf(time.Minutes % 5 >= 2), TurnOnIf(time.Minutes % 5 >= 3), TurnOnIf(time.Minutes % 5 >= 4) });
            return clock;
        }

        public BerlinClockState State { get; private set; }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static LightState TurnOnIf(bool condition)
        {
            return condition ? LightState.On : LightState.Off;
        }
    }
}
