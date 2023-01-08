using System.Security.Cryptography;
using System.Text;

namespace Dmail.Presentation.Helpers;

public static class PasswordHelper
{
    private static readonly string SecurityKey = GetKey();
    
    private static string GetKey()
    {
        var algorithm = Aes.Create();
        algorithm.KeySize = 256;
        algorithm.GenerateKey();
        return Convert.ToBase64String(algorithm.Key);
    }

    public static string EncryptPassword(string password)
    {
        var toEncryptedArr = Encoding.UTF8.GetBytes(password);
        var objMD5CryptoService = new MD5CryptoServiceProvider();
        var securityKeyArr = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
        
        objMD5CryptoService.Clear();

        var objTripleDESCCryptoService = new TripleDESCryptoServiceProvider();
        objTripleDESCCryptoService.Key = securityKeyArr;
        objTripleDESCCryptoService.Mode = CipherMode.ECB;
        objTripleDESCCryptoService.Padding = PaddingMode.PKCS7;

        var objCryptoTransform = objTripleDESCCryptoService.CreateEncryptor();
        var resultArr = objCryptoTransform.TransformFinalBlock(toEncryptedArr, 0, toEncryptedArr.Length);
        objTripleDESCCryptoService.Clear();

        return Convert.ToBase64String(resultArr, 0, resultArr.Length);
    }

    public static string DecryptPassword(string cryptedPassword)
    {
        var toEncryptArr = Convert.FromBase64String(cryptedPassword);
        var objMD5CryptoService = new MD5CryptoServiceProvider();
        var securityKeyArr = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
        
        objMD5CryptoService.Clear();

        var objTripleDESCCryptoService = new TripleDESCryptoServiceProvider();
        objTripleDESCCryptoService.Key = securityKeyArr;
        objTripleDESCCryptoService.Mode = CipherMode.ECB;

        var objCryptoTransform = objTripleDESCCryptoService.CreateDecryptor();
        var resultArr = objCryptoTransform.TransformFinalBlock(toEncryptArr, 0, toEncryptArr.Length);
        objTripleDESCCryptoService.Clear();

        return Encoding.UTF8.GetString(resultArr);
    }
}