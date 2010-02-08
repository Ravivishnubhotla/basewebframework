using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAblum.Web.Codes
{
    [Serializable]
    public class NavMenu
    {
        private string id;
        private string name;
        private string target;
        private string navUrl;
        private NavMenu parentMenu;

        private List<NavMenu> subMenus = new List<NavMenu>();

        public List<NavMenu> SubMenus
        {
            get { return subMenus; }
            set { subMenus = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Target
        {
            get { return target; }
            set { target = value; }
        }

        public string NavUrl
        {
            get { return navUrl; }
            set { navUrl = value; }
        }

        public NavMenu AddSubMenu(string _id, string _name, string _url, string _target)
        {
            NavMenu subMenu = new NavMenu();
            subMenu.Id = _id;
            subMenu.Name = _name;
            subMenu.NavUrl = _url;
            subMenu.Target = _target;
            return AddSubMenu(subMenu);
        }

        public NavMenu ParentMenu
        {
            get { return parentMenu; }
            set { parentMenu = value; }
        }

        public NavMenu AddSubMenu(NavMenu subMenu)
        {
            subMenu.ParentMenu = this;
            subMenus.Add(subMenu);
            return subMenu;
        }
    }
}
