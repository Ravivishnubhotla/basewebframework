/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.BaseDomain;

namespace Powerasp.Enterprise.Core.BaseManager.Domain
{
	/// <summary>
	///	系统角色
	/// </summary>
	[Serializable]
	public class SystemRole : SystemRoleBase
	{
	    public virtual string RoleIsSystemRoleString
	    {
	        get
	        {
                if (this.RoleIsSystemRole)
                    return "是";
                else
                    return "否";
	        }
	    }
	}
}
