#include<stdio.h>
#include<stdlib.h>
#include<conio.h>
#include<windows.h>
#include<time.h>

typedef struct 
{
	int a1,a2,b1,b2;
	int k;
	int type;
	int num_dot;
	int dot[2][2];
	int who;
}chessmessage;

int len,wid;

void gotoxy(int x,int y) 
{
	COORD a={x,y};
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),a);
}

int startscreen()
{
	int a,b;  
	printf("五子棋游戏\n");
	printf("请选择模式：\n");
	printf("A、玩家对战\n");
	printf("B、人机对战\n");
	printf("\n按ESC键退出游戏"); 
	gotoxy(12,1);
	while(1)
	{
		a=getch();
		gotoxy(0,5);
		if(a==65||a==66||a==97||a==98)
		{
			break;
		}
		if(a==27)
		{
			return 0;
		}
		else
		{
			printf("输入非选项，请重新输入!\n按任意键继续：");
			getch(); 
			system("cls");
			startscreen();
		}
	}
    if(a==65||a==97)
	{
	    printf("您选择了PvP    \n"); 
	    a=1;
	}
	if(a==66||a==98)
	{
	   	printf("您选择了PvE    \n"); 
		a=2 ;
	}
	printf("\n按任意键进行棋盘选择\n按空格键返回模式选择界面\n按Esc退出游戏\n"); 
	b=getch();
	if(b==32)
	{
		system("cls");
		startscreen();
	}
	if(b==27)
	{
		return 0;
	}
	return a;
 } 
 
void definechessboard()
{
	printf("请输入棋盘大小：\n");
	printf("长度：\n");
	printf("宽度：\n");
	printf("（长、宽在20至50之间）"); 
	gotoxy(6,1);
	scanf("%d",&len);
	gotoxy(6,2);
	scanf("%d",&wid);
	system("cls");
	while(len<20||len>50||wid<20||wid>50)
	{
		if((len<20||len>50)&&(wid<20||wid>50))
		{ 
			printf("长、宽均不在可生成范围！"); 
		}
		else if((len<20||len>50)&&(wid>=20&&wid<=50))
		{
			printf("长度不在可生成范围！");
	    }
		else if((len>=20&&len<=50)&&(wid<20||wid>50))
		{
			printf("宽度不在可生成范围！");
		}
		printf("\n请重新设置棋盘："); 
		getch();
		system("cls");
		definechessboard();
	}
}

void createchessboard(int len,int wid,int a)
{
	int i,p;
	printf("  ");
	for(i=1;i<=len;i++)
	{
		printf("%2d",i);
	}
	for(i=1;i<=wid;i++)
	{
		printf("\n%2d",i);
		for(p=0;p<len;p++)
		{
			printf(" .");
		}	
	}
	printf("\n\n先手玩家棋子为O，后手玩家棋子为X\n");
	if(a==1)
	{
	    printf("请二位玩家依次轮流输入坐标（如在第m列第n行下棋子，则输入m n）：");
	    printf("\n执O棋者坐标:");
	    printf("\n执X棋者坐标:"); 
	}
	if(a==2)
	{
		printf("请您选择是否先手（先手输入1，后手输入2）：");
		 
	}
}

int judge5(int numboard[][wid],int len,int wid)
{
	int i,j,num,k,m,n,p;
	int direct[4][2]={{0,1},{1,0},{1,1},{1,-1}};
	for(i=0;i<len;i++)
	{
		for(j=0;j<wid;j++)
		{
		    k=numboard[i][j];
		    if(k==0)continue;
		    for(p=0;p<4;p++)
		    {
		    	num=1;
		    	m=i+direct[p][0];
		    	n=j+direct[p][1];
		    	while(m>=0&&m<len&&n>=0&&n<wid&&numboard[m][n]==k)
		    	{
		    		num++;
		    		m+=direct[p][0];
		    		n+=direct[p][1];
				}
				if(num==5)
				{
					return k;
				}
			}
		}
	}
	return 0;
}

int checkinput(int *x,int *y,int numz[][wid],int k)
{
	if(*x>len||*x<1||*y>wid||*y<1)
	{
		gotoxy(2*wid+5,3);
		printf("您在棋盘外落子！请重新落子！"); 
		gotoxy(2*wid+5,4);
		printf("按任意键继续："); 
		getch();
		gotoxy(2*wid+5,3);printf("                                              ");
		gotoxy(2*wid+5,4);printf("                                              ");
		return 0;
	}
	if(numz[*x-1][*y-1]==1||numz[*x-1][*y-1]==2)
	{
		gotoxy(2*wid+5,3); 
		printf("已在(%d %d)落子！请重新落子！",*x,*y);
		gotoxy(2*wid+5,4);
		printf("按任意键继续："); 
		getch();
		gotoxy(2*wid+5,3);printf("                                              ");
		gotoxy(2*wid+5,4);printf("                                              ");
		return 0;
	}
	return 1;
}

int checkchess(int a,int b)
{
	if(a>0&&a<=len&&b>0&&b<=wid)
	return 1;
	else return 0;
}

chessmessage bianli(int who,int type,int numboard[][wid],chessmessage a)
{
	int i,j,k,m,n,w,num;
	int direct[4][2]={{0,1},{1,0},{1,1},{1,-1}};
	for(i=0;i<len;i++)
	{
		for(j=0;j<wid;j++)
		{
			k=numboard[i][j];
			if(k!=who)continue;
			for(w=0;w<4;w++)
			{
				num=1;
				m=i+direct[w][0];
				n=j+direct[w][1];
				while(m>=0&&m<len&&n>=0&&n<wid&&numboard[m][n]==k)
		    	{
		    		num++;
		    		m+=direct[w][0];
		    		n+=direct[w][1];
				}
				if(num==type)
				{
					a.k=w;a.type=type;a.who=who;
					a.a1=i+1;a.a2=j+1;
					a.b1=1+m-direct[w][0];a.b2=1+n-direct[w][1];
				    if(checkchess(i+1-direct[w][0],j+1-direct[w][1])==1)
					{
					    if(numboard[i-direct[w][0]][j-direct[w][1]]==0)
					    {
					    	a.num_dot++;
					    	a.dot[0][0]=i+1-direct[w][0];a.dot[0][1]=j+1-direct[w][1];
						}
						else
						{
							a.dot[0][0]=-1;a.dot[0][1]=-1;
						}
					}
					if(checkchess(1+m,1+n)==1)
					{
					    if(numboard[m][n]==0)
					    {
					    	a.num_dot++;
					    	a.dot[1][0]=1+m;a.dot[1][1]=1+n;
						}
						else
						{
							a.dot[1][0]=-1;a.dot[1][1]=-1;
						}
					}
					if(a.num_dot!=0)
			        return a;
				}
			}
		}
	}
	return a;
 } 
 
chessmessage judgeall(int numboard[][wid])
{
	int g,h;
	chessmessage a={0};
	for(g=4;g>=1;g--)
	{
		for(h=2;h>=1;h--)
		{
			a=bianli(h,g,numboard,a);
			if(a.num_dot!=0)
			return a;
		}
	}
	return a;
}

void AIchess(int numz[][wid],int p)
{
	int m,n,k;
	chessmessage a=judgeall(numz);
	if(a.num_dot==0)
	{
		do
		{
            k=rand();
		    m=k%len;n=k%wid;
		}while(numz[m][n]!=0);
		gotoxy(1+2*(m+1),n+2);
		numz[m][n]=2;
		if(p%2==0)printf("O");
	    else printf("X");
	    return;
	}
	if((a.dot[0][0]!=-1&&a.dot[1][0]==-1)||(a.dot[0][0]!=-1&&a.dot[1][0]!=-1))
	{
		gotoxy(1+2*a.dot[0][0],a.dot[0][1]+2);
		numz[a.dot[0][0]-1][a.dot[0][1]-1]=2;
	}
	else if(a.dot[0][0]==-1&&a.dot[1][0]!=-1)
	{
		gotoxy(1+2*a.dot[1][0],a.dot[1][1]+2);
		numz[a.dot[1][0]-1][a.dot[1][1]-1]=2;
	}
	if(p%2==0)printf("O");
	else printf("X");
}

void modePvE()
{
	int i,j,k,m,n,p;
	int numboard[len][wid];
	for(i=0;i<len;i++)
	{
		for(j=0;j<wid;j++)
		{
			numboard[i][j]=0;
		}
	}
	gotoxy(42,wid+5);
	k=getch();
	while(1)
	{
		if(k==49) 
	    {
	    	gotoxy(0,wid+5);
			printf("您选择了先手下棋，您的棋子为O！                        "); 
	    	break;
    	}
	    else if(k==50)
	    {
	    	gotoxy(0,wid+5);
	    	printf("您选择了后手下棋，您的棋子为X！                        "); 
	    	if(len%2==0)
	    	{
	    		gotoxy(len+1,((int)((wid+1)/2))+2);
			}
	    	else
	    	{
	    		gotoxy(len+2,((int)((wid+1)/2))+2);
			}
			numboard[((int)((len+1)/2))-1][((int)((wid+1)/2))-1]=2;
			printf("O"); 
	    	break;
    	}
	    else
    	{
    		gotoxy(2*wid+5,3);
    		printf("您输入了错误的选项！请重新输入！");
    		gotoxy(2*wid+5,4);
    		printf("按任意键继续！");
    		getch();
    		gotoxy(2*wid+5,3);printf("                                         ");
    		gotoxy(2*wid+5,4);printf("                                         ");
    		gotoxy(42,wid+5);
    		k=getch();
    	}
	}
	gotoxy(0,wid+6);
	printf("请输入你下一步棋的坐标（如在第m列第n行下棋子，则输入m n）：");
	while(judge5(numboard,len,wid)==0)
	{
		gotoxy(60,wid+6);
	    scanf("%d %d",&m,&n);
	    while(checkinput(&m,&n,numboard,k)==0)
		{
			gotoxy(60,wid+6);
			printf("                            ");
			gotoxy(60,wid+6);
			scanf("%d %d",&m,&n);
		}
		gotoxy(1+2*m,n+2);
		if(k%2==0)
		{
			putchar('X');
		}
		else
		{
			putchar('O');
		}
	    numboard[m-1][n-1]=1;
	    if(judge5(numboard,len,wid)==1)
	    {
	    	break;
		}
	    gotoxy(60,wid+6);
	    printf("                                ");
	    AIchess(numboard,k);
	    if(judge5(numboard,len,wid)==2)
        {
            break;
        }
	}
	system("cls");
	if(judge5(numboard,len,wid)==1)
	{
        printf("玩家胜利！\n");
	}
	else
	{
		printf("AI胜利！\n");
	}
}


void modePvP()
{
	int x,y,i,j,k=0,p=0,m;
	int numboard[len][wid];
	for(i=0;i<len;i++)
	{
		for(j=0;j<wid;j++)
		{
			numboard[i][j]=0;
		}
	}
	while(judge5(numboard,len,wid)==0)
	{
		k++;
		if(k%2==0)
			gotoxy(13,wid+7);
		else
			gotoxy(13,wid+6);
		scanf("%d %d",&x,&y);
	    while(checkinput(&x,&y,numboard,k)==0)
		{
			if(k%2==0)
			{
				gotoxy(13,wid+7);
				printf("              ");
				gotoxy(13,wid+7);
			}
			else
			{
				gotoxy(13,wid+6);
				printf("              ");
				gotoxy(13,wid+6);
			}
			scanf("%d %d",&x,&y);
		}
		if(k%2==0)
			numboard[x-1][y-1]=2;
		else
			numboard[x-1][y-1]=1;
		gotoxy(1+2*x,y+2);
		if(k%2==0)
		{
			putchar('X');
			gotoxy(13,wid+7);
		}
		else
		{
			putchar('O');
			gotoxy(13,wid+6);
		}
		printf("           ");
	}
	system("cls");
	if(judge5(numboard,len,wid)==1)
	{
		printf("执O者获胜！\n"); 
	}
	else
	{
		printf("执X者获胜！\n");
	}
	printf("\n按任意键退出游戏！\n");
	getch();
}

int main()
{
	system("cls");
	srand(time(NULL));
	int a=startscreen();
	if(a==0)
	{
	    system("cls"); 
		printf("游戏结束！");
		return 0;
	}
    system("cls"); 
	definechessboard();
	system("cls");
	gotoxy(0,2);
	createchessboard(len,wid,a);
	gotoxy(0,0);
	if(a==1)
	{
		printf("PvP模式：\n\n");
		modePvP(); 
	}
	else if(a==2)
	{
		printf("PvE模式：\n\n");
		modePvE(); 	
	}
	return 0;
}