
    export interface IProduct
    {
        id: string
        productName: string
        productDescription: string
        productPrice: number
        productImageUrl: string
        categoryId: string
        brandId: string
        createdOn: string
        createdBy: string
        lastModifiedOn: string
        lastModifiedBy: string
        isDeleted: boolean
    }

    export interface ICategory
    {
        categoryName: string
        categoryDescription: any
        categoryDisplayOrder: number
        createdOn: string
        createdBy: string
        lastModifiedOn: string
        lastModifiedBy: string
        isDeleted: boolean
        id: string
        domainEvents: any[]
    }

    export interface IBrand
    {
        name: string
        createdOn: string
        createdBy: string
        lastModifiedOn: string
        lastModifiedBy: string
        isDeleted: boolean
        id: string
        domainEvents: any[]
    }

