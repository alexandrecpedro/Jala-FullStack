
import { createContext, Dispatch, FC, ReactNode, SetStateAction, useContext, useMemo, useState } from 'react';
import { IUser } from '../interfaces/IUser';

// Define the shape of the user context
interface IUserContext {
    user: IUser | null;
    setUser: Dispatch<SetStateAction<IUser | null>>
}

// Creates the user context
const UserContext = createContext<IUserContext>({ user: null, setUser: () => { } });

// Creates a custom hook to access the user context
export const useUserContext = (): IUserContext => {
    const context = useContext<IUserContext>(UserContext);

    if (!context) {
        throw new Error('useUserContext must be used within a UserContextProvider!');
    }

    return context;
};

// Creates the user context provider component
export const UserContextProvider: FC<{ children: ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<IUser | null>(null)
    const memorizedUser = useMemo(() => ({ user, setUser }), [user, setUser])

    return (
        <UserContext.Provider value={memorizedUser}>
            {children}
        </UserContext.Provider>
    );
};

// Export the user context
export default UserContext;
