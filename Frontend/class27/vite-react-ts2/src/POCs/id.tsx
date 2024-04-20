import React,{ useId } from 'react';

const IdExample: React.FC = () => {
    const [id] = useId();

    return (
        <div id={id}>
            <label htmlFor={id}>Input:</label>
            <input type="text" id={id} />
        </div>
    );
};

export default IdExample;




