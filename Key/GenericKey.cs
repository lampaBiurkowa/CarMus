using System.Collections.Generic;
using System.Linq;

namespace MusicLib.Key
{
    public abstract class GenericKey
    {
        public abstract KeyType KeyType { get; }
        public Note Note { get; }
        public abstract int[] Offsets { get; }
        public List<Note> ScaleNotes { get; } = new List<Note>();

        public GenericKey(Note note)
        {
            Note = note;
            fillScaleNotes();
        }

        private void fillScaleNotes()
        {
            int currentOffset = Note.GetGenericSemitoneOffsetOfNote();
            int letterIterator = (int)Note.Letter;
            while (ScaleNotes.Count < Constants.LETTERS_COUNT)
            {
                Note generatedNote = generateNoteForScale(currentOffset, letterIterator);
                letterIterator = (letterIterator + 1) % Constants.LETTERS_COUNT;
                currentOffset = (currentOffset + Offsets[ScaleNotes.Count]) % Constants.SEMITONES_COUNT;
                ScaleNotes.Add(generatedNote);
            }
        }

        private Note generateNoteForScale(int currentOffset, int letterIterator)
        {
            Note note = new Note((NoteLetter)letterIterator);
            switch (currentOffset - note.GetGenericSemitoneOffsetOfNote())
            {
                case 2: case -10:
                    note.Accidental = Accidental.DOUBLE_SHARP;
                    break;
                case 1: case -11:
                    note.Accidental = Accidental.SHARP;
                    break;
                case -1: case 11:
                    note.Accidental = Accidental.FLAT;
                    break;
                case -2: case 10:
                    note.Accidental = Accidental.DOUBLE_FLAT;
                    break;
            }

            return note;
        }

        public bool IsInKey(Note note) => ScaleNotes.Any(n => n.SameBesideOctave(note));

        public GenericKey ConvertFrom(GenericKey key)
        {
            return this;
        }
    }
}
