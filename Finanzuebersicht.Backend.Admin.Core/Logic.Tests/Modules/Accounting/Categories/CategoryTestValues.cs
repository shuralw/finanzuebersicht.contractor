using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories
{
    public class CategoryTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("fde946d0-2e26-9483-e143-51aa316e2a69");
        public static readonly Guid IdDefault2 = Guid.Parse("d7ceb6db-c29d-4d9d-1428-c13f795c9ef4");
        public static readonly Guid IdForCreate = Guid.Parse("90800ccd-9a46-4433-a733-1cc824c64b82");

        public static readonly Guid? SuperCategoryIdDefault = CategoryTestValues.IdDefault;
        public static readonly Guid? SuperCategoryIdDefault2 = CategoryTestValues.IdDefault2;
        public static readonly Guid? SuperCategoryIdForCreate = CategoryTestValues.IdDefault;
        public static readonly Guid? SuperCategoryIdForUpdate = CategoryTestValues.IdDefault2;

        public static readonly string TitleDefault = "TitleDefault";
        public static readonly string TitleDefault2 = "TitleDefault2";
        public static readonly string TitleForCreate = "TitleForCreate";
        public static readonly string TitleForUpdate = "TitleForUpdate";

        public static readonly string ColorDefault = "ColorDefault";
        public static readonly string ColorDefault2 = "ColorDefault2";
        public static readonly string ColorForCreate = "ColorForCreate";
        public static readonly string ColorForUpdate = "ColorForUpdate";
    }
}