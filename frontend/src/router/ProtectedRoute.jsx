import { Navigate } from 'react-router-dom';
import authStore from "../store/store.js"; // Импортируйте ваш хранилище аутентификации

const ProtectedRoute = ({ element }) => {
    return authStore.isAuthenticated ? element : <Navigate to="/signin" />;
};

export default ProtectedRoute;