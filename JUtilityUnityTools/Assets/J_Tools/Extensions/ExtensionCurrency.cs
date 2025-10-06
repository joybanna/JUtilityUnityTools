using System;
using J_Tools;
using UnityEngine;

public static class ExtensionCurrency
{
    private static readonly string[] PrefixSi = { "", "k", "M", "G", "T", "P", "E", "Z", "Y" };

    public static string GetPrefixSI(this long num)
    {
        try
        {
            if (num == 0) return "0";
            int log10 = (int)Mathf.Log10(num);
            if (log10 < -27) return "0";
            if (log10 % 3 <= 0) log10 -= 3;
            int log1000 = log10 / 3;
            return (num / Mathf.Pow(10, log1000 * 3)).ToString("###,###" + PrefixSi[log1000]);
        }
        catch (Exception e)
        {
            return num.ToString("###,###");
        }
    }
}