import { useCallback, useState } from 'react';

const CallBackComponent = () => {
    const [message, setMessage] = useState('');
    const [count, setCount] = useState(0);

    const handleClick = useCallback(() => {
        setMessage(`Button clicked ${count} times!`);
        setCount(count => count + 1);
    }, [count]);

    return (
        <div>
            <button onClick={handleClick}>Click here</button>
            <p>{message}</p>
        </div>
    );
};

export default CallBackComponent;

