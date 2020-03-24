package dev.kirillzhelt.processors;

import java.awt.image.BufferedImage;
import java.util.ArrayList;

public class ImageSegmentation {

    public static BufferedImage segmentate(BufferedImage image) {
        BufferedImage processedImage = new BufferedImage(image.getWidth(), image.getHeight(), image.getType());

        double mean = 0;

        int pixelsCount = image.getHeight() * image.getWidth();
        for (int i = 0; i < image.getWidth(); i++) {
            for (int j = 0; j < image.getHeight(); j++) {
                int p = image.getRGB(i, j);
                int a = (p>>24)&0xff;
                int r = (p>>16)&0xff;
                int g = (p>>8)&0xff;
                int b = p&0xff;

                int avg = (r + g + b) / 3;

                p = (a<<24) | (avg<<16) | (avg<<8) | avg;

                mean += (double)p / pixelsCount;

                processedImage.setRGB(i, j, p);
            }
        }

        for (int i = 0; i < processedImage.getWidth(); i++) {
            for (int j = 0; j < processedImage.getHeight(); j++) {
                int p = processedImage.getRGB(i, j);

                if (p > mean) {
                    processedImage.setRGB(i, j, Utils.colorToRGB(255, 255, 255, 255));
                } else {
                    processedImage.setRGB(i, j, Utils.colorToRGB(255, 0, 0, 0));
                }
            }
        }

        return processedImage;
    }
}
