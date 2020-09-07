using System.Collections.Generic;

namespace MusicLib
{
    public class Interval
    {
        static List<Dictionary<int, IntervalQuality>> intervalsMap = new List<Dictionary<int, IntervalQuality>>();
        
        static Interval()
        {
            int minSemitonesCount = -1;
            addPerfectBasedInterval(minSemitonesCount);
            addNonPerfectBasedInterval(minSemitonesCount += 1);
            addNonPerfectBasedInterval(minSemitonesCount += 2);
            addPerfectBasedInterval(minSemitonesCount += 2);
            addPerfectBasedInterval(minSemitonesCount += 2);
            addNonPerfectBasedInterval(minSemitonesCount += 1);
            addNonPerfectBasedInterval(minSemitonesCount += 2);
            addPerfectBasedInterval(minSemitonesCount += 2);
        }

        static void addPerfectBasedInterval(int minSemitonesCount)
        {
            intervalsMap.Add(new Dictionary<int, IntervalQuality> {
                { minSemitonesCount, IntervalQuality.DIMINISHED },
                { minSemitonesCount + 1, IntervalQuality.PERFECT },
                { minSemitonesCount + 2, IntervalQuality.AUGMENTED }
            });
        }

        static void addNonPerfectBasedInterval(int minSemitonesCount)
        {
            intervalsMap.Add(new Dictionary<int, IntervalQuality> {
                { minSemitonesCount, IntervalQuality.DIMINISHED },
                { minSemitonesCount + 1, IntervalQuality.MINOR },
                { minSemitonesCount + 2, IntervalQuality.MAJOR },
                { minSemitonesCount + 3, IntervalQuality.AUGMENTED }
            });
        }

        public int AdditionalOctaves { get; set; }
        public IntervalQuality Quality { get; set; } = IntervalQuality.GENERIC;
        public int Length { get; set; }

        public Interval(int length, IntervalQuality quality = IntervalQuality.GENERIC, int additionalOctaves = 0)
        {
            Length = length % (Constants.LETTERS_COUNT + 1) + 1;
            AdditionalOctaves = additionalOctaves;
            Quality = quality;
        }

        public static Interval DetermineInterval(Note note1, Note note2)
        {
            int semitonesDifference = note2.GetTotalSemitoneOffsetOfNote() - note1.GetTotalSemitoneOffsetOfNote();
            int lettersDifference = (note2.Letter - note1.Letter + Constants.LETTERS_COUNT) % Constants.LETTERS_COUNT;

            IntervalQuality quality = intervalsMap[lettersDifference % Constants.LETTERS_COUNT][semitonesDifference % Constants.SEMITONES_COUNT];
            return new Interval(lettersDifference, quality, semitonesDifference / Constants.SEMITONES_COUNT);
        }
    }
}
