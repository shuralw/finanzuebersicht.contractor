using Moq;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Tools.Pagination
{
    internal class PaginationContextTest
    {
        public static IPaginationContext SetupPaginationContextDefault()
        {
            Mock<IPaginationContext> paginationContext = new Mock<IPaginationContext>();
            paginationContext.Setup(context => context.Limit).Returns(10);
            paginationContext.Setup(context => context.Offset).Returns(0);
            paginationContext.Setup(context => context.Sort).Returns(new Dictionary<string, IPaginationSortItem>());
            paginationContext.Setup(context => context.Filter).Returns(new Dictionary<string, IPaginationFilterItem>());
            paginationContext.Setup(context => context.CustomSort).Returns(new Dictionary<string, IPaginationSortItem>());
            paginationContext.Setup(context => context.CustomFilter).Returns(new Dictionary<string, IPaginationFilterItem>());
            return paginationContext.Object;
        }
    }
}