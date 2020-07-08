using System;
using System.Collections.Generic;
using System.Linq;

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
            int currentOffset = wyt.GetSemitoneOffsetOfNote(Note);
            int iterator = (int)Note.Letter;
            int i = 0;
            Accidental accidental = Note.Accidental;
            while (ScaleNotes.Count < Constants.LETTERS_COUNT)
            {
                Note n = new Note();
                n.Letter = (NoteLetter)iterator;
                int naturalNoteOffset = wyt.GetSemitoneOffsetOfNote(n);
                switch(currentOffset - naturalNoteOffset)
                {
                    case 2:
                        n.Accidental = Accidental.DOUBLE_SHARP;
                        break;
                    case 1:
                        n.Accidental = Accidental.SHARP;
                        break;
                    case -1:
                        n.Accidental = Accidental.FLAT;
                        break;
                    case -2:
                        n.Accidental = Accidental.DOUBLE_FLAT;
                        break;
                }

                if (currentOffset == naturalNoteOffset - 1)
                    n.Accidental = Accidental.FLAT;
                else if (currentOffset == naturalNoteOffset + 1)
                    n.Accidental = Accidental.SHARP;
                ScaleNotes.Add(n);
                iterator = (iterator + 1) % Constants.LETTERS_COUNT;
                currentOffset = (currentOffset + Offsets[i]) % Constants.SEMITONES_COUNT;
                i++;
            }
        }

        public MajorKey ConvertFrom(IKey key)
        {
            return this;
        }
    }
}
