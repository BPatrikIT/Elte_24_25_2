public enum Color {
    White, Black, Brown, Yellow
}

public static class ColorExtensions {
    public static double GetMultiplier(this Color color) =>
        color switch {
            Color.White => 1.0,
            Color.Black => 0.8,
            Color.Brown => 1.2,
            Color.Yellow => 1.1,
            _ => 1.0
        };
}