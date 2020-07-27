 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    [Serializable]
    class Games
    {
        public int[,] n = new int[5, 5];                     //定义一个数组
        public Random r = new Random();                      //随机数
        public bool over = false;                            //判断是否死亡
        public bool change = false;                          //判断该方块是否发生变化
        public int grade = 0;                                //记录得分
        private int zero = 16;                                //方块值为0的个数，默认为16个
        public int max = 0;                                  // 记录最高分数
        
        /// <summary>
        /// 重新开始
        /// </summary>
        public void Again()
        {
            //重置方块的值
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4 ; y++)
                    n[x, y] = 0;

            zero = 16;
            over = false;
            if (grade > max)
                max = grade;
            grade = 0;          
            AddNum();
            AddNum();            
        }
        /// <summary>
        /// 随机给值为0的方块随机赋值2或4
        /// </summary>
        public void AddNum()
        {
            int x = r.Next(0, 4);
            int y = r.Next(0, 4);
            if (n[x, y] == 0)
            {
                n[x, y] = 2 * r.Next(1, 3);
                zero--;
                GameOver();
            }
            else AddNum();
        }

        /// <summary>
        /// 计算值为0的方块的个数
        /// </summary>
        public void GetZero()
        {
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (n[i, j] == 0)
                    {
                        num++;
                    }
                }
            }
            zero = num;
        }


        /// <summary>
        /// 判断该局是否结束
        /// </summary>
        /// <returns></returns>
        public bool GameOver()
        {
            int b = 0;
            if(zero==0)
            {
                n[0, 4] = n[1, 4] = n[2, 4] = n[3, 4] = n[4, 4] = n[4, 1] = n[4, 2] = n[4, 3] = 0;
                for (int i = 0;i<4;i++)
                {
                    for(int j = 0;j<4;j++)
                    {
                        if (n[i, j] != n[i, j + 1] && n[i, j] != n[i + 1, j])
                        {
                            b += 1;
                        }
                        else
                        {
                            b += 0;
                        }                           
                    }
                }

            }
            if(b==16)
            {
                over = true;
            }
            else
            {
                over = false;
            }
            return over;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int Max()
        {
            if(grade>max)
            {
                return grade;
            }
            else
            {
                return max;
            }
        }

        
        #region
        //向左 先判断为0
        public void Left0()
        {
            for (int x = 0; x < 4; x++)
            {
                if (n[x, 0] == 0 && n[x, 1] + n[x, 2] + n[x, 3] != 0)
                {
                    n[x, 0] = n[x, 1];
                    n[x, 1] = n[x, 2];
                    n[x, 2] = n[x, 3];
                    n[x, 3] = 0;
                    change = true;
                    Left0();
                    
                }
                else if (n[x, 1] == 0 && n[x, 2] + n[x, 3] != 0)
                {
                    n[x, 1] = n[x, 2];
                    n[x, 2] = n[x, 3];
                    n[x, 3] = 0;
                    change = true;
                    Left0();
                }
                else if (n[x, 2] == 0 && n[x, 3] != 0)
                {
                    n[x, 2] = n[x, 3];
                    n[x, 3] = 0;
                    change = true;
                }
            }
        }
        public void Left()
        {
            change = false;
            Left0();
            for (int x = 0; x < 4; x++)
            {
                if (n[x, 0] == n[x, 1] && n[x, 0] + n[x, 1] != 0)
                {
                    if (n[x, 2] != n[x, 3])
                    {
                        n[x, 0] = n[x, 1] * 2;
                        n[x, 1] = n[x, 2];
                        n[x, 2] = n[x, 3];
                        n[x, 3] = 0;
                        grade += n[x, 0];                    
                    }
                    else
                    {
                        n[x, 0] = n[x, 1] * 2;
                        n[x, 1] = n[x, 2] * 2;
                        n[x, 2] = 0;
                        n[x, 3] = 0;
                        grade += n[x, 0];
                        grade += n[x, 1];
                    }
                    change = true;
                }
                else if (n[x, 1] == n[x, 2] && n[x, 1] + n[x, 2] != 0)
                {
                    n[x, 1] = n[x, 2] * 2;
                    n[x, 2] = n[x, 3];
                    n[x, 3] = 0;
                    grade += n[x, 1];
                    change = true;
                }
                else if (n[x, 2] == n[x, 3] && n[x, 2] + n[x, 3] != 0)
                {
                    n[x, 2] = n[x, 3] * 2;
                    n[x, 3] = 0;
                    grade += n[x, 2];
                    change = true;
                }
            }
            GetZero();
        }

          //向右 先判断0
        public void Right0()
        {
            for (int x = 0; x < 4; x++)
            {
                if (n[x, 3] == 0 && n[x, 2] + n[x, 1] + n[x, 0] != 0)
                {
                    n[x, 3] = n[x, 2];
                    n[x, 2] = n[x, 1];
                    n[x, 1] = n[x, 0];
                    n[x, 0] = 0;
                    change = true;
                    Right0();
                }
                else if (n[x, 2] == 0 && n[x, 1] + n[x, 0] != 0)
                {
                    n[x, 2] = n[x, 1];
                    n[x, 1] = n[x, 0];
                    n[x, 0] = 0;
                    change = true;
                    Right0();
                }
                else if (n[x, 1] == 0 && n[x, 0] != 0)
                {
                    n[x, 1] = n[x, 0];
                    n[x, 0] = 0;
                    change = true;
                }
            }
        }
        public void Right()
        {
            change = false;
            Right0();
            for (int x = 0; x < 4; x++)
            {
                if (n[x, 3] == n[x, 2] && n[x, 3] + n[x, 2] != 0)
                {
                    if (n[x, 1] != n[x, 0])
                    {
                        n[x, 3] = n[x, 2] * 2;
                        n[x, 2] = n[x, 1];
                        n[x, 1] = n[x, 0];
                        n[x, 0] = 0;
                        grade += n[x, 3];
                    }
                    else
                    {
                        n[x, 3] = n[x, 2] * 2;
                        n[x, 2] = n[x, 1] * 2;
                        n[x, 1] = 0;
                        n[x, 0] = 0;
                        grade += n[x, 3];
                        grade += n[x, 2];
                    }
                    change = true;
                }
                else if (n[x, 2] == n[x, 1] && n[x, 2] + n[x, 1] != 0)
                {
                    n[x, 2] = n[x, 1] * 2;
                    n[x, 1] = n[x, 0];
                    n[x, 0] = 0;
                    grade += n[x, 2];
                    change = true;
                }
                else if (n[x, 1] == n[x, 0] && n[x, 1] + n[x, 0] != 0)
                {
                    n[x, 1] = n[x, 0] * 2;
                    n[x, 0] = 0;
                    grade += n[x, 1];
                    change = true;
                }
            }
            GetZero();
        }

        //向上 判断0
        public void Up0()
        {
            for (int y = 0; y < 4; y++)
            {
                if (n[0, y] == 0 && n[1, y] + n[2, y] + n[3, y] != 0)
                {
                    n[0, y] = n[1, y];
                    n[1, y] = n[2, y];
                    n[2, y] = n[3, y];
                    n[3, y] = 0;
                    change = true;
                    Up0();
                }
                else if (n[1, y] == 0 && n[2, y] + n[3, y] != 0)
                {
                    n[1, y] = n[2, y];
                    n[2, y] = n[3, y];
                    n[3, y] = 0;
                    change = true;
                    Up0();
                }
                else if (n[2, y] == 0 && n[3, y] != 0)
                {
                    n[2, y] = n[3, y];
                    n[3, y] = 0;
                    change = true;
                }
            }
        }

        public void Up()
        {
            change = false;
            Up0();
            for (int y = 0; y < 4; y++)
            {
                if (n[0, y] == n[1, y] && n[0, y] + n[1, y] != 0)
                {
                    if (n[2, y] != n[3, y])
                    {
                        n[0, y] = n[1, y] * 2;
                        n[1, y] = n[2, y];
                        n[2, y] = n[3, y];
                        n[3, y] = 0;
                        grade += n[0, y];
                    }
                    else
                    {
                        n[0, y] = n[1, y] * 2;
                        n[1, y] = n[2, y] * 2;
                        n[2, y] = 0;
                        n[3, y] = 0;
                        grade += n[0, y];
                        grade += n[1, y];
                    }
                    change = true;
                }
                else if (n[1, y] == n[2, y] && n[1, y] + n[2, y] != 0)
                {
                    n[1, y] = n[2, y] * 2;
                    n[2, y] = n[3, y];
                    n[3, y] = 0;
                    grade += n[1, y];
                    change = true;
                }
                else if (n[2, y] == n[3, y] && n[2, y] + n[3, y] != 0)
                {
                    n[2, y] = n[3, y] * 2;
                    n[3, y] = 0;
                    grade += n[2, y];
                    change = true;
                }
            }
            GetZero();
        }

        //向下
        public void Down0()
        {             
            for (int y = 0; y < 4; y++)
            {
                if (n[3, y] == 0 && n[2, y] + n[1, y] + n[0, y] != 0)
                {
                    n[3, y] = n[2, y];
                    n[2, y] = n[1, y];
                    n[1, y] = n[0, y];
                    n[0, y] = 0;
                    change = true;
                    Down0();
                }
                else if (n[2, y] == 0 && n[1, y] + n[0, y] != 0)
                {
                    n[2, y] = n[1, y];
                    n[1, y] = n[0, y];
                    n[0, y] = 0;
                    change = true;
                    Down0();
                }
                else if (n[1, y] == 0 && n[0, y] != 0)
                {
                    n[1, y] = n[0, y];
                    n[0, y] = 0;
                    change = true;
                }
            }
        }

        public void Down()
        {
            change = false;
            Down0();
            for (int y = 0; y < 4; y++)
            {
                if (n[3, y] == n[2, y] && n[3, y] + n[2, y] != 0)
                {
                    if (n[1, y] != n[0, y])
                    {
                        n[3, y] = n[2, y] * 2;
                        n[2, y] = n[1, y];
                        n[1, y] = n[0, y];
                        n[0, y] = 0;
                        grade += n[3, y];
                    }
                    else
                    {
                        n[3, y] = n[2, y] * 2;
                        n[2, y] = n[1, y] * 2;
                        n[1, y] = 0;
                        n[0, y] = 0;
                        grade += n[3, y];
                        grade += n[2, y];
                    }
                    change = true;
              
                }
                else if (n[2, y] == n[1, y] && n[2, y] + n[1, y] != 0)
                {
                    n[2, y] = n[1, y] * 2;
                    n[1, y] = n[0, y];
                    n[0, y] = 0;
                    grade += n[2, y];
                    change = true;
                 }
                 else if (n[1, y] == n[0, y] && n[1, y] + n[0, y] != 0)
                 {
                    n[1, y] = n[0, y] * 2;
                    n[0, y] = 0;
                    grade += n[1, y];
                    change = true;
                 }
            }
            GetZero();  
        }

          #endregion//方向
    }
}

