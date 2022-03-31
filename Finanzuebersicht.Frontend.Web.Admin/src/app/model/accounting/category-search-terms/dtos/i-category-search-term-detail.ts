import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';

export interface ICategorySearchTermDetail {
    id: string;
    category: ICategory;
    term: string;
}
