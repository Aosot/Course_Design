package java_swing.package1;

import java.awt.*;

public abstract class BaseComponent {
    int x,y,w,h;
    String s;
    Color c;
    public BaseComponent(int x,int y,int w,int h,String s,Color c)
    {
        this.x=x;this.y=y;this.w=w;this.h=h;this.s=s;this.c=c;
    }
    public BaseComponent(int x,int y,String s,Color c)
    {
        this.x=x;this.y=y;this.s=s;this.c=c;
    }
    boolean judge(int mx,int my)
    {
        return mx>x&&mx<(x+w)&&my>y&&my<(y+h);
    }
    public abstract void paint(Graphics g);
}