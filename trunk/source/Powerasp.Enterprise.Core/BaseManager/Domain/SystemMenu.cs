/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.BaseDomain;

namespace Powerasp.Enterprise.Core.BaseManager.Domain
{
	/// <summary>
	///	系统导航菜单
	/// </summary>
	[Serializable]
	public class SystemMenu : SystemMenuBase
	{
        public SystemMenu()
        {
        }

	    public SystemMenu(int _menu_id, string _menu_name, string _menu_url, string _menu_urltarget, bool _menu_iscategory)
	    {
	        this.MenuID = _menu_id;
	        this.MenuName = _menu_name;
	        this.MenuUrl = _menu_url;
	        this.MenuUrlTarget = _menu_urltarget;
	        this.MenuIsCategory = _menu_iscategory;
	    }


	}
}
