import api from "./axios";

export const getProducts = async (page: number, pageSize: number, search: string) => {
    const response = await api.get("/products", {
        params: {
            page,
            pageSize,
            search
        }
    });
    return response.data;
};

export const getProductById = async (id:string) => {
    const response = await api.get(`/products/${id}`);
    return response.data;
};

export const createProduct = async (data: any) => {
    const response = await api.post("/products", data);
    return response.data;
};

export const updateProduct = async (id: string, data: any) => {
    const response = await api.put(
        `/products/${id}`,
        data
    );
    return response.data;
};

export const deleteProduct = async (id: string) => {
    const response = await api.delete(`/products/${id}`);
    return response.data;
}