namespace GuessTheNumber
{
    interface INumberGenerator
    {
        int Digit { get; set; }
        bool GenerateDigit(int maxDigit);
    }
}