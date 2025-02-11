import { Navigate } from 'react-router-dom';
import authStore from "../store/store.js";
import {toast} from "react-toastify"; // Импортируйте ваш хранилище аутентификации

const ProtectedRoute = ({ element }) => {
    const redirect = () => {
        toast.info("Please log in first", {toastId: "LogInRequired"});
        return <Navigate to="/signin" />;
    }
    return authStore.isAuthenticated ? element : redirect();
};

export default ProtectedRoute;