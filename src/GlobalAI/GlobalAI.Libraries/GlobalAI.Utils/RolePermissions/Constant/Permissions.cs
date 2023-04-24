using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.RolePermissions.Constant
{
    public static class Permissions
    {
        //các loại permission
        private const string Menu = "menu_";
        private const string Tab = "tab_";
        private const string Page = "page_";
        private const string Table = "table_";
        private const string Form = "form_";
        private const string ButtonAction = "btn_action_";

        #region product
        private const string ProductModule = "product.";
        public const string ProductAdminDashboard = ProductModule + Page + "admin_dashboard";
        public const string ProductAdminProduct = ProductModule + Page + "admin_product";
        public const string ProductAdminOrder = ProductModule + Page + "admin_order";
        #endregion

    }
}
