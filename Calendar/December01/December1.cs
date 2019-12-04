public class December1Puzzle : Calendar.Puzzle
{
    public string Run()
    {
        var input = December01.RocketEquation.LoadInput($"{Tools.RootPath}/resources/dec1/dec1.txt");
        var reqs = December01.RocketEquation.CalculateFuelRequirements(input);
        return reqs.ToString();
    }
}