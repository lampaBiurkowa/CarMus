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
            addPerfectBasedInterval(minSemitonesCount += 1);
            addNonPerfectBasedInterval(minSemitonesCount += 1);
            addNonPerfectBasedInterval(minSemitonesCount += 2);
            addPerfectBasedInterval(minSemitonesCount += 2);
        }

        static void addPerfectBasedInterval(int minSemitonesCount)
        {
            intervalsMap.Add(new Dictionary<int, IntervalQuality> {
                {minSemitonesCount, IntervalQuality.DIMINISHED },
                {minSemitonesCount + 1, IntervalQuality.PERFECT },
                {minSemitonesCount + 2, IntervalQuality.AUGMENTED }
            });
        }

        static void addNonPerfectBasedInterval(int minSemitonesCount)
        {
            intervalsMap.Add(new Dictionary<int, IntervalQuality> {
                {minSemitonesCount, IntervalQuality.DIMINISHED },
                {minSemitonesCount + 1, IntervalQuality.MINOR },
                {minSemitonesCount + 2, IntervalQuality.MAJOR },
                {minSemitonesCount + 3, IntervalQuality.AUGMENTED }
            });
        }

        public IntervalQuality Quality { get; set; } = IntervalQuality.GENERIC;
        public int Length { get; set; }

        public Interval() { }
        public Interval(int length, IntervalQuality quality = IntervalQuality.GENERIC)
        {
            Length = length;
            Quality = quality;
        }

        public static Interval DetermineInterval(Note note1, Note note2)
        {
            int semitonesDifference = note2.GetTotalSemitoneOffsetOfNote() - note1.GetTotalSemitoneOffsetOfNote();
            int lettersDifference = (note2.Letter - note1.Letter + 1 + Constants.LETTERS_COUNT) % Constants.LETTERS_COUNT;

            IntervalQuality quality = intervalsMap[lettersDifference][semitonesDifference];
            return new Interval(lettersDifference, quality);
        }
    }
}
