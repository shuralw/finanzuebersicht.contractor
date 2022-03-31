using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions
{
    internal static class PermissionsCalculation
    {
        public static IDictionary<string, PermissionStatus> GetPermissionsWithStatus(PermissionStatus status)
        {
            return GetPermissionNames().ToDictionary(value => value, value => status);
        }

        public static IDictionary<string, PermissionStatus> Aggregate(IEnumerable<IDictionary<string, PermissionStatus>> permissionsList)
        {
            IDictionary<string, PermissionStatus> permissions = GetPermissionsWithStatus(PermissionStatus.NOT_SET);

            if (permissionsList != null && permissionsList.Any())
            {
                permissions.Keys.ToList().ForEach(key =>
                {
                    var accumulatedValue = permissionsList.Max(permissionsToAccumulate => permissionsToAccumulate[key]);
                    permissions[key] = accumulatedValue;
                });
            }

            return permissions;
        }

        public static IDictionary<string, PermissionStatus> ToStrictPermissions(IDictionary<string, PermissionStatus> permissions)
        {
            IDictionary<string, PermissionStatus> strictPermissions = GetPermissionsWithStatus(PermissionStatus.NOT_SET);

            permissions.ToList().ForEach(permissions =>
            {
                if (permissions.Value == PermissionStatus.NOT_SET)
                {
                    strictPermissions[permissions.Key] = PermissionStatus.DENY;
                }
                else
                {
                    strictPermissions[permissions.Key] = permissions.Value;
                }
            });

            return strictPermissions;
        }

        private static IEnumerable<string> GetPermissionNames()
        {
            return typeof(PermissionName)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Select(f => (string)f.GetValue(null));
        }
    }
}