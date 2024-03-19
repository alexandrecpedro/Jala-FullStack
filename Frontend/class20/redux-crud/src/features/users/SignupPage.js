import { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { createUser } from "./usersSlice";

export function SignupPage() {
  const users = useSelector((state) => state.users.users);
  const dispatch = useDispatch();

  const navigate = useNavigate();

  const nameRef = useRef(null);
  const emailRef = useRef(null);
  const phoneRef = useRef(null);
  const passwordRef = useRef(null);

  function handleSubmit(event) {
    event.preventDefault();
    const newUser = {
      name: nameRef.current.value,
      email: emailRef.current.value,
      phone: phoneRef.current.value,
      password: passwordRef.current.value,
    };

    const user = users.find((user) => user.email === newUser.email);

    if (user) {
      alert("User already registered!");
      event.target.reset();
      return;
    }

    dispatch(createUser(newUser));
    navigate("/");
  }

  return (
    <div>
      <h1>Redux CRUD</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="name"
          required
          ref={nameRef}
        />
        <input
          type="email"
          name="email"
          placeholder="email"
          required
          ref={emailRef}
        />
        <input
          type="text"
          name="phone"
          placeholder="phone"
          required
          ref={phoneRef}
        />
        <input
          type="password"
          name="password"
          placeholder="password"
          required
          ref={passwordRef}
        />
        <button type="submit">Login</button>
      </form>
      <Link to="/signup">Do you already have an account? Log in!</Link>
    </div>
  );
}
