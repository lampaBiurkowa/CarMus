namespace MusicLib.Key
{
    public class NaturalMinorKey : GenericKey
    {
        public override KeyType KeyType => KeyType.NATURAL_MINOR;
        public override int[] Offsets => new int[] { 2, 1, 2, 2, 1, 2, 2 };

        public NaturalMinorKey(Note note) : base(note) { }
    }
}
