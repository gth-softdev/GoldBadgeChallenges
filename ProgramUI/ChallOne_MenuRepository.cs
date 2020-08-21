using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallOne
{
    public class MenuRepository
    {
        private List<ChallOne_MenuContent> _menuLibrary = new List<ChallOne_MenuContent>();

        // Create
        public void AddMenuItemSet(ChallOne_MenuContent content)
        {
            _menuLibrary.Add(content);
        }

        // Read

        public List<ChallOne_MenuContent> GetDirectory()
        {
            return _menuLibrary;
        }

        // Update


        // Delete

        public bool DeleteMenuItemSet(ChallOne_MenuContent content)
        {
            return _menuLibrary.Remove(content);
        }

    }
}
