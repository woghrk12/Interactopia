using System.Text;  
using System.Security.Cryptography;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    #region Variables

    private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new Dictionary<float, WaitForSeconds>();

    #endregion Variables

    #region Methods

    public static WaitForSeconds WaitForSeconds(float p_sec)
    {
        if (waitForSeconds.ContainsKey(p_sec)) return waitForSeconds[p_sec];
        WaitForSeconds t_wfs = new WaitForSeconds(p_sec);
        waitForSeconds.Add(p_sec, t_wfs);
        return t_wfs;
    }

    public static string ComputeMD5(string seed, int length)
    {
        StringBuilder md5Str = new();
        byte[] byteArr = Encoding.ASCII.GetBytes(seed);
        byte[] resultArr = (new MD5CryptoServiceProvider()).ComputeHash(byteArr);

        for (int idx = 0; idx < length; idx++) { md5Str.Append(resultArr[idx].ToString("X2")); }

        return md5Str.ToString();
    }

    public string MD5HashFunc(string str)
    {
        StringBuilder MD5Str = new StringBuilder();
        byte[] byteArr = Encoding.ASCII.GetBytes(str);
        byte[] resultArr = (new MD5CryptoServiceProvider()).ComputeHash(byteArr);

        //for (int cnti = 1; cnti < resultArr.Length; cnti++) (2010.06.27)
        for (int cnti = 0; cnti < resultArr.Length; cnti++)
        {
            MD5Str.Append(resultArr[cnti].ToString("X2"));
        }
        return MD5Str.ToString();
    }

    #endregion Methods
}
