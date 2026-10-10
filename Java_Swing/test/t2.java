package java_swing.test;

import java.awt.*;
import javax.swing.*;

public class t2 extends JFrame{
    public t2()
    {
        setTitle("t2");
        setSize(600,400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        MYPANEL my=new MYPANEL();
        add(my);

        setVisible(true);
    }
    public static void main(String[]args)
    {
        new t2();
    }
}

class MYLABEL
{
    int x,y,w,h;
    String s;
    public MYLABEL(int x,int y,int w,int h,String s)
    {
        this.x=x;
        this.y=y;
        this.w=w;
        this.h=h;
        this.s=s;
    }
    public void paint(Graphics g)
    {
        g.drawRect(x,y,w,h);
        g.setFont(new Font("黑体",Font.BOLD,20));
        g.drawString(s,x+10,y+30);
    }
}

class MYPANEL extends JPanel{
    MYLABEL mp=new MYLABEL(200,100,100,30,"test");
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        mp.paint(g);
    }
}