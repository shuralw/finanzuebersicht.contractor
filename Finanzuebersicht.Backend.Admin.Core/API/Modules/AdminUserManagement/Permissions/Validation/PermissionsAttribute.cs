using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Finanzuebersicht.Backend.Admin.Core.API.Modules.AdminUserManagement.Permissions
{
    public sealed class PermissionsAttribute : ValidationAttribute
    {
        public PermissionsAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.GetType() != typeof(Dictionary<string, PermissionStatus>))
            {
                return false;
            }

            var permissions = value as IDictionary<string, PermissionStatus>;

            return this.IsPermissionsLengthValid(permissions) &&
                this.ArePermissionNamesValid(permissions) &&
                this.ArePermissionValuesValid(permissions);
        }

        private bool IsPermissionsLengthValid(IDictionary<string, PermissionStatus> permissions)
        {
            var permissionNames = this.GetPermissionNames();
            return permissions.Count == permissionNames.Count();
        }

        private bool ArePermissionNamesValid(IDictionary<string, PermissionStatus> permissions)
        {
            var permissionNames = this.GetPermissionNames();
            return permissionNames.All(permissionName =>
            {
                return permissions.ContainsKey(permissionName);
            });
        }

        private IEnumerable<string> GetPermissionNames()
        {
            return typeof(PermissionName)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Select(f => (string)f.GetValue(null));
        }

        private bool ArePermissionValuesValid(IDictionary<string, PermissionStatus> permissions)
        {
            return permissions.All(permissions =>
            {
                return Enum.IsDefined(typeof(PermissionStatus), permissions.Value);
            });
        }
    }
}