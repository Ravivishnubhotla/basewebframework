namespace Eastasp.Framework.Storage
{
    using System;
    using System.IO;

    public interface IDataChunk
    {
        void ReadData(BinaryReader reader);
        void WriteData(BinaryWriter writer);

        int Length { get; }
    }
}

