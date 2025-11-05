using System.Text.RegularExpressions;


namespace ShopApp.Domain.Abstractions.Guards;

public interface IGuardClause
{
    /// <summary>
    /// Bir STRİNG'in nyll, boş veya sadece boşluk olup olmadığını kontrol eder.
    /// </summary>
    /// <param name = "value">Kontrol edilecek değer.</param>
    /// <param name = "message"> Hata durumunda fırlatılacak mesaj.</param>
    /// <exception cref = "ArgumentException">Eğer değer geçersizse.</exception>

    void NullOrWhiteSpace(string value, string message);

    ///<summary>
    /// Bir sayının negatif olup olmadığını kontrol eder.
    /// </summary>
    /// <exception cref = "ArgumentException">Eğer değer negatifse.</exception>

    void Negative(decimal value, string message);
    void Negative(int value, string message);
    
    ///<summary>
    /// Bir stringin max uzunluğunu kontrol eder.
    /// </summary>
    /// <exception cref = "ArgumentException">Eğer string maxlengthten uzunsa</exception>
    
    void MaxLength(int value, int maxLength,string message);
    
    ///<summary>
    /// Bir stringin regex formatına uyup uymadığını kontrol eder.
    /// </summary>
    /// <exception cref = "FormatException">Eğer string regexe uymuyorsa</exception>
    
    void InvalidFormat(string value, Regex pattern,string message);
    
}