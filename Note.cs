using MusicLib.Key;

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

        public void Rise(int semitonesCount)
        {

        }

        public void Lower(int semitonesCount)
        {

        }

        public bool SameSound(Note note)
        {
            return note.Letter == Letter && note.Accidental == Accidental;
        }

        public void ToKey(IKey key)
        {

        }
    }
}
