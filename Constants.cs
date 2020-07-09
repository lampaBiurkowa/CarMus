using System.Collections.Generic;

namespace MusicLib
{
    public static class Constants
    {
        public const int LETTERS_COUNT = 7;
        public const int SEMITONES_COUNT = 12;

        public static Dictionary<Accidental, int> AccidentalOffsetMap = new Dictionary<Accidental, int>
        {
            { Accidental.DOUBLE_FLAT, -2 },
            { Accidental.FLAT, -1 },
            { Accidental.NATURAL, 0 },
            { Accidental.SHARP, 1 },
            { Accidental.DOUBLE_SHARP, 2 }
        };
    }
}
