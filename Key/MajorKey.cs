using System.Collections.Generic;

namespace MusicLib.Key
{
    public class MajorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public Note Note { get; }
        public int[] Offsets => new int[] { 2, 2, 1, 2, 2, 2, 1 };
        public List<Note> ScaleNotes { get; } = new List<Note>();

        public MajorKey(Note note)
        {
            Note = note;
            int currentOffset = note.GetSemitoneOffsetOfNote();
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
            switch (currentOffset - note.GetSemitoneOffsetOfNote())
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

        public MajorKey ConvertFrom(IKey key)
        {
            return this;
        }
    }
}
