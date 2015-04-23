using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCMS.Models;

namespace Testing
{
    class Program
    {



        static void ShowBranch(LinkedList<MenuButton> Branch)
        {
            var node = Branch.First;
            var a = node.Next;


        }
        public static List<MenuButton> MenuButtons = new List<MenuButton>()
        {
            new MenuButton(){Id = 1,Level = 0,IsRootButton = true,Name = "Głowny",ParentId = 0},
            new MenuButton(){Id = 2,Level = 1,IsRootButton = false,Name = "G1",ParentId = 1},
            new MenuButton(){Id = 3,Level = 1,IsRootButton = false,Name = "G2",ParentId = 1},
            new MenuButton(){Id = 4,Level = 1,IsRootButton = false,Name = "G3",ParentId = 1},
            new MenuButton(){Id = 5,Level = 2,IsRootButton = false,Name = "G2.1",ParentId = 3},
            new MenuButton(){Id = 6,Level = 3,IsRootButton = false,Name = "G2.1.1",ParentId = 5},
        };
        static void Main(string[] args)
        {
            var rootButton = MenuButtons[0];
            int level = 1;

            Stack<MenuButton> allbuttons = new Stack<MenuButton>();
            allbuttons.Push(rootButton);

            while (allbuttons.Count > 0)
            {
                var button = allbuttons.Pop();
                level--;
               Console.WriteLine(button.Name +"  "+ button.Level);
                var childrenNodes = MenuButtons.Where(x => x.ParentId == button.Id);
                if (childrenNodes.Any())
                {

                    level++;
                    foreach (var node in childrenNodes)
                    {

                        allbuttons.Push(node);
                        
                    }
                }
            }
            Console.ReadKey();





        }
    }
}
