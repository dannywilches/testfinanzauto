import { useState } from "react";
import { login as loginApi } from "../api/authService";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/useAuth";
import { Button, Card, Col, Container, Form, Row } from "react-bootstrap";

export default function LoginPage() {
    const navigate = useNavigate();
    const auth = useAuth();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async () => {
        try {
            const response = await loginApi(
                username,
                password
            );

            auth.login(response.token);
            navigate("/products");
        } 
        catch {
            alert("Credenciales inválidas");
        }
    };

  return (
    
    <Container className="d-flex align-items-center justify-content-center vh-100 bg-light">
      <Row className="w-100 justify-content-center">
        <Col md={6} lg={4}>
          <Card className="shadow border-0 p-4 rounded-4">
            <Card.Body>
              <h2 className="text-center mb-4 fw-bold text-dark">Iniciar Sesión</h2>
              
              <Form>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                  <Form.Label className="text-muted fw-semibold">Usuario</Form.Label>
                  <Form.Control 
                    type="text" 
                    placeholder="ejemplo@correo.com" 
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    required 
                  />
                </Form.Group>

                <Form.Group className="mb-4" controlId="formBasicPassword">
                  <Form.Label className="text-muted fw-semibold">Contraseña</Form.Label>
                  <Form.Control 
                    type="password" 
                    placeholder="••••••••" 
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required 
                  />
                </Form.Group>

                <Button onClick={handleLogin} variant="dark" className="w-100 py-2 fw-bold btn-dark">
                  Ingresar
                </Button>
              </Form>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}