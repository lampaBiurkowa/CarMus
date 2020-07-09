namespace MusicLib.Key
{
    public class HarmonicMinorKey : GenericKey
    {
        public override KeyType KeyType => KeyType.HARMONIC_MINOR;
        public override int[] Offsets => new int[] { 2, 2, 1, 2, 2, 2, 1 };

        public HarmonicMinorKey(Note note) : base(note) { }
    }
}
