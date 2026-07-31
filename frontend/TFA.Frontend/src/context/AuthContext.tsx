import { createContext, useState } from "react";

interface AuthContextType {
    token: string | null;
    login: (token: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType>(null!);

export default function AuthProvider ({ children }: { children: React.ReactNode}) {

    const [token, setToken] = useState(localStorage.getItem("token"));

    const login = (jwt: string) => {
        localStorage.setItem("token", jwt);
        setToken(jwt);
    };

    const logout = () => {
        localStorage.removeItem("token");
        setToken(null);
    };

    return (
        <AuthContext.Provider
            value={{
                token,
                login,
                logout
            }}
        >
            {children}
        </AuthContext.Provider>
    );
};
export { AuthContext }
// export const useAuth = () => useContext(AuthContext);