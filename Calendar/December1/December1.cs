public class December1Puzzle : Calendar.Puzzle
{
    public string Run()
    {
        var input = December1.RocketEquation.LoadInput($"{Tools.RootPath}/resources/dec1/dec1.txt");
        var reqs = December1.RocketEquation.CalculateFuelRequirements(input);
        return reqs.ToString();
    }
}