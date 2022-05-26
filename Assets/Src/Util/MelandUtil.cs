using System.Security.Cryptography;
using System.Text;

public static class MelandUtil
{
    public static string GetMd5(string input)
    {
        // Create a new instance of the MD5CryptoServiceProvider object.
        MD5 md5 = MD5.Create();
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input));
        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new();
        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            _ = sBuilder.Append(data[i].ToString("x2"));
        }
        // Return the hexadecimal string.
        return sBuilder.ToString();
    }
}