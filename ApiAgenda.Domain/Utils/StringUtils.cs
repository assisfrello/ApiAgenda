using System.Text.RegularExpressions;

namespace ApiAgenda.Domain.Utils;

public static class StringUtils
{
    private static readonly Regex NonDigitsRegex = new ("[^\\d]+");
  
    public static string FormatEx(this string aValue, params object[]? aArgs) =>
        aValue.IsNullOrWhiteSpace() || aArgs == null || aArgs.Length == 0 ? aValue : string.Format(aValue, aArgs);
    
    private static bool IsNullOrWhiteSpace(this string aValue) => string.IsNullOrWhiteSpace(aValue);

    private static string OnlyNumbers(this string aValue) => string.IsNullOrEmpty(aValue) ? aValue : NonDigitsRegex.Replace(aValue, "");

    public static bool ValidarDocumento(this string documento) =>
      documento.OnlyNumbers().Length == 11 ? documento.ValidaCPF() : documento.ValidaCNPJ();

    public static bool ValidarUf(this string uf)
    {
        var ufdValidas = new List<string>
        {
            "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES",
            "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
            "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
            "SP", "SE", "TO"
        };

        return ufdValidas.Contains(uf.ToUpper());
    }
    
    public static bool ValidarNumeroCelular(this string celular)
    {
        var pattern = @"^\(\d{2}\)\s9\d{4}-\d{4}$";
        return Regex.IsMatch(celular, pattern);
    }
    
    public static bool ValidarEmail(this string email)
    {
        var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
    
    #region Validação de CPF e CNPJ

    private static bool ValidaCPF(this string? vrCpf)
    {
        if (vrCpf == null)
            return false;
        string str = vrCpf.Replace(".", "").Replace("-", "").Replace(",", "");
        if (str.Length != 11)
            return false;
        bool flag = true;
        for (int index = 1; index < 11 & flag; ++index)
        {
            if ((int) str[index] != (int) str[0])
                flag = false;
        }
        if (flag || str == "12345678909")
            return false;
        int[] numArray = new int[11];
        for (int index = 0; index < 11; ++index)
            numArray[index] = int.Parse(str[index].ToString());
        int num1 = 0;
        for (int index = 0; index < 9; ++index)
            num1 += (10 - index) * numArray[index];
        int num2 = num1 % 11;
        switch (num2)
        {
            case 0:
            case 1:
                if (numArray[9] != 0)
                    return false;
                break;
            default:
                if (numArray[9] != 11 - num2)
                    return false;
                break;
        }
        int num3 = 0;
        for (int index = 0; index < 10; ++index)
            num3 += (11 - index) * numArray[index];
        int num4 = num3 % 11;
        switch (num4)
        {
            case 0:
            case 1:
                if (numArray[10] != 0)
                    return false;
                break;
            default:
                if (numArray[10] != 11 - num4)
                    return false;
                break;
        }
        return true;
    }

    private static bool ValidaCNPJ(this string vrCnpj)
    {
        string str1 = vrCnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        string str2 = "6543298765432";
        int[] numArray1 = new int[14];
        int[] numArray2 = new int[2]{ 0, 0 };
        int[] numArray3 = new int[2]{ 0, 0 };
        bool[] flagArray = new bool[2]{ false, false };
        try
        {
            for (int startIndex = 0; startIndex < 14; ++startIndex)
            {
                numArray1[startIndex] = int.Parse(str1.Substring(startIndex, 1));
                if (startIndex <= 11)
                    numArray2[0] += numArray1[startIndex] * int.Parse(str2.Substring(startIndex + 1, 1));
                if (startIndex <= 12)
                    numArray2[1] += numArray1[startIndex] * int.Parse(str2.Substring(startIndex, 1));
            }
            for (int index = 0; index < 2; ++index)
            {
                numArray3[index] = numArray2[index] % 11;
                flagArray[index] = numArray3[index] == 0 || numArray3[index] == 1 ? numArray1[12 + index] == 0 : numArray1[12 + index] == 11 - numArray3[index];
            }
            return flagArray[0] && flagArray[1];
        }
        catch
        {
            return false;
        }
    }

    #endregion
}