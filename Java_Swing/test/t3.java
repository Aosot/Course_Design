package java_swing.test;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class t3 extends JFrame{
    public t3()
    {
        setTitle("t3");
        setSize(600,400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        MYPANE mp=new MYPANE();
        add(mp);

        setVisible(true);
    }
    public static void main(String[]args)
    {
        new t3();
    }
}

class MYTF
{
    int x,y,w,h;
    String s="";
    public MYTF(int x,int y,int w,int h)
    {
        this.x=x;this.y=y;this.w=w;this.h=h;
    }
    public MYTF(int x,int y,int w,int h,String s)
    {
        this.x=x;this.y=y;this.w=w;this.h=h;this.s=s;
    }
    public void paint(Graphics g)
    {
        g.setColor(Color.WHITE);
        g.fillRect(x,y,w,h);
        g.setColor(Color.BLACK);
        g.drawRect(x,y,w,h);
        g.setFont(new Font("黑体",Font.BOLD,h-5));
        if(s!=null)g.drawString(s,x+5,y+h-5);
    }
    public boolean check(int mx,int my)
    {
        return mx>x&&mx<x+w&&my>y&&my<y+h;
    }
}

class MYPANE extends JPanel implements MouseListener,KeyListener{
    MYTF mtf=new MYTF(100,50,100,30,"");
    boolean f=false;
    public MYPANE()
    {
        addMouseListener(this);
        addKeyListener(this);
        setFocusable(true);
    }
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        mtf.paint(g);
    }
    @Override 
    public void mouseClicked(MouseEvent e){
        if(mtf.check(e.getX(),e.getY()))
        {
            f=true;
            setFocusable(true);
            requestFocusInWindow();
        }
        else f=false;
        repaint();
    }
    @Override
    public void keyTyped(KeyEvent e)
    {
        if(f)
        {
            char c=e.getKeyChar();
            if(c>='a'&&c<='z'||c>='A'&&c<='Z'||c>='0'&&c<='9')
            {
                mtf.s+=c;
                repaint();
            }
        }
    }
    @Override public void mousePressed(MouseEvent e){}
    @Override public void mouseReleased(MouseEvent e){}
    @Override public void mouseEntered(MouseEvent e){}
    @Override public void mouseExited(MouseEvent e){}
    @Override public void keyPressed(KeyEvent e){}
    @Override public void keyReleased(KeyEvent e){}
}