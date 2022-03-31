namespace Finanzuebersicht.Backend.Admin.Core.Contract.Contexts
{
    public interface IPaginationSortItem
    {
        string PropertyName { get; set; }

        string PropertyQuery { get; set; }

        SortOrder OrderBy { get; set; }
    }
}