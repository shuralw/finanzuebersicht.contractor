import { ICategorySearchTermDetail } from './i-category-search-term-detail';

export interface ICategorySearchTermUpdate {
    id: string;
    categoryId: string;
    term: string;
}

export abstract class CategorySearchTermUpdate {
    public static fromCategorySearchTermDetail(iCategorySearchTermDetail: ICategorySearchTermDetail): ICategorySearchTermUpdate {
        return {
            id: iCategorySearchTermDetail.id,
            categoryId: iCategorySearchTermDetail.category?.id,
            term: iCategorySearchTermDetail.term,
        };
    }
}
