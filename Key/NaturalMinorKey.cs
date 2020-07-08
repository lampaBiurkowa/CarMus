namespace MusicLib.Key
{
    class NaturalMinorKey : IKey
    {
        public KeyType KeyType => KeyType.MAJOR;
        public NoteLetter Letter { get; }

        public Note Note => throw new System.NotImplementedException();
    }
}
