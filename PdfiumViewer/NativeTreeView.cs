using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PdfiumViewer
{
    internal class NativeTreeView : TreeView
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                                string pszSubIdList);

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetWindowTheme(this.Handle, "explorer", null);
        }

        public TreeNode GetNodeByTag(object tag)
        {
            return GetNodeByTag(this.Nodes, tag);
        }

        public TreeNode GetNodeByTag(TreeNodeCollection nodes, object tag)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == tag)
                    return node;

                TreeNode result = GetNodeByTag(node.Nodes, tag);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
