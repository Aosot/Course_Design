package java_swing.package1;

import java.awt.*;

public class MyButton extends BaseComponent{
    boolean ip=false;
    public MyButton(int x,int y,int w,int h,String s,Color c)
    {
        super(x,y,w,h,s,c);
    }
    @Override
    public void paint(Graphics g)
    {
        if(ip)g.setColor(Color.GRAY);
        if(!ip)g.setColor(Color.WHITE);
        g.fillRect(x,y,w,h);
        g.setColor(Color.BLACK);
        g.drawRect(x,y,w,h);
        g.setColor(c);
        g.setFont(new Font("黑体",Font.BOLD,15));
        if(s!=null)g.drawString(s,x,y);
    }
}