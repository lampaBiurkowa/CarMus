using System.Collections.Generic;
using System.Linq;

namespace MusicLib
{
    public static class Constants
    {
        public const int LETTERS_COUNT = 7;
        public const int SEMITONES_COUNT = 12;
        public const double PITCH_CONSTANT = 1.0594630943592952645618252949463417007792043174;
        public const double A0_PITCH = 27.5;

        private static Dictionary<Accidental, int> AccidentalOffsetMap = new Dictionary<Accidental, int>
        {
            { Accidental.TRIPLE_FLAT, -3 },
            { Accidental.DOUBLE_FLAT, -2 },
            { Accidental.FLAT, -1 },
            { Accidental.NATURAL, 0 },
            { Accidental.SHARP, 1 },
            { Accidental.DOUBLE_SHARP, 2 },
            { Accidental.TRIPLE_SHARP, 3 }
        };

        public const NoteLetter OCTAVE_START_LETTER = NoteLetter.C;

        public static int GetOffsetForAccidental(Accidental accidental) => AccidentalOffsetMap[accidental];
        public static Accidental GetAccidentalForOffset(int offset) => AccidentalOffsetMap.Where(i => i.Value == offset).Select(i => i.Key).FirstOrDefault();
    }
}
