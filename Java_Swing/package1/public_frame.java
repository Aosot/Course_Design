package java_swing.package1;

import javax.swing.*;

public class public_frame extends JFrame{
    public public_frame(){
        setTitle("主交互界面");
        setSize(600,400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        MyPanel mp=new MyPanel();
        add(mp);

        setVisible(true);
    }
    public static void main(String[]args)
    {
        new public_frame();
    }
}
