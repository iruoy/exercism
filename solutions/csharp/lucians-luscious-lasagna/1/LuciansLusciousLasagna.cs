class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int amountOfMinutesInOven)
    {
        return ExpectedMinutesInOven() - amountOfMinutesInOven;
    }

    public int PreparationTimeInMinutes(int amountOfLayers)
    {
        return amountOfLayers * 2;
    }

    public int ElapsedTimeInMinutes(int amountOfLayers, int amountOfMinutesInOven)
    {
        return PreparationTimeInMinutes(amountOfLayers) + amountOfMinutesInOven;
    }
}
