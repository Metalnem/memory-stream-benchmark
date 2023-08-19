using System.Security.Cryptography;

namespace MemoryStreamBenchmark;

public class Item
{
    public int A { get; set; }
    public string B { get; set; }
    public DateTime C { get; set; }

    public Item()
    {
        A = RandomNumberGenerator.GetInt32(1_000_000);
        B = RandomNumberGenerator.GetHexString(10);
        C = DateTime.Now.AddSeconds(RandomNumberGenerator.GetInt32(1_000_000));
    }
}
