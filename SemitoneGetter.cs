namespace MusicLib
{
    public static class wyt
    {
        public static int GetSemitoneOffsetOfNote(Note note)
        {
            int baseSemitoneOffset = 0;
            switch (note.Letter)
            {
                case NoteLetter.A:
                    baseSemitoneOffset = 0;
                    break;
                case NoteLetter.B:
                    baseSemitoneOffset = 2;
                    break;
                case NoteLetter.C:
                    baseSemitoneOffset = 3;
                    break;
                case NoteLetter.D:
                    baseSemitoneOffset = 5;
                    break;
                case NoteLetter.E:
                    baseSemitoneOffset = 7;
                    break;
                case NoteLetter.F:
                    baseSemitoneOffset = 8;
                    break;
                case NoteLetter.G:
                    baseSemitoneOffset = 10;
                    break;
            }
            if (note.Accidental == Accidental.FLAT)
                baseSemitoneOffset = (baseSemitoneOffset - 1) % Constants.SEMITONES_COUNT;
            else if (note.Accidental == Accidental.SHARP)
                baseSemitoneOffset = (baseSemitoneOffset + 1) % Constants.SEMITONES_COUNT;

            return baseSemitoneOffset;
        }
    }
}
