package java_swing.test;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class t1 extends JFrame{
    public t1()
    {
        setTitle("t1");
        setSize(600,400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        MYPNL pnl=new MYPNL();
        add(pnl);

        setVisible(true);
    }
    public static void main(String[] args)
    {
        new t1();
    }
}

class MYBT
{
    int x,y;
    int w,h;
    String s,t;
    Color c;
    public MYBT(int x,int y,int w,int h,String s,String t,Color c)
    {
        this.x=x;this.y=y;
        this.w=w;this.h=h;
        this.t=t;this.s=s;
        this.c=c;
    }
    public boolean judge(int mx,int my)
    {
        return mx>x&&mx<x+w&&my>y&&my<y+h;
    }
    public void paint(Graphics g){
        g.setColor(c);
        if(t.equals("Oval"))
            g.fillOval(x,y,w,h);
        else
            g.fillRect(x,y,w,h);
        g.drawString(s,x,y);
    }
}

class MYPNL extends JPanel
{
    MYBT btn1=new MYBT(100,100,150,50,"111","Rect",Color.LIGHT_GRAY);
    MYBT btn2=new MYBT(100,200,150,50,"222","Oval",Color.DARK_GRAY);

    public MYPNL(){
        addMouseListener(new MouseAdapter(){
            @Override
            public void mouseClicked(MouseEvent e)
            {
                int mx=e.getX();
                int my=e.getY();
                if(btn1.judge(mx,my))
                {
                    System.out.println("btn1 is pressed");
                }
                if(btn2.judge(mx,my))
                {
                    System.out.println("btn2 is pressed");
                }
            }
        });
    }

    @Override
    protected void paintComponent(Graphics g){
        super.paintComponent(g);
        btn1.paint(g);
        btn2.paint(g);
    }
}