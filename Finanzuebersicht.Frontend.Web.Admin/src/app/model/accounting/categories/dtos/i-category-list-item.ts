import { ICategory } from 'src/app/model/accounting/categories/dtos/i-category';

export interface ICategoryListItem {
    id: string;
    superCategory: ICategory;
    title: string;
    color: string;
    summe: number;
}
