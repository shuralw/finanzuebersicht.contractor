import { ICategoryDetail } from './i-category-detail';

export interface ICategoryUpdate {
    id: string;
    superCategoryId: string;
    title: string;
    color: string;
}

export abstract class CategoryUpdate {
    public static fromCategoryDetail(iCategoryDetail: ICategoryDetail): ICategoryUpdate {
        return {
            id: iCategoryDetail.id,
            superCategoryId: iCategoryDetail.superCategory?.id,
            title: iCategoryDetail.title,
            color: iCategoryDetail.color,
        };
    }
}
