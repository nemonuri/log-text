using System.Text;

namespace Nemonuri.LogTexts;

public class CollectionLogTextTheory
{
    public static string ToLogString<T>(T[] source) => ToLogString(source.AsSpan());
    
    public static string ToLogString<T>(Span<T> source) => ToLogString((ReadOnlySpan<T>)source);

    public static string ToLogString<T>(ReadOnlySpan<T> source) => ToLogString<T>
    (
        source: source,
        left: "[",
        right: "]",
        seperator: ",",
        width: 0
    );

    public static string ToLogString<T>
    (
        ReadOnlySpan<T> source,
        string left,
        string right,
        string seperator,
        int width
    )
    {
        int correctedWidth = width;
        if 
        (
            width <= 0 ||
            width > source.Length
        )
        {
            correctedWidth = source.Length;
        }

        StringBuilder sb = new StringBuilder();

        int currentIndex = 0;
        foreach (T item in source)
        {
            if (currentIndex == 0)
            {
                sb.Append(left);
            }
            else
            {
                sb.Append(seperator);
            }

            sb.Append(item);
            
            currentIndex++;

            if (currentIndex >= correctedWidth)
            {
                sb.Append(right);
                currentIndex = 0;
            }
        }

        return sb.ToString();
    }
}
