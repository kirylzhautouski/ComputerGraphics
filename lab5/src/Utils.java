public class Utils {
    private final static float EPSILON = 0.01f;

    public static boolean feq(double f1, double f2) {
        return (Math.abs(f1 - f2) < EPSILON);
    }
}
