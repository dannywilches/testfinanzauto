export interface ProductList {
    productID: string;
    productName: string;
    category: string;
    supplier: string;
    quantityPerUnit: number;
    unitPrice: number;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: boolean;
}