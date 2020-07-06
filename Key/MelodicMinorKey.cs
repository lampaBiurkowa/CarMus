namespace MusicLib.Key
{
    public class MelodicMinorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public NoteLetter Letter { get; }
    }
}
