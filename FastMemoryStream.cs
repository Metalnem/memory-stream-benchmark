namespace MemoryStreamBenchmark;

public sealed class FastMemoryStream : Stream
{
    private readonly Memory<byte> _buffer;
    private int _position;

    public FastMemoryStream(Memory<byte> buffer)
    {
        _buffer = buffer;
    }

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;

    public override long Length => _buffer.Length;

    public override long Position
    {
        get => _position;
        set => _position = (int)value;
    }

    public override void Flush() { }

    public override int Read(Span<byte> buffer)
    {
        var n = Math.Min(_buffer.Length - _position, buffer.Length);

        _buffer.Span.Slice(_position, n).CopyTo(buffer);
        _position += n;

        return n;
    }
    public override int Read(byte[] buffer, int offset, int count)
    {
        var n = Math.Min(_buffer.Length - _position, count);
        var destination = new Span<byte>(buffer, offset, n);

        _buffer.Span.Slice(_position, n).CopyTo(destination);
        _position += n;

        return n;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotImplementedException();
    }

    public override void SetLength(long value)
    {
        throw new NotImplementedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotImplementedException();
    }
}
