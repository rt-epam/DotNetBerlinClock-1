using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock
{
    internal class BerlinClockConsoleSerializer : IBerlinClockConsoleSerializer
    {
        private const string TurnedOffLightSymbol = "O";
        private const string TopLightColor = "Y";
        private const string Line1Colors = "RRRR";
        private const string Line2Colors = "RRRR";
        private const string Line3Colors = "YYRYYRYYRYY";
        private const string Line4Colors = "YYYY";

        public string Serialize(BerlinClockState state)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(state.TopLight == LightState.On ? TopLightColor : TurnedOffLightSymbol);
            stringBuilder.AppendLine(PrintLine(state.Line1, Line1Colors));
            stringBuilder.AppendLine(PrintLine(state.Line2, Line2Colors));
            stringBuilder.AppendLine(PrintLine(state.Line3, Line3Colors));
            stringBuilder.Append(PrintLine(state.Line4, Line4Colors));
            return stringBuilder.ToString();
        }

        private string PrintLine(List<LightState> line, string lineColors)
        {
            var stringBuilder = new StringBuilder();
            for (int i=0; i<line.Count; i++)
            {
                stringBuilder.Append(line[i] == LightState.On ? lineColors[i].ToString() : TurnedOffLightSymbol);
            }
            return stringBuilder.ToString();
        }
    }
}
