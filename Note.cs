using MusicLib.Key;
using System;
using System.Collections.Generic;
using System.Linq;

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
            int semitonesFactor = Letter < Constants.OCTAVE_START_LETTER ? GetSemitoneOffsetOfNote() : GetSemitoneOffsetOfNote() - Constants.SEMITONES_COUNT;
            return Constants.A0_PITCH * Math.Pow(Constants.PITCH_CONSTANT, (Octave * Constants.SEMITONES_COUNT) + semitonesFactor);
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

        public Note ToKey(GenericKey originalKey, GenericKey newKey)
        {
            int scaleIndex = originalKey.ScaleNotes.IndexOf(originalKey.ScaleNotes.Where(item => item.Letter == Letter).FirstOrDefault());
            int originalKeyAccidentalSemitoneOffset = Constants.GetOffsetForAccidental(originalKey.ScaleNotes[scaleIndex].Accidental);
            int newKeyAccidentalSemitoneOffset = Constants.GetOffsetForAccidental(newKey.ScaleNotes[scaleIndex].Accidental);
            int ownAccidentalSemitoneOffset = Constants.GetOffsetForAccidental(Accidental);
            int outOfKeyOffset = ownAccidentalSemitoneOffset - originalKeyAccidentalSemitoneOffset;
            Accidental newAccidental = Constants.GetAccidentalForOffset(newKeyAccidentalSemitoneOffset + outOfKeyOffset);
            NoteLetter newLetter = newKey.ScaleNotes[scaleIndex].Letter;

            return new Note(newLetter, getOctaveOfNoteInNewKey(newLetter), newAccidental);
        }

        int getOctaveOfNoteInNewKey(NoteLetter newLetter)
        {
            int newOctave = Octave;
            if (Letter < Constants.OCTAVE_START_LETTER && newLetter >= Constants.OCTAVE_START_LETTER)
                newOctave++;
            else if (Letter >= Constants.OCTAVE_START_LETTER && newLetter < Constants.OCTAVE_START_LETTER)
                newOctave--;

            return newOctave;
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

            return (baseSemitoneOffset + Constants.GetOffsetForAccidental(Accidental)) % Constants.SEMITONES_COUNT;
        }
    }
}
