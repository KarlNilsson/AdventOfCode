public class December01Puzzle : Calendar.PuzzleClass
{
    public December01Puzzle()
    {
        Title = "The Tyranny of the Rocket Equation";
    }

    public override string Run()
    {
        var input = December01.RocketEquation.LoadInput($"{Tools.RootPath}/resources/dec1/dec1.txt");
        var reqs = December01.RocketEquation.CalculateFuelRequirements(input);
        return reqs.ToString();
    }
}