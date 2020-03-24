package dev.kirillzhelt.processors;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.util.ArrayList;

public class LinearContrasting {

    public static BufferedImage changeContrast(BufferedImage image) {
        BufferedImage newImage = new BufferedImage(image.getWidth(), image.getHeight(), image.getType());
        ArrayList<int[]> imageHist = Utils.imageHistogram(image);

        // Fill the lookup table
        int[] rhistogram = imageHist.get(0);
        int[] ghistogram = imageHist.get(1);
        int[] bhistogram = imageHist.get(2);

        double discard_ratio = 0.01;
        int[][] hists = new int[3][256];

        hists[0] = rhistogram;
        hists[1] = ghistogram;
        hists[2] = bhistogram;

        // cumulative hist
        int total = image.getWidth() * image.getHeight();

        int[] vmin = new int[3];
        int[] vmax = new int[3];

        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 255; ++j) {
                hists[i][j + 1] += hists[i][j];
            }
            vmin[i] = 0;
            vmax[i] = 255;
            while (hists[i][vmin[i]] < discard_ratio * total)
                vmin[i] += 1;
            while (hists[i][vmax[i]] > (1 - discard_ratio) * total)
                vmax[i] -= 1;
            if (vmax[i] < 255 - 1)
                vmax[i] += 1;
        }


        for (int y = 0; y < image.getWidth(); ++y) {
            for (int x = 0; x < image.getHeight(); ++x) {

                int[] rgbValues = new int[3];

                for (int j = 0; j < 3; ++j) {
                    int val = 0;
                    int red = new Color(image.getRGB(y, x)).getRed();
                    int green = new Color(image.getRGB(y, x)).getGreen();
                    int blue = new Color(image.getRGB(y, x)).getBlue();

                    if (j == 0) val = red;
                    if (j == 1) val = green;
                    if (j == 2) val = blue;

                    if (val < vmin[j])
                        val = vmin[j];
                    if (val > vmax[j])
                        val = vmax[j];

                    rgbValues[j] = (int)((val - vmin[j]) * 255.0 / (vmax[j] - vmin[j]));
                }
                int alpha = new Color(image.getRGB(y, x)).getAlpha();
                int newPixel = Utils.colorToRGB(alpha, rgbValues[0], rgbValues[1], rgbValues[2]);
                newImage.setRGB(y, x, newPixel);
            }
        }

        return newImage;
    }

}
