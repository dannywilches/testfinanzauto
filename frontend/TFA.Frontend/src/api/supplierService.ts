import api from "./axios";

export const getSuppliers = async () => {
    const response = await api.get("/suppliers");
    return response.data;
};
