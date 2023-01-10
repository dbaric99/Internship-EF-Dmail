namespace UtilityLibrary;
using System.Security.Cryptography;
using System.Text;

public static class PasswordLibrary
{
    private static readonly string SecurityKey = "StZ0kU9L/2IN0ycWGdypQvoOSEOn16pvKG59OLbkgjc=";
    
    public static string EncryptPassword(string password)
    {
        var toEncryptedArr = Encoding.UTF8.GetBytes(password);
        var objMd5CryptoService = new MD5CryptoServiceProvider();
        var securityKeyArr = objMd5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
        
        objMd5CryptoService.Clear();

        var objTripleDescCryptoService = new TripleDESCryptoServiceProvider();
        objTripleDescCryptoService.Key = securityKeyArr;
        objTripleDescCryptoService.Mode = CipherMode.ECB;
        objTripleDescCryptoService.Padding = PaddingMode.PKCS7;

        var objCryptoTransform = objTripleDescCryptoService.CreateEncryptor();
        var resultArr = objCryptoTransform.TransformFinalBlock(toEncryptedArr, 0, toEncryptedArr.Length);
        objTripleDescCryptoService.Clear();

        return Convert.ToBase64String(resultArr, 0, resultArr.Length);
    }
    
    public static string DecryptPassword(string encryptedPassword)
    {
        var toEncryptArr = Convert.FromBase64String(encryptedPassword);
        var objMd5CryptoService = new MD5CryptoServiceProvider();
        var securityKeyArr = objMd5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
        
        objMd5CryptoService.Clear();

        var objTripleDescCryptoService = new TripleDESCryptoServiceProvider();
        objTripleDescCryptoService.Key = securityKeyArr;
        objTripleDescCryptoService.Mode = CipherMode.ECB;

        var objCryptoTransform = objTripleDescCryptoService.CreateDecryptor();
        var resultArr = objCryptoTransform.TransformFinalBlock(toEncryptArr, 0, toEncryptArr.Length);
        objTripleDescCryptoService.Clear();

        return Encoding.UTF8.GetString(resultArr);
    }
}