package java_swing.package1;

import java.awt.*;

public class MyLabel extends BaseComponent{
    public MyLabel(int x,int y,String s,Color c)
    {
        super(x,y,s,c);
    }
    @Override
    public void paint(Graphics g)
    {
        g.setFont(new Font("等线",Font.BOLD,20));
        g.setColor(c);
        g.drawString(s,x,y);
    }
}