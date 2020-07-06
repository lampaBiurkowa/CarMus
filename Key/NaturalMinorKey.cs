namespace MusicLib.Key
{
    class NaturalMinorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public NoteLetter Letter { get; }
    }
}
