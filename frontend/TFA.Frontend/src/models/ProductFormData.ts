export interface ProductFormData {
    productName: string;
    categoryID: string;
    supplierID: string;
    quantityPerUnit: number;
    unitPrice: number;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: boolean;
}