using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallThree
{
    class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeLibrary = new Dictionary<int, List<string>>(); 

        // Create
        public void AddBadge(ChallThree_BadgeContent stuff)
        {
            _badgeLibrary.Add(stuff.BadgeIDNumber, stuff.DoorNames);
        }

        // Read

        public Dictionary<int, List<string>> GetDirectory()
        {
            return _badgeLibrary;
        }

        // Update
        public void EditBadge(int badgeNum, List<string> stuff)
        {
            _badgeLibrary[badgeNum] = stuff;
        }
                      
    }
}
