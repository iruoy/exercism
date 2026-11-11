public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var (prefix, payload) = reading switch
        {
            > uint.MaxValue or < int.MinValue => (-sizeof(long), BitConverter.GetBytes(reading)),
            > int.MaxValue => (sizeof(uint), BitConverter.GetBytes((uint)reading)),
            > ushort.MaxValue or < short.MinValue => (-sizeof(int), BitConverter.GetBytes((int)reading)),
            >= 0 => (sizeof(ushort), BitConverter.GetBytes((ushort)reading)),
            _ => (-sizeof(short), BitConverter.GetBytes((short)reading))
        };

        var buffer = new byte[9];
        buffer[0] = (byte)prefix;
        payload.CopyTo(buffer, 1);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) =>
        (sbyte)buffer[0] switch
        {
            -sizeof(long) => BitConverter.ToInt64(buffer, 1),
            sizeof(uint) => BitConverter.ToUInt32(buffer, 1),
            -sizeof(int) => BitConverter.ToInt32(buffer, 1),
            sizeof(ushort) => BitConverter.ToUInt16(buffer, 1),
            -sizeof(short) => BitConverter.ToInt16(buffer, 1),
            _ => 0
        };
}