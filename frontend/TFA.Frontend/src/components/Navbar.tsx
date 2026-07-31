import { Navbar, Container, Nav, Button } from "react-bootstrap"
import { Link, useNavigate, type NavigateFunction } from "react-router-dom";


const logout = (navigate: NavigateFunction) => {
    localStorage.removeItem("token");
    navigate("/");
};

export default function NavBar () {
    const navigate = useNavigate();
    return (
         <Navbar bg="dark" variant="dark" expand="lg">
            <Container>
                <Navbar.Brand as={Link} to="/products">Productos App</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link as={Link} to="/products/create">Nuevo Producto</Nav.Link>
                    </Nav>
                    <Nav className="my-2 my-sm-0">
                        <Button className="btn-sm btn-dark" variant="outline-light" onClick={() => logout(navigate)}>Cerrar Sesion</Button>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}