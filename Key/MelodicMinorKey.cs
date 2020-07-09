namespace MusicLib.Key
{
    public class MelodicMinorKey : GenericKey
    {
        public override KeyType KeyType => KeyType.MAJOR;
        public override int[] Offsets => new int[] { 2, 2, 1, 2, 2, 2, 1 };

        public MelodicMinorKey(Note note) : base(note) { }
    }
}
