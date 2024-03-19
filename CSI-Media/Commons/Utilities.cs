namespace CSI_Media.Commons
{
    public class Utilities
    {
        public static List<int> ParseNumbersFromInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<int>(); // Empty list for empty input
            }

            return input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(numberString => int.TryParse(numberString.Trim(), out int number) ? number : 0)
                        //.Where(number => number.HasValue)
                        .ToList();
        }
    }
}
