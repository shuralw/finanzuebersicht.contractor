using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.UserManagement.EmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.Categories
{
    public class CategoryTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("fde946d0-2e26-9483-e143-51aa316e2a69");
        public static readonly Guid IdDbDefault2 = Guid.Parse("d7ceb6db-c29d-4d9d-1428-c13f795c9ef4");
        public static readonly Guid IdForCreate = Guid.Parse("90800ccd-9a46-4433-a733-1cc824c64b82");

        public static readonly Guid EmailUserIdDbDefault = EmailUserTestValues.IdDbDefault;

        public static readonly Guid? SuperCategoryIdDbDefault = CategoryTestValues.IdDbDefault;
        public static readonly Guid? SuperCategoryIdDbDefault2 = CategoryTestValues.IdDbDefault2;
        public static readonly Guid? SuperCategoryIdForCreate = CategoryTestValues.IdDbDefault;
        public static readonly Guid? SuperCategoryIdForUpdate = CategoryTestValues.IdDbDefault2;

        public static readonly string TitleDbDefault = "TitleDbDefault";
        public static readonly string TitleDbDefault2 = "TitleDbDefault2";
        public static readonly string TitleForCreate = "TitleForCreate";
        public static readonly string TitleForUpdate = "TitleForUpdate";

        public static readonly string ColorDbDefault = "ColorDbDefault";
        public static readonly string ColorDbDefault2 = "ColorDbDefault2";
        public static readonly string ColorForCreate = "ColorForCreate";
        public static readonly string ColorForUpdate = "ColorForUpdate";
    }
}