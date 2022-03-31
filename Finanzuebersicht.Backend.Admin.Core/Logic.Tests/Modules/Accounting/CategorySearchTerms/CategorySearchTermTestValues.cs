using Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.Categories;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.Accounting.CategorySearchTerms
{
    public class CategorySearchTermTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("5ceb27e1-7e89-db9c-42ad-57d0172ddde6");
        public static readonly Guid IdDefault2 = Guid.Parse("0a115995-2c0d-0573-239e-a97484dace68");
        public static readonly Guid IdForCreate = Guid.Parse("26429a5a-f5fa-55ff-3aaf-2979e162a9c3");

        public static readonly Guid? CategoryIdDefault = CategoryTestValues.IdDefault;
        public static readonly Guid? CategoryIdDefault2 = CategoryTestValues.IdDefault2;
        public static readonly Guid? CategoryIdForCreate = CategoryTestValues.IdDefault;
        public static readonly Guid? CategoryIdForUpdate = CategoryTestValues.IdDefault2;

        public static readonly string TermDefault = "TermDefault";
        public static readonly string TermDefault2 = "TermDefault2";
        public static readonly string TermForCreate = "TermForCreate";
        public static readonly string TermForUpdate = "TermForUpdate";
    }
}