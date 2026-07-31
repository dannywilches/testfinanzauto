import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage";
import ProductsPage from "../pages/ProductsPage";
import ProductsCreatePage from "../pages/ProductsCreatePage";
import ProductsEditPage from "../pages/ProductsEditPage";
import ProtectedRoute from "./ProtectedRoute";
import MainLayout from "../layouts/MainLayout";

export default function AppRoutes() {

  return (
    <BrowserRouter>

      <Routes>

        <Route
          path="/"
          element={<LoginPage />}
        />

        <Route 
            element={
                <ProtectedRoute>
                    <MainLayout />
                </ProtectedRoute>
            }
        >
            <Route
                path="/products"
                element={
                    <ProtectedRoute>
                        <ProductsPage />
                    </ProtectedRoute>
                }
            />
            
            <Route
                path="/products/create"
                element={
                    <ProtectedRoute>
                        <ProductsCreatePage />
                    </ProtectedRoute>
                }
            />

            <Route
                path="/products/edit/:id"
                element={
                    <ProtectedRoute>
                        <ProductsEditPage />
                    </ProtectedRoute>
                }
            /> 
        </Route>

      </Routes>

    </BrowserRouter>
  );
}