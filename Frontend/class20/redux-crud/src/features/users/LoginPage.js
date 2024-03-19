import { useRef } from "react";
import { useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";

export function LoginPage() {
  const users = useSelector((state) => state.users.users);

  const emailRef = useRef(null);
  const passwordRef = useRef(null);

  const navigate = useNavigate();

  function handleSubmit(event) {
    event.preventDefault();
    const user = users.find((user) => user.email === emailRef.current.value);

    if (user && user.password === passwordRef.current.value) {
      navigate(`user/${user.id}`);
      return;
    }

    alert("Invalid email or password!");
    event.target.reset();
  }

  return (
    <div>
      <h1>Redux CRUD</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          name="email"
          placeholder="email"
          required
          ref={emailRef}
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
      <Link to="/signup">Don't have an account? Sign up!</Link>
    </div>
  );
}
