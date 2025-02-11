import {observable, action, makeObservable} from 'mobx';
import {toast} from "react-toastify";

class AuthStore {
    isAuthenticated = !localStorage.getItem('token');
    login = async (token) => {
        toast.info("You have successfully logged in", {toastId: "LogInInfo"})
        this.isAuthenticated = true;
        localStorage.setItem('token', token);
        location.reload();
    }
    logout = () => {
        toast.info("You have successfully logged out", {toastId: "LogOutInfo"})
        localStorage.removeItem('token');
        this.isAuthenticated = false;
        location.reload();
    }
    constructor() { makeObservable(this, {
        isAuthenticated: observable,
        login: action,
        logout: action
    })
    }
}

const authStore = new AuthStore();

export default authStore;