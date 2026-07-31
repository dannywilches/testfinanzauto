import { Navigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";

interface JwtPayload {
    exp: number;
}

const checkTokenValidity = (): boolean => {
    const token = localStorage.getItem("token");
    if (!token) return false;

    try {
        const decoded = jwtDecode<JwtPayload>(token);
        const currentTime = Date.now() / 1000;

        if (decoded.exp < currentTime) {
            localStorage.removeItem("token");
            return false;
        }
        return true; 
    } catch {
        localStorage.removeItem("token");
        return false; 
    }
};


export default function ProtectedRoute({ children }: { children: React.ReactNode }) {
    const isTokenValid = checkTokenValidity();

    if (!isTokenValid) {
        return <Navigate to="/" replace />;
    }

    return <>{children}</>;
}
