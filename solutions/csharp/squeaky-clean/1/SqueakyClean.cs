using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < identifier.Length; i++)
        {
            var c = identifier[i];

            if (char.IsWhiteSpace(c))
            {
                builder.Append('_');
                continue;
            }

            if (char.IsControl(c))
            {
                builder.Append("CTRL");
                continue;
            }

            if (i > 0 && identifier[i - 1] == '-')
            {
                builder.Append(char.ToUpper(c));
                continue;
            }

            if (!char.IsLetter(c))
            {
                continue;
            }

            if (c is >= 'α' and <= 'ω')
            {
                continue;
            }

            builder.Append(c);
        }

        return builder.ToString();
    }
}