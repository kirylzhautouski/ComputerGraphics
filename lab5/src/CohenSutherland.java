import java.util.ArrayList;
import java.util.Arrays;

public class CohenSutherland {

    private static final int INSIDE = 0;
    private static final int LEFT   = 1;
    private static final int RIGHT  = 2;
    private static final int BOTTOM = 4;
    private static final int TOP    = 8;

    private static int regionCode(double x, double y, int xMin, int yMin, int xMax, int yMax) {
        int code = x < xMin
            ? LEFT
            : x > xMax
            ? RIGHT
            : INSIDE;
        if (y < yMin) code |= BOTTOM;
        else if (y > yMax) code |= TOP;
        return code;
    }

    public static ArrayList<Integer> calc(ArrayList<Integer> line, ArrayList<Integer> rect){
        double p1x = line.get(0);
        double p1y = line.get(1);
        double p2x = line.get(2);
        double p2y = line.get(3);

        int xMin = rect.get(0);
        int yMin = rect.get(1);
        int xMax = rect.get(2);
        int yMax = rect.get(3);

        double qx = 0;
        double qy = 0;

        boolean vertical = p1x == p2x;

        double slope = vertical
            ? 0
            : (p2y - p1y) / (p2x - p1x);

        int c1 = regionCode(p1x, p1y, xMin, yMin, xMax, yMax);
        int c2 = regionCode(p2x, p2y, xMin, yMin, yMax, yMax);

        ArrayList<Integer> in = new ArrayList<>();

        while (c1 != INSIDE || c2 != INSIDE) {

            if ((c1 & c2) != INSIDE)
                return in;

            int c = c1 == INSIDE ? c2 : c1;

            if ((c & LEFT) != INSIDE) {
                qx = xMin;
                qy = (Utils.feq(qx, p1x) ? 0 : qx - p1x) * slope + p1y;
            }
            else if ((c & RIGHT) != INSIDE) {
                qx = xMax;
                qy = (Utils.feq(qx, p1x) ? 0 : qx - p1x) * slope + p1y;
            }
            else if ((c & BOTTOM) != INSIDE) {
                qy = yMin;
                qx = vertical
                    ? p1x
                    : (Utils.feq(qy, p1y) ? 0 : qy - p1y) / slope + p1x;
            }
            else if ((c & TOP) != INSIDE) {
                qy = yMax;
                qx = vertical
                    ? p1x
                    : (Utils.feq(qy, p1y) ? 0 : qy-p1y) / slope + p1x;
            }

            if (c == c1) {
                p1x = qx;
                p1y = qy;
                c1  = regionCode(p1x, p1y, xMin, yMin, xMax, yMax);
            }
            else {
                p2x = qx;
                p2y = qy;
                c2 = regionCode(p2x, p2y, xMin, yMin, xMax, yMax);
            }
        }

        in.add((int)p1x);
        in.add((int)p1y);
        in.add((int)p2x);
        in.add((int)p2y);

        return in;
    }
}
