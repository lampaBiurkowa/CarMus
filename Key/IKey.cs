using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLib.Key
{
    public interface IKey
    {
        KeyType KeyType { get; }
        Note Note { get; }
    }
}
