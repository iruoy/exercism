using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var builder = new StringBuilder(identifier.Length);

        for (var i = 0; i < identifier.Length; i++)
        {
            var c = identifier[i];

            builder.Append(c switch
            {
                _ when char.IsControl(c) => "CTRL",
                _ when char.IsWhiteSpace(c) => '_',
                _ when !char.IsLetter(c) => null,
                _ when i > 0 && identifier[i - 1] == '-' => char.ToUpper(c),
                >= 'α' and <= 'ω' => null,
                _ => c
            });
        }

        return builder.ToString();
    }
}