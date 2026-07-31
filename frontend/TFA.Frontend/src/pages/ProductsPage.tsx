import { useEffect, useState } from "react";
import { deleteProduct, getProducts } from "../api/productService";
import { Form, Button, Card, Container, Table, Row, Col, Modal } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { Pagination } from "react-bootstrap";
import { useDebounce } from "use-debounce";

export default function ProductsPage() {
    
    const [products, setProducts] = useState([]);
    const navigate = useNavigate();
    
    const [page, setPage] = useState(1);
    const [pageSize] = useState(10);
    const [search, setSearch] = useState("");
    const [totalPages, setTotalPages] = useState(0);
    const [debouncedSearch] = useDebounce(search, 500);

    useEffect(() => {
        loadProducts();

    }, [page, debouncedSearch]);

    const loadProducts = async () => {
        const data = await getProducts(page, pageSize, debouncedSearch);
        setProducts(data.items);
        setTotalPages(data.totalPages)
        console.log(data.items);
    };

    const editProduct = async (id:string) => {
        navigate(`/products/edit/${id}`);
    };

    const [showDeleteModal, setShowDeleteModal] = useState(false);

    const [selectedProductId, setSelectedProductId] = useState<string | null>(null);

    const openDeleteModal = ( productId: string ) => {
        setSelectedProductId(productId);
        setShowDeleteModal(true);
    };
    
    const confirmDelete = async () => {
        if (!selectedProductId) return;
        try {
            await deleteProduct(selectedProductId);
            setShowDeleteModal(false);
            loadProducts();
        }
        catch {
            alert("Error eliminando producto");
        }
    };

    const items = [];
    const startPage = Math.max(1, page - 2);
    const endPage = Math.min(totalPages, page + 2);

    for (
        let number = startPage;
        number <= endPage;
        number++
    ) {

        items.push(
            <Pagination.Item
                key={number}
                active={number === page}
                onClick={() => setPage(number)}
            >
                {number}
            </Pagination.Item>
        );
    }


    return (
        <Container className="mt-4">
            <Card className="shadow border-0 rounded-4">
                <Card.Header>
                    <Row>
                        <Col>
                            <h5 className="fw-bold">Editar Producto</h5>
                        </Col>
                        <Col>
                            <Form.Control
                                placeholder="Buscar..."
                                value={search}
                                onChange={(e) => setSearch(e.target.value)}
                            />
                        </Col>
                    </Row>

                </Card.Header>
                <Card.Body>
                    <Table
                        striped
                        bordered
                        hover
                        responsive
                    >

                        <thead>
                            <tr>
                                <th>Producto</th>
                                <th>Categoria</th>
                                <th>Precio Unitario</th>
                                <th>Unidades en Stock</th>
                                <th>Unidades Pedidas</th>
                                <th>Cantidad por Unidad</th>
                                <th>Proveedor</th>
                                <th>Acciones</th>
                                <th>Eliminar</th>
                            </tr>
                        </thead>

                        <tbody>
                            {products.map((p: any) => (
                                <tr key={p.productID}>
                                    <td>{p.productName}</td>
                                    <td>{p.category}</td>
                                    <td>{p.unitPrice}</td>
                                    <td>{p.unitsInStock}</td>
                                    <td>{p.unitsOnOrder}</td>
                                    <td>{p.quantityPerUnit}</td>
                                    <td>{p.supplier}</td>
                                    <td><Button onClick={() => editProduct(p.productID)}>Editar</Button></td>
                                    <td><Button variant="danger" onClick={() => openDeleteModal(p.productID)}>Eliminar</Button></td>
                                </tr>
                            ))}
                        </tbody>

                    </Table>
                    <Pagination className="d-flex justify-content-end">

                        <Pagination.First
                            disabled={page === 1}
                            onClick={() => setPage(1)}
                        />

                        <Pagination.Prev
                            disabled={page === 1}
                            onClick={() =>
                                setPage(page - 1)
                            }
                        />

                        {items}

                        <Pagination.Next
                            disabled={page === totalPages}
                            onClick={() =>
                                setPage(page + 1)
                            }
                        />

                        <Pagination.Last
                            disabled={page === totalPages}
                            onClick={() =>
                                setPage(totalPages)
                            }
                        />

                    </Pagination>
                </Card.Body>
            </Card>
            <Modal
                show={showDeleteModal}
                onHide={() =>
                    setShowDeleteModal(false)
                }
            >
                <Modal.Header closeButton>
                    <Modal.Title>
                        Confirmar eliminación
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    ¿Está seguro de eliminar este
                    producto?
                </Modal.Body>
                <Modal.Footer>
                    <Button
                        variant="secondary"
                        onClick={() =>
                            setShowDeleteModal(false)
                        }
                    >
                        Cancelar
                    </Button>
                    <Button
                        variant="danger"
                        onClick={confirmDelete}
                    >
                        Eliminar
                    </Button>
                </Modal.Footer>
            </Modal>
        </Container>
    );
}