using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.Web.UI.WebControls
{
    public class SuperWebTreeNode : TreeNode
    {
        private int maxDepth = 8;
        private int minDepth = 1;
        private int relateItems = 0;

        public int MaxDepth
        {
            get { return maxDepth; }
        }

        public int MinDepth
        {
            get { return minDepth; }
        }
        

        public int RelateItems
        {
            get { return relateItems; }
        }


        public SuperWebTreeNode(int minDepth, int maxDepth, int relateItems) : base()
        {
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
            this.relateItems = relateItems;
        }

        /// <summary>
        /// 是否显示添加子项（显示添加子项功能）
        /// </summary>
        public bool CanAddSubItem
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 是否显示编辑（显示编辑功能）
        /// </summary>
        public bool CanModify
        {
            get
            {
                return (this.Depth >= minDepth);
            }
        }

        /// <summary>
        /// 是否显示删除（显示删除功能）
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return (this.Depth >= minDepth);
            }
        }

        /// <summary>
        /// 是否显示向上移动（显示向上移动功能）
        /// </summary>
        public bool CanMoveUp
        {
            get
            {
                return (this.Depth >= minDepth);
            }
        }

        /// <summary>
        /// 是否显示向下移动（显示向下移动功能）
        /// </summary>
        public bool CanMoveDown
        {
            get
            {
                return (this.Depth >= minDepth);
            }
        }

        /// <summary>
        /// 是否显示子项排序（显示子项排序功能）
        /// </summary>
        public bool CanResortSub
        {
            get
            {
                return (this.ChildNodes.Count> 0);
            }
        }

        /// <summary>
        /// 是否允许添加子项
        /// </summary>
        public bool AllowAddSubItem
        {
            get
            {
                return this.CanAddSubItem && (this.Depth < maxDepth) ;
            }
        }

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool AllowModify
        {
            get
            {
                 return this.CanModify;
            }
        }

        /// <summary>
        /// 是否允许删除
        /// </summary>
        public bool AllowDelete
        {
            get
            {
                return this.CanDelete && (this.ChildNodes.Count == 0);
            }
        }

        /// <summary>
        /// 是否允许向上移动序位
        /// </summary>
        public bool AllowMoveUp
        {
            get
            {
                return this.CanMoveUp && this.Parent != null && !(this.Parent.ChildNodes[0] == this);
            }
        }

        /// <summary>
        /// 是否允许向下移动序位
        /// </summary>
        public bool AllowMoveDown
        {
            get
            {
                return this.CanMoveDown && this.Parent != null && !(this.Parent.ChildNodes[this.Parent.ChildNodes.Count - 1] == this);
            }
        }

        /// <summary>
        /// 是否允许子项排序（）
        /// </summary>
        public bool AllowResortSub
        {
            get
            {
                return this.CanResortSub;
            }
        }
    }
}
