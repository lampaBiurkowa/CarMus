namespace MusicLib.Key
{
    public class HarmonicMinorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public NoteLetter Letter { get; }
    }
}
