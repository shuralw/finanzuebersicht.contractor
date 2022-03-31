import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';

export interface ICategorySearchTermListItem {
    id: string;
    category: ICategory;
    term: string;
}
