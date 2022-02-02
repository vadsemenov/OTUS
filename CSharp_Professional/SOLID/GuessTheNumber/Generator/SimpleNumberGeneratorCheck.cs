namespace GuessTheNumber
{
    public static class SimpleNumberGeneratorCheck
    {
        public static bool CheckNumber(int number)
        {
            if (number != 0 && number > 0)
                return true;

            return false;
        }
    }
}