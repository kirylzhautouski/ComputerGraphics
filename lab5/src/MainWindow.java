import javax.swing.*;
import java.awt.*;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.StringTokenizer;

public class MainWindow extends JFrame {

    static int n, m;
    static ArrayList<ArrayList<Integer>> lines = new ArrayList<>();
    static ArrayList<Integer> rectangle = new ArrayList<>();
    static ArrayList<ArrayList<Integer>> polygon = new ArrayList<>();

    private DrawPanel drawingPanel = new DrawPanel();

    public MainWindow(){
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        int WIDTH = 1100;
        int HEIGHT = 900;
        setSize(WIDTH, HEIGHT);
        setVisible(true);
        setLayout(null);

        drawingPanel.setBounds(0, 0, WIDTH, 560);
        add(drawingPanel);

        JButton stepByStepButton = new JButton("Нарисовать линии");
        stepByStepButton.setBounds(260, 570, 200, 40);
        stepByStepButton.addActionListener(e -> {
            drawingPanel.drawLines(lines);
        });
        add(stepByStepButton);

        JButton drawPolygon = new JButton("Нарисовать полигон");
        drawPolygon.setBounds(20, 570, 200, 40);
        drawPolygon.addActionListener(e -> {
            drawingPanel.drawPolygon(polygon);
        });
        add(drawPolygon);

        JButton CDAButton = new JButton("Нарисовать прямоугольник");
        CDAButton.setBounds(260, 620, 200, 40);
        CDAButton.addActionListener(e -> {
            drawingPanel.drawRectangle(rectangle);
        });
        add(CDAButton);


        JButton clearButton = new JButton("Очистить");
        clearButton.setBounds(260, 770, 200, 40);
        clearButton.addActionListener(e -> {
            drawingPanel.drawLines(new ArrayList<>());
            drawingPanel.drawRectangle(new ArrayList<>());
            drawingPanel.drawPolygon(new ArrayList<>());
        });
        add(clearButton);

        setResizable(false);
    }

    public static void main(String[] args) throws IOException {
        File fin = new File("input.txt");
        Scanner scanner = new Scanner(fin);
        int n = Integer.parseInt(scanner.nextLine());

        for(int i=0;i<n;i++){
            lines.add(new ArrayList<>());
            String[] line = scanner.nextLine().split(" ");
            for(String num : line){
                lines.get(i).add(Integer.parseInt(num));
            }
        }

        rectangle = new ArrayList<>();
        String[] line = scanner.nextLine().split(" ");
        for(String num : line){
            rectangle.add(Integer.parseInt(num));
        }

        polygon.add(new ArrayList<>());
        polygon.get(0).addAll(Arrays.asList(-10, 6, 8, 9));
        polygon.add(new ArrayList<>());
        polygon.get(1).addAll(Arrays.asList(8, 9, 12, 3));
        polygon.add(new ArrayList<>());
        polygon.get(2).addAll(Arrays.asList(12, 3, -10, -8));
        polygon.add(new ArrayList<>());
        polygon.get(3).addAll(Arrays.asList(-10, -8, -10, 6));

        MainWindow mainWindow = new MainWindow();
        mainWindow.repaint();
    }
}
