using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1x1_Trainer
{
    abstract class BaseMenu
    {
        public BaseMenu()
        {
            Console.Clear();
            DisplayMenu();
        }
        public abstract void DisplayMenu();

    }
}
