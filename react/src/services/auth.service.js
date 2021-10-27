import axios from "axios";

const API_URL = "https://localhost:44350/api/";

const register = (username, email, password) => {
  return axios.post(API_URL + "signup", {
    username,
    email,
    password,
  });
};

const login = (user) => {
    const u='Tenant/GetTenantByEmailAndTz/'+user.email+'/'+user.tz
  return axios
    .get(API_URL + u)
    .then((response) => {
      if (response.data) {
        localStorage.setItem("user", JSON.stringify(response.data));
      }
      return response.data;
    });
};

const logout = () => {
  localStorage.removeItem("user");
};

export default {
  register,
  login,
  logout,
};