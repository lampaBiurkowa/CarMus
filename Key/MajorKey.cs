using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLib.Key
{
    public class MajorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public NoteLetter Letter { get; }
        public int[] Offsets => new int[] { 2, 2, 1, 2, 2, 2, 1 };
        public List<NoteLetter> ScaleLetters { get; }

        public MajorKey()
        {
            int iterator = (int)Letter;
            while (ScaleLetters.Count < Constants.LETTERS_COUNT)
            {
                iterator = (iterator + 1) % Constants.LETTERS_COUNT;
                ScaleLetters.Add((NoteLetter)iterator);
            }
        }

        public Note GetNoteBySemitoneOffset(int semitoneOffset)
        {

        }

        public int GetSemitoneOffsetOfNote(Note note)
        {
            int result = 0;
            for (int i = 0; i < Constants.LETTERS_COUNT; i++)
            {
                if (note.Letter == ScaleLetters[i])
                    break;

                result += Offsets[i];
            }

            if (note.)
        }

        public MajorKey ConvertFrom(IKey key)
        {

        }
    }
}
