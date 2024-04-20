import React, { useContext } from 'react';

// Create a context
const MyContext = React.createContext<string>('');

// Component that consumes the context
const MyComponent: React.FC = () => {
    // Use the useContext hook to access the context value
    const contextValue = useContext(MyContext);

    return (
        <div>
            Context value: {contextValue}
        </div>
    );
};

// Component that provides the context value
const PseudoApp: React.FC = () => {
    return (
        <MyContext.Provider value="Provided context value">
            <MyComponent />
        </MyContext.Provider>
    );
};

export default PseudoApp;


