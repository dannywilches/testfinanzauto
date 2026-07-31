import ProductForm from "../components/ProductForm";
import { Container, Card} from "react-bootstrap";
import { getProductById, updateProduct } from "../api/productService";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";

export default function ProductsEditPage() {
    
    const { id } = useParams();

    const navigate = useNavigate();

    const[product, setProduct] = useState<any>(null);

    useEffect(() => {
        loadProduct();
    }, []);

    const loadProduct = async () => {
        const data = await getProductById(id);
        setProduct(data);
        console.log(data);
    };

    const handleUpdate = async (data: any) => {
        await updateProduct(id, data);

        navigate("/products");
    };

    if (!product) {
        return <p>Cargando...</p>
    }

    return (
        <Container className="mt-4">
            <Card className="shadow border-0 rounded-4">
                <Card.Header>
                    <h5 className="fw-bold">Editar Producto</h5>
                </Card.Header>
                <Card.Body>
                    <ProductForm 
                        initialData={product}
                        onSubmit={handleUpdate}
                        buttonText="Actualizar Producto"
                    />
                </Card.Body>
            </Card>
        </Container>
    );
}