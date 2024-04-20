import  { useDebugValue, useState } from 'react';

const DebugValueComponent = () => {
    const [count, setCount] = useState(0);

    // Usando o hook useDebugValue para exibir o valor do contador no DevTools
    useDebugValue(count);

    const increment = () => {
        setCount(prevCount => prevCount + 1);
    };

    return (
        <div>
            <h1>Contador: {count}</h1>
            <button onClick={increment}>Incrementar</button>
        </div>
    );
};

export default DebugValueComponent; 


