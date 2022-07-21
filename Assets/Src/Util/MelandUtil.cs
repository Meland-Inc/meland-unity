using System;
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

    /// <summary>
    /// 一个中文长度为2，英文长度为1，其他长度为0.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int GetTextNameLen(string name)
    {
        int len = 0;
        for (int i = 0; i < name.Length; i++)
        {
            len += IsChinese(name[i]) ? 2 : 1;
        }
        return len;
    }

    public static bool IsChinese(char c)
    {
        return c is >= (char)0x4E00 and <= (char)0x9FA5; // 根据字符取汉字
    }

    public static T ToEnum<T>(this string str)
    {
        return (T)Enum.Parse(typeof(T), str);
    }

    /// <summary>
    /// 清除委托列表。
    /// </summary>
    /// <param name="action"></param>
    public static void ClearDelegage<T>(Action<T> action)
    {
        if (action != null)
        {
            Delegate[] delegates = action.GetInvocationList();
            for (int i = 0; i < delegates.Length; i++)
            {
                action -= delegates[i] as Action<T>;
            }
        }
    }
}