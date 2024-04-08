using Domain;
using System.Security.Cryptography;
using System.Text;

public class EncryptionService : IEncryptionService
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("RUNEMAXSOULAIMAN"); // Key should be of length 16, 24 or 32
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("SOULAIMANMAXRUNE"); // IV should be of length 16

    public string Encrypt(string data)
    {
        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
            sw.Write(data);

        var encrypted = ms.ToArray();

        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string data)
    {
        var buffer = Convert.FromBase64String(data);

        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream(buffer);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        var decrypted = sr.ReadToEnd();

        return decrypted;
    }
}
