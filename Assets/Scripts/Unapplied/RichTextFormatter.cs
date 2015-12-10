
public class RichTextFormatter
{
    public enum Colors
    {
        aqua,
        black,
        blue,
        brown,
        darkblue,
        magenta,
        green,
        grey,
        lightblue,
        lime,
        maroon,
        navy,
        olive,
        orange,
        purple,
        red,
        silver,
        teal,
        white,
        yellow
    }

    public static string StringColor(string targetLetter, Colors color)
    {
        return "<color=" + color + ">" + targetLetter + "</color>";
    }
}