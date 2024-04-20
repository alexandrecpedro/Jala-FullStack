import LoginForm from "../../components/LoginForm";

const Home: React.FC = () => {
  return (
    <main className="main">
      <h2>Welcome</h2>
      <h3>Please fill the information to receive job offerings</h3>
      <LoginForm />
    </main>
  );
}

export default Home
