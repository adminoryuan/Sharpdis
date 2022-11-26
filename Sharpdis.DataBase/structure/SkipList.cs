using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class SkipNode
    {
        public int key;
        public string value;
        public SkipNode down, right;
        public SkipNode(int key, string v)
        {
            this.key = key;
            this.value = v==null?"":v;
        }

    }
    public class SkipList
    {

        private SkipNode head = new SkipNode(0, "");

        private SkipNode[] level;

        private int MaxLevel;

        /// <summary>
        /// 当前层数
        /// </summary>
        private int currLevel;

        /// <summary>
        /// 用来决定是否链接
        /// 
        /// </summary>
        Random random = new Random();

        public SkipNode Search(int key)
        {
            SkipNode temp = head;
            while (temp != null)
            {
                if (temp.key == key) return temp;

                if (temp.right == null || temp.right.key > key)
                {
                    temp = temp.down;
                }
                else
                {
                    temp = temp.right;
                }

            }
            return null;

        }
        public bool Update(SkipNode node)
        {
            SkipNode temp;
            if ((temp = Search(node.key)) != null)
            {
                temp.value = node.value;
                return true;
            }
            return false;
        }
        public void Delete(int key)
        {

            SkipNode team = head;
            while (team != null)
            {
                if (team.right == null)
                {//右侧没有了，说明这一层找到，没有只能下降
                    team = team.down;
                }
                else if (team.right.key == key)//找到节点，右侧即为待删除节点
                {
                    team.right = team.right.right;//删除右侧节点
                    team = team.down;//向下继续查找删除
                }
                else if (team.right.key > key)//右侧已经不可能了，向下
                {
                    team = team.down;
                }
                else
                { //节点还在右侧
                    team = team.right;
                }
            }

        }

        public int ZCount(int start, int end)
        {
            return ZRange(start, end).Length;
        }

        public int ZRank(string val)
        {
            int ranke = 0;

            SkipNode node = head;
            while (node.down != null) node = node.down;
            while (node != null && !node.value.Equals(val))
            {
                node = node.right;
                ranke++;
            }
            return node == null ? -1 : ranke;
        }
        public string[] ZRange(int start, int end)
        {
            if (end == -1) end = int.MaxValue;
            SkipNode temp = head;
            while (temp != null)
            {
                if (temp.key == start) break;

                if (temp.right == null || temp.right.key > start)
                {
                    if (temp.down == null)
                    {
                        temp = temp.right;
                        break;
                    }
                    temp = temp.down;
                }
                else
                {
                    temp = temp.right;
                }
            }
            while (temp.down != null) temp = temp.down;

            var list = new List<string>();

            while (temp != null && temp.key <= end)
            {
                list.Add(temp.value);
                temp = temp.right;
            }
            return list.ToArray();
        }
        public void Insert(SkipNode node)
        {
            int key = node.key;
            SkipNode findNode = Search(key);
            if (findNode != null)//如果存在这个key的节点
            {
                findNode.value = node.value;
                return;
            }
            Stack<SkipNode> stack = new Stack<SkipNode>();//存储向下的节点，这些节点可能在右侧插入节点
            SkipNode team = head;//查找待插入的节点   找到最底层的哪个节点。
            while (team != null)
            {//进行查找操作 
                if (team.right == null)//右侧没有了，只能下降
                {
                    stack.Push(team);//将曾经向下的节点记录一下
                    team = team.down;
                }
                else if (team.right.key > key)//需要下降去寻找
                {
                    stack.Push(team);//将曾经向下的节点记录一下
                    team = team.down;
                }
                else //向右
                {
                    team = team.right;
                }
            }
            int level = 1;//当前层数，从第一层添加(第一层必须添加，先添加再判断)
            SkipNode downNode = null;//保持前驱节点(即down的指向，初始为null)
            while (stack.Count != 0)
            {
                //在该层插入node
                team = stack.Pop();//抛出待插入的左侧节点
                SkipNode nodeTeam = new SkipNode(node.key, node.value);//节点需要重新创建
                nodeTeam.down = downNode;//处理竖方向
                downNode = nodeTeam;//标记新的节点下次使用
                if (team.right == null)
                {//右侧为null 说明插入在末尾
                    team.right = nodeTeam;
                }
                //水平方向处理
                else
                {//右侧还有节点，插入在两者之间
                    nodeTeam.right = team.right;
                    team.right = nodeTeam;
                }
                //考虑是否需要向上
                if (level > MaxLevel)//已经到达最高级的节点啦
                    break;
                double num = random.Next();//[0-1]随机数
                if (num > 0.5)//运气不好结束
                    break;
                level++;
                if (level > currLevel)//比当前最大高度要高但是依然在允许范围内 需要改变head节点
                {
                    currLevel = level;
                    //需要创建一个新的节点
                    SkipNode highHeadNode = new SkipNode(MaxLevel, null);
                    highHeadNode.down = head;
                    head = highHeadNode;//改变head
                    stack.Push(head);//下次抛出head
                }
            }


        }
    }
}
    



