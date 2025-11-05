using System.Text.RegularExpressions;


namespace ShopApp.Domain.Abstractions.Guards;

public static class Guard
{
    public static IGuardClause Against { get; } = new GuardClause();

    private class GuardClause : IGuardClause
    {
        public void NullOrWhiteSpace(string value, string message)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(message);
        }

        public void Negative(int value, string message)
        {
            if(value < 0)
                throw new ArgumentException(message);
        }

        public void Negative(decimal value, string message)
        {
            if(value < 0)
                throw new ArgumentException(message);
        }

        public void MaxLength(int value, int maxLength,string message)
        {
            if(value > maxLength)
                throw new ArgumentException(message);
        }

        public void InvalidFormat(string value, Regex pattern,string message)
        {
            if(!pattern.IsMatch(value.ToString()))
                throw new FormatException(message);
        }
    }

}