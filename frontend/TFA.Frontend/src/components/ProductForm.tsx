import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { Button, Col, Form, Row } from "react-bootstrap";
import { getCategories } from "../api/categoryService";
import { getSuppliers } from "../api/supplierService";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const schema = yup.object({

    productName: yup
        .string()
        .required("Nombre requerido"),
    
    categoryID: yup
        .string()
        .required("Seleccione una categoria"),
    
    supplierID: yup
        .string()
        .required("Seleccione un proveedor"),

    quantityPerUnit: yup
        .number()
        .typeError("Debe ser numerico")
        .required("Campo obligatorio")
        .positive("Debe ser mayor a 0"),

    unitPrice: yup
        .number()
        .typeError("Debe ser numerico")
        .required("Campo obligatorio")
        .positive("Debe ser mayor a 0"),

    unitsInStock: yup
        .number()
        .typeError("Debe ser numerico")
        .required("Campo obligatorio")
        .positive("Debe ser mayor a 0"),

    unitsOnOrder: yup
        .number()
        .typeError("Debe ser numerico")
        .required("Campo obligatorio")
        .positive("Debe ser mayor a 0"),

    reorderLevel: yup
        .number()
        .typeError("Debe ser numerico")
        .required("Campo obligatorio")
        .positive("Debe ser mayor a 0"),

    discontinued: yup
        .boolean()
        .required("Campo obligatorio")
});

interface ProductFormProps {
    onSubmit: (data: any) => Promise<void>;
    initialData?: any;
    buttonText?: string
}

export default function ProductForm({onSubmit, initialData, buttonText="Guardar"} : ProductFormProps) {
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors }
    } = useForm({
        resolver: yupResolver(schema),
        defaultValues: initialData
    });

    const[categories, setCategories] = useState<any[]>([]);
    const[suppliers, setSuppliers] = useState<any[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        const loadFormData = async() => {
            const [categoriesData, suppliersData] = await Promise.all([
                getCategories(),
                getSuppliers()
            ]);

            setCategories(categoriesData || []);
            setSuppliers(suppliersData || []);
            if (initialData) {
                reset({
                    ...initialData,
                    categoryID: initialData.categoryID ? String(initialData.categoryID) : "",
                    supplierID: initialData.supplierID ? String(initialData.supplierID) : "",
                });
            }
        };

        loadFormData();
    }, [initialData, reset]);

    return (
        <Form onSubmit={handleSubmit(onSubmit)}>
            <Row>
                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Nombre Producto</Form.Label>
                        <Form.Control
                            type="text"
                            {...register("productName")}
                        />
                        <small className="text-danger">
                            {String(errors.productName?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>

                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Categoria</Form.Label>

                        <Form.Select {...register("categoryID")} aria-label="Selecciona una opción">
                            <option></option>
                            {categories.map((p: any) => (
                                <option key={p.categoryID} value={p.categoryID}>{p.categoryName}</option>
                            ))}
                        </Form.Select>

                        <small className="text-danger">
                            {String(errors.categoryID?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>
                
                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Proveedor</Form.Label>

                        <Form.Select {...register("supplierID")} aria-label="Selecciona una opción">
                            <option></option>
                            {suppliers.map((p: any) => (
                                <option key={p.supplierID} value={p.supplierID}>{p.companyName}</option>
                            ))}
                        </Form.Select>

                        <small className="text-danger">
                            {String(errors.supplierID?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>
                
                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Cantidad Por Unidad</Form.Label>

                        <Form.Control
                            type="number"
                            {...register("quantityPerUnit")}
                        />

                        <small className="text-danger">
                            {String(errors.quantityPerUnit?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>

                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Precio Unitario</Form.Label>

                        <Form.Control
                            type="number"
                            step="0.01"
                            {...register("unitPrice")}
                        />

                        <small className="text-danger">
                            {String(errors.unitPrice?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>

                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Existencias</Form.Label>

                        <Form.Control
                            type="number"
                            {...register("unitsInStock")}
                        />

                        <small className="text-danger">
                            {String(errors.unitsInStock?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>
            </Row>

            <Row>
                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>En Pedido</Form.Label>

                        <Form.Control
                            type="number"
                            {...register("unitsOnOrder")}
                        />

                        <small className="text-danger">
                            {String(errors.unitsOnOrder?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>
                <Col md={4}>
                    <Form.Group className="mb-3">
                        <Form.Label>Nivel Reorden</Form.Label>

                        <Form.Control
                            type="number"
                            {...register("reorderLevel")}
                        />

                        <small className="text-danger">
                            {String(errors.reorderLevel?.message ?? "")}
                        </small>
                    </Form.Group>
                </Col>

                <Col md={4}>
                    <Form.Group className="mb-3 mt-4">

                        <Form.Check
                            type="checkbox"
                            label="Descontinuado"
                            {...register("discontinued")}
                        />

                    </Form.Group>
                </Col>
            </Row>
            <Row className="mt-4">
                <Col className="d-flex justify-content-center">
                    <Button
                        variant="primary"
                        type="submit"
                        >
                        {buttonText}
                    </Button>
                    <Button
                        variant="danger"
                        onClick={() => navigate("/products")}
                    >
                        Cancelar
                    </Button>
                </Col>
            </Row>

        </Form>
    );
}