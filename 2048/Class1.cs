using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Game
    {
        public int[,] n = new int[6,6];
        public Random r = new Random();
        public bool die = false;
        public bool change = false;
        public int socer = 0;
       
        #region
        //向上 先判断为0
        public void up0()
        {
            change = false;
           
            for(int x = 1;x<=4;x++)
            {
                if(n[x,1]==0 && n[x,2] + n[x,3] + n[x,4] != 0)
                {
                    n[x, 1] = n[x, 2];
                    n[x, 2] = n[x, 3];
                    n[x, 3] = n[x, 4];
                    n[x, 4] = 0;
                    change = true;
                }
                else if(n[x, 2] == 0 && n[x, 3] + n[x, 4] != 0)
                {
                    n[x, 2] = n[x, 3];
                    n[x, 3] = n[x, 4];
                    n[x, 4] = 0;
                    change = true;
                }
                else if(n[x, 3] == 0 && n[x, 4]!=0)
                {
                    n[x, 3] = n[x, 4];
                    n[x, 4] = 0;
                }

            }
        }
        public void up()
        {
            change = false;
            up0();
            for(int x = 1;x <= 4; x++)
            {
                if(n[x, 1] == n[x, 2] && n[x, 1] + n[x, 2] != 0)
                {
                    if (n[x, 3] != n[x, 4])
                    {
                        n[x, 1] = n[x, 2] * 2;
                        n[x, 2] = n[x, 3];
                        n[x, 3] = n[x, 4];
                        n[x, 4] = 0;
                    }
                    else
                    {
                        n[x, 1] = n[x, 2] * 2;
                        n[x, 2] = n[x, 3] * 2;
                        n[x, 3] = 0;
                        n[x, 4] = 0;
                    }
                }
                else if(n[x,2]==n[x,3]&&n[x,2]+n[x,3]!=0)
                {
                    n[x, 2] = n[x, 3] * 2;
                    n[x, 3] = n[x, 4];
                    n[x, 4] = 0;
                }
                else if(n[x, 3] == n[x, 4] && n[x, 3] + n[x, 4] != 0)
                {
                    n[x, 3] = n[x, 4] * 2;
                    n[x, 4] = 0;
                }
            }
        }

        //向下 先判断0
        public void down0()
        {
            for(int x = 1;x<=4;x++)
            {
                if(n[x, 4] = 0 && n[x, 3] + n[x, 2] + n[x, 1] != 0)
                {
                    n[x, 4] = n[x, 3];
                    n[x, 3] = n[x, 2];
                    n[x, 2] = n[x, 1];
                    n[x, 1] = 0;
                }
                else if(n[x, 3] = 0 && n[x, 2] + n[x, 1] != 0)
                {
                    n[x, 3] = n[x, 2];
                    n[x, 2] = n[x, 1];
                    n[x, 1] = 0;
                }
                else if(n[x, 2] = 0 && n[x, 1] != 0)
                {
                    n[x, 2] = n[x, 1];
                    n[x, 1] = 0;
                }
            }
        }
        public void down()
        {
            down0();
            for(int x = 1; x <=4; x++)
            {
                if(n[x, 4] == n[x, 3] && n[x, 4] + n[x, 3] != 0)
                {
                    if(n[x, 2] != n[x, 1])
                    {
                        n[x, 4] = n[x, 3] * 2;
                        n[x, 3] = n[x, 2];
                        n[x, 2] = n[x, 1];
                        n[x, 1] = 0;
                    }
                    else
                    {
                        n[x, 4] = n[x, 3] * 2;
                        n[x, 3] = n[x, 2] * 2;
                        n[x, 2] = 0;
                        n[x, 1] = 0;
                    }
                }
                else if(n[x, 3] == n[x, 2] && n[x, 3] + n[x, 2] != 0)
                {
                    n[x, 3] = n[x, 2] * 2;
                    n[x, 2] = n[x, 1];
                    n[x, 1] = 0;
                }
                else if(n[x, 2] == n[x, 1] && n[x, 2] + n[x, 1] != 0)
                {
                    n[x, 2] = n[x, 1] * 2;
                    n[x, 1] = 0;
                }
            }
        }

        //向左 判断0
        public void left0()
        {
            for(int y = 1; y <= 4; y++)
            {
                if (n[1, y] == 0 && n[2, y] + n[3, y] + n[4, y] != 0)
                {
                    n[1, y] = n[2, y];
                    n[2, y] = n[3, y];
                    n[3, y] = n[4, y];
                    n[4, y] = 0;                 
                }
                else if (n[2, y] == 0 && n[2, y] + n[4, y] != 0)
                {
                    n[2, y] = n[3, y];
                    n[3, y] = n[4, y];
                    n[4, y] = 0;                  
                }
                else if (n[3, y] == 0 && n[4, y] != 0)
                {
                    n[3, y] = n[4, y];
                    n[4, y] = 0;
                }
            }
        }

        public void left()
        {
            left0();
            for(int y = 1;y <= 4; y++)
            {
                if (n[1, y] == n[2, y] && n[1, y] + n[2, y] != 0)
                {
                    if (n[3, y] != n[4, y])
                    {
                        n[1, y] = n[2, y] * 2;
                        n[2, y] = n[3, y];
                        n[3, y] = n[4, y];
                        n[4, y] = 0;
                    }
                    else
                    {
                        n[1, y] = n[2, y] * 2;
                        n[2, y] = n[3, y] * 2;
                        n[3, y] = 0;
                        n[4, y] = 0;
                    }
                }
                else if (n[2, y] == n[3, y] && n[2, y] + n[3, y] != 0)
                {
                    n[2, y] = n[3, y] * 2;
                    n[3, y] = n[4, y];
                    n[4, y] = 0;
                }
                else if (n[3, y] == n[4, y] && n[3, y] + n[4, y] != 0)
                {
                    n[3, y] = n[4, y] * 2;
                    n[4, y] = 0;
                }
            }
        }

        public void right0()
        {
            for (int y = 1; y <= 4; y++)
            {
                if (n[4, y] = 0 && n[3, y] + n[2, y] + n[1, y] != 0)
                {
                    n[4, y] = n[3, y];
                    n[3, y] = n[2, y];
                    n[2, y] = n[1, y];
                    n[1, y] = 0;
                }
                else if (n[3, y] = 0 && n[2, y] + n[1, y] != 0)
                {
                    n[3, y] = n[2, y];
                    n[2, y] = n[1, y];
                    n[1, y] = 0;
                }
                else if (n[2, y] = 0 && n[1, y] != 0)
                {
                    n[2, y] = n[1, y];
                    n[1, y] = 0;
                }
            }
        }

        public void right()
        {
            right0();
            for (int y = 1; y <= 4; y++)
            {
                if (n[4, y] == n[3, y] && n[4, y] + n[3, y] != 0)
                {
                    if (n[3, y] != n[1, y])
                    {
                        n[4, y] = n[3, y] * 2;
                        n[3, y] = n[3, y];
                        n[3, y] = n[1, y];
                        n[1, y] = 0;
                    }
                    else
                    {
                        n[4, y] = n[3, y] * 2;
                        n[3, y] = n[3, y] * 2;
                        n[3, y] = 0;
                        n[1, y] = 0;
                    }
                }
                else if (n[3, y] == n[3, y] && n[3, y] + n[3, y] != 0)
                {
                    n[3, y] = n[3, y] * 2;
                    n[3, y] = n[1, y];
                    n[1, y] = 0;
                }
                else if (n[3, y] == n[1, y] && n[3, y] + n[1, y] != 0)
                {
                    n[3, y] = n[1, y] * 2;
                    n[1, y] = 0;
                }
            }
        }
        
        #endregion//方向

        
    }
}
