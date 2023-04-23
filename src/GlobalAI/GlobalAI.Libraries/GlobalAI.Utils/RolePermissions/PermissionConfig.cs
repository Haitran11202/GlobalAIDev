using GlobalAI.Utils.RolePermissions.Constant;
using System.Collections.Generic;

namespace GlobalAI.Utils.RolePermissions
{
    /// <summary>
    /// Cấu hình các permission trong hệ thống
    /// </summary>
    public static class PermissionConfig
    {
        public static readonly Dictionary<string, PermissionContent> Configs = new()
        {
            #region product
            {
                Permissions.ProductAdminDashboard, new PermissionContent(){ Description = "Trang admin dashboard" }
            },
            {
                Permissions.ProductAdminProduct, new PermissionContent(){ Description = "Trang admin product" }
            },
            {
                Permissions.ProductAdminOrder, new PermissionContent(){ Description = "Trang admin đơn hàng" }
            },
            #endregion

        };
    }
}
