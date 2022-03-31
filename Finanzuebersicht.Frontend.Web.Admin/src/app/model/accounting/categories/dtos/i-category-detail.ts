import { IAccountingEntry } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry';
import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';
import { ICategorySearchTerm } from 'src/app/model/accounting/category-search-terms/dtos/i-category-search-term';

export interface ICategoryDetail {
    id: string;
    accountingEntries: IAccountingEntry[];
    childCategories: ICategory[];
    superCategory: ICategory;
    categorySearchTerms: ICategorySearchTerm[];
    title: string;
    color: string;
}
