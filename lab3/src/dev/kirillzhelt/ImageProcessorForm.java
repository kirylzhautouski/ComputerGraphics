package dev.kirillzhelt;

import dev.kirillzhelt.processors.HistogramEqualization;
import dev.kirillzhelt.processors.ImageSegmentation;
import dev.kirillzhelt.processors.LinearContrasting;

import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.nio.file.Paths;
import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;

public class ImageProcessorForm extends JFrame {
    private JLabel imageLabel;
    private JLabel processedImageLabel;

    private String selectedImagePath;

    public ImageProcessorForm() {
        super("Image Processor");

        JButton browseButton = new JButton("Browse");
        browseButton.setBounds(20,500,100,40);
        browseButton.addActionListener(e -> {
            JFileChooser file = new JFileChooser();
            file.setCurrentDirectory(new File(System.getProperty("user.home")));

            FileNameExtensionFilter filter = new FileNameExtensionFilter("*.Images", "jpg", "gif", "png");
            file.addChoosableFileFilter(filter);
            int result = file.showSaveDialog(null);

            if (result == JFileChooser.APPROVE_OPTION) {
                File selectedFile = file.getSelectedFile();
                this.selectedImagePath = selectedFile.getAbsolutePath();
                imageLabel.setIcon(resizeImage(this.selectedImagePath));
            }
            else if (result == JFileChooser.CANCEL_OPTION) {
                System.out.println("No File Select");
            }
        });
        this.add(browseButton);

        JButton linearContrastingButton = new JButton("Linear contrasting");
        linearContrastingButton.setBounds(150,500, 200, 40);
        linearContrastingButton.addActionListener(e -> {
            if (this.selectedImagePath != null) {
                File imageFile = new File(this.selectedImagePath);
                try {
                    BufferedImage originalImage = ImageIO.read(imageFile);
                    BufferedImage processedImage = LinearContrasting.changeContrast(originalImage);

                    String destFileName = Paths.get(imageFile.getParentFile().getAbsolutePath() + "/linearContrasting",
                        imageFile.getName()).toString();
                    File dir = new File(imageFile.getParentFile().getAbsolutePath() + "/linearContrasting");
                    if (!dir.exists()) {
                        boolean isCreated = dir.mkdir();
                    }
                    ImageIO.write(processedImage, "jpg", new File(destFileName));
                    processedImageLabel.setIcon(resizeImage(destFileName));
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        });
        this.add(linearContrastingButton);

        JButton segmentateButton = new JButton("Segmentate");
        segmentateButton.setBounds(360,500, 200, 40);
        segmentateButton.addActionListener(e -> {
            if (this.selectedImagePath != null) {
                File imageFile = new File(this.selectedImagePath);
                try {
                    BufferedImage originalImage = ImageIO.read(imageFile);
                    BufferedImage processedImage = ImageSegmentation.segmentate(originalImage);

                    String destFileName = Paths.get(imageFile.getParentFile().getAbsolutePath() + "/segmentation",
                        imageFile.getName()).toString();
                    File dir = new File(imageFile.getParentFile().getAbsolutePath() + "/segmentation");
                    if (!dir.exists()) {
                        boolean isCreated = dir.mkdir();
                    }
                    ImageIO.write(processedImage, "jpg", new File(destFileName));
                    processedImageLabel.setIcon(resizeImage(destFileName));
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        });
        this.add(segmentateButton);

        JButton equalizeButton = new JButton("Equalize");
        equalizeButton.setBounds(570,500, 200, 40);
        equalizeButton.addActionListener(e -> {
            if (this.selectedImagePath != null) {
                File imageFile = new File(this.selectedImagePath);
                try {
                    BufferedImage originalImage = ImageIO.read(imageFile);
                    BufferedImage processedImage = HistogramEqualization.equalize(originalImage);

                    String destFileName = Paths.get(imageFile.getParentFile().getAbsolutePath() + "/equalize",
                        imageFile.getName()).toString();
                    File dir = new File(imageFile.getParentFile().getAbsolutePath() + "/equalize");
                    if (!dir.exists()) {
                        boolean isCreated = dir.mkdir();
                    }
                    ImageIO.write(processedImage, "jpg", new File(destFileName));
                    processedImageLabel.setIcon(resizeImage(destFileName));
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        });
        this.add(equalizeButton);

        imageLabel = new JLabel();
        imageLabel.setBounds(10, 10, 600, 400);
        this.add(imageLabel);

        processedImageLabel = new JLabel();
        processedImageLabel.setBounds(710, 10, 600, 400);
        this.add(processedImageLabel);

        setLayout(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocation(50, 50);
        setSize(1500,700);
        setExtendedState(JFrame.MAXIMIZED_BOTH);
        setVisible(true);
    }

    private ImageIcon resizeImage(String ImagePath) {
        ImageIcon MyImage = new ImageIcon(ImagePath);
        Image img = MyImage.getImage();
        Image newImg = img.getScaledInstance(imageLabel.getWidth(), imageLabel.getHeight(), Image.SCALE_SMOOTH);
        return new ImageIcon(newImg);
    }

    public static void main(String[] args){
        new ImageProcessorForm();
    }
}

