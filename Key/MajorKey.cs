namespace MusicLib.Key
{
    public class MajorKey : GenericKey
    {
        public override KeyType KeyType => KeyType.MAJOR;
        public override int[] Offsets => new int[] { 2, 2, 1, 2, 2, 2, 1 };

        public MajorKey(Note note) : base(note) { }
    }
}
