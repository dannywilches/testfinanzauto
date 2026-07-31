import { useNavigate } from "react-router-dom";
import ProductForm from "../components/ProductForm";
import { Card, Container } from "react-bootstrap";
import { createProduct } from "../api/productService";

export default function ProductsCreatePage() {
    const navigate = useNavigate();

    const handleCreate = async (data: any) => {
        await createProduct(data);

        navigate("/products");
    }

    return (
        <Container className="mt-4">
            <Card className="shadow border-0 rounded-4">
                <Card.Header>
                    <h5 className="fw-bold">Crear Producto</h5>
                </Card.Header>
                <Card.Body>
                    <ProductForm 
                        onSubmit={handleCreate}
                        buttonText="Crear Producto"
                    />
                </Card.Body>
            </Card>
        </Container>
    );
}