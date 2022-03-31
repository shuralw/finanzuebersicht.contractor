using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.UserManagement.EmailUsers;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Accounting.CategorySearchTerms
{
    public class CategorySearchTermTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("5ceb27e1-7e89-db9c-42ad-57d0172ddde6");
        public static readonly Guid IdDbDefault2 = Guid.Parse("0a115995-2c0d-0573-239e-a97484dace68");
        public static readonly Guid IdForCreate = Guid.Parse("26429a5a-f5fa-55ff-3aaf-2979e162a9c3");

        public static readonly Guid EmailUserIdDbDefault = EmailUserTestValues.IdDbDefault;

        public static readonly Guid? CategoryIdDbDefault = CategoryTestValues.IdDbDefault;
        public static readonly Guid? CategoryIdDbDefault2 = CategoryTestValues.IdDbDefault2;
        public static readonly Guid? CategoryIdForCreate = CategoryTestValues.IdDbDefault;
        public static readonly Guid? CategoryIdForUpdate = CategoryTestValues.IdDbDefault2;

        public static readonly string TermDbDefault = "TermDbDefault";
        public static readonly string TermDbDefault2 = "TermDbDefault2";
        public static readonly string TermForCreate = "TermForCreate";
        public static readonly string TermForUpdate = "TermForUpdate";
    }
}