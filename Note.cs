using MusicLib.Key;
using System.Collections.Generic;

namespace MusicLib
{
    public class Note
    {
        public int Octave { get; set; }
        public Accidental Accidental { get; set; } = Accidental.NATURAL;
        public NoteLetter Letter { get; set; }

        public Note() { }

        public Note(NoteLetter letter, Accidental accidental = Accidental.NATURAL)
        {
            Accidental = accidental;
            Letter = letter;
        }

        public Note(NoteLetter letter, int octave, Accidental accidental = Accidental.NATURAL)
        {
            Accidental = accidental;
            Letter = letter;
            Octave = octave;
        }

        public double GetPitchInHz()
        {
            return 0;
        }

        public void Rise(int semitonesCount, GenericKey key)
        {
            
        }

        public void Lower(int semitonesCount, GenericKey key)
        {

        }

        public bool SameSound(Note note)
        {
            return note.Letter == Letter && note.Accidental == Accidental;
        }

        public void ToKey(GenericKey key)
        {

        }

        public int GetSemitoneOffsetOfNote()
        {
            int baseSemitoneOffset = 0;
            switch (Letter)
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

            return (baseSemitoneOffset + Constants.AccidentalOffsetMap[Accidental]) % Constants.SEMITONES_COUNT;
        }
    }
}
