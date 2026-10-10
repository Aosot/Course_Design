package java_swing.package1;

import java.util.Date;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class MyPanel extends JPanel implements MouseListener,KeyListener{
    boolean flag=false;
    MyButton bt=new MyButton(250,275,100,50,"输入完成请点击",Color.BLACK);
    MyTextField tf=new MyTextField(100,100,400,30,"",Color.BLACK);
    MyLabel lb=new MyLabel(10,50,"请输入您的名字：",Color.BLACK);
    MyLabel lb1=new MyLabel(100,200,"",Color.RED);

    public MyPanel(){
        setFocusable(true);
        addMouseListener(this);
        addKeyListener(this);
    }

    public void mouseClicked(MouseEvent e)
    {
        int mx=e.getX();
        int my=e.getY();
        if(bt.judge(mx,my)){
            Date date=new Date();
            System.out.println(date+"  用户"+tf.s+"登录成功");
            lb1.s="欢迎您："+tf.s;
            repaint();
        }
        if(tf.judge(mx,my))
        {
            flag=true;
        }
        else flag=false;
    }
    public void keyTyped(KeyEvent e)
    {
        if(flag)
        {
            tf.s+=e.getKeyChar();
            repaint();
        }
    }

    @Override public void mousePressed(MouseEvent e){
        int mx=e.getX();
        int my=e.getY();
        if(bt.judge(mx,my)){
            bt.ip=true;
            repaint();
        }
    }
    @Override public void mouseReleased(MouseEvent e){
        int mx=e.getX();
        int my=e.getY();
        if(bt.judge(mx,my)){
            bt.ip=false;
            repaint();
        }
    }
    @Override public void mouseEntered(MouseEvent e){}
    @Override public void mouseExited(MouseEvent e){}
    @Override public void keyPressed(KeyEvent e){}
    @Override public void keyReleased(KeyEvent e){}

    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        bt.paint(g);
        tf.paint(g);
        lb.paint(g);
        lb1.paint(g);
    }
}
