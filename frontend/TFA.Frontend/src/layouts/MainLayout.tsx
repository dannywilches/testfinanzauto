import { Outlet } from "react-router-dom";
import NavBar from "../components/Navbar";

export default function MainLayout() {

    return (
        <>
            <NavBar />
            <div className="container mt-4">
                <Outlet />
            </div>
        </>
    );
}