using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallThree
{
    class ChallThree_BadgeContent
    {
        public ChallThree_BadgeContent() { }

        public ChallThree_BadgeContent(int badgeIDNumber, List<string> doorNames)
        {
            BadgeIDNumber = badgeIDNumber;
            DoorNames = doorNames;
        }
        public int BadgeIDNumber { get; set; }
        public List<string> DoorNames { get; set; }

    }
}
