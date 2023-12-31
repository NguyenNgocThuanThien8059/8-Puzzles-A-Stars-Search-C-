﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_A_Star_Search
{
    internal class A_Stars_Search
    {
        public A_Stars_Search() 
        {

        }
        public List<Node> AStarSearch(Node root)
        {
            //Tạo List đường tới goal
            List<Node> PathToSolution = new List<Node>();
            //Tạo List node hàng đợi duyệt
            List<Node> OpenList = new List<Node>();
            //Tạo List node đã duyệt
            List<Node> ClosedList = new List<Node>();
            //Thêm node đầu tiên vào hàng đợi
            OpenList.Add(root);
            bool GoalFound = false;
            //Khi vẫn còn node trong hàng đợi duyệt và chưa tìm ra trạng thái cần tìm
            while (OpenList.Count > 0 && !GoalFound)
            {
                //Lấy node đầu tiên trong hàng đợi thêm vào List node đã duyệt
                Node CurrentNode = OpenList[0];
                ClosedList.Add(CurrentNode);
                //Xóa node đầu tiên trong hàng đợi
                OpenList.RemoveAt(0);
                //Bắt đầu duyệt qua node đã xóa
                CurrentNode.ExpandNode();
                //Kiểm tra từng đứa con của node
                for (int i = 0; i < CurrentNode.Children.Count; i++)
                {
                    Node CurrentChild = CurrentNode.Children[i];
                    //Nếu có đứa con có trùng trạng thái puzzle với trạng thái cần tìm
                    if (CurrentChild.GoalState())
                    {
                        GoalFound = true;
                        PathTrace(PathToSolution, CurrentChild);
                        Console.WriteLine("- Number of Moves:" + CurrentChild.g);
                    }
                    //Nếu trong OpenList và ClosedList không có node con trùng với node hiện đang xét thì thêm vào
                    if (!Contains(OpenList, CurrentChild) && !Contains(ClosedList, CurrentChild))
                    {
                        OpenList.Add(CurrentChild);
                    }
                }
                CheckShortRoute(OpenList);
            }

            return PathToSolution;
        }
        public void CheckShortRoute(List<Node> list)
        {
            int Minfx = list[0].g + list[0].h;
            for(int i = 1; i < list.Count; i++)
            {
                if(list[i].g + list[i].h <= Minfx)
                {
                    Node Copied = list[i];
                    list.Remove(list[i]);
                    list.Insert(0, Copied);
                    Minfx = Copied.g + Copied.h;
                }
            }
        }
        //Tìm đường đi
        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Finding Path....");
            Node Current = n;
            path.Add(Current);
            while (Current.Parent != null)
            {
                Current = Current.Parent;
                path.Add(Current);
            }
        }
        //Kiểm tra trùng lặp
        public static bool Contains(List<Node> list, Node c)
        {
            bool contains = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.Puzzle))
                {
                    contains = true;
                }
            }
            return contains;
        }
    }
}
