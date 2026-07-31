import { useContext } from "react";
import { AuthContext } from "../context/AuthContext"; // Ajusta la ruta según tu carpeta

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth debe ser utilizado dentro de un AuthProvider");
    }
    return context;
};
