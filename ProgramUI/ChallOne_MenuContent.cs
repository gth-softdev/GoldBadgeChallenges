using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallOne
{

    public class ChallOne_MenuContent
    {
        public ChallOne_MenuContent() { }

        public ChallOne_MenuContent(int itemNumber, string itemName, string itemDesc, List<string> itemIngredients, decimal itemPrice)
        {
            MenuItemNumber = itemNumber;
            MenuItemName = itemName;
            MenuItemDesc = itemDesc;
            MenuItemIngredients = itemIngredients;
            MenuItemPrice = itemPrice;
        }
        public int MenuItemNumber { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDesc { get; set; }
        public List<string> MenuItemIngredients { get; set; }
        public decimal MenuItemPrice { get; set; }



    }
}
