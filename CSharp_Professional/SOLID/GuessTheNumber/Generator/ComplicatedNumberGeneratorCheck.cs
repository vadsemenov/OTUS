namespace GuessTheNumber
{
    public static class ComplicatedNumberGeneratorCheck
    {
        public static bool CheckNumber(int number)
        {
            if (number != 0 && number > 0 && number < 1000)
                return true;

            return false;
        }
    }
}