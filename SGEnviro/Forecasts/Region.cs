namespace SGEnviro
{
    public enum Region
    {
        Central,
        East,
        North,
        South,
        West,
        National,
        Undefined
    }

    public static class RegionUtils
    {
        public static Region Parse(string xmlValue)
        {
            switch (xmlValue)
            {
                case "rNO":
                    return Region.North;
                case "rCE":
                    return Region.Central;
                case "rEA":
                    return Region.East;
                case "rWE":
                    return Region.West;
                case "rSO":
                    return Region.South;
                case "NRS":
                    return Region.National;
                default:
                    return Region.Undefined;
            }
        }
    }
}