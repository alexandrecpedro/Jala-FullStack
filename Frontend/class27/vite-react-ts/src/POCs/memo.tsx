import React, { useMemo } from 'react'

const MemoComponent: React.FC = () => {
    const expensiveCalculation = useMemo(() => {
        // Perform expensive calculation here
        // This calculation will only be re-executed if the dependencies change

        return ((42 ** 32 + 43) ** 2).toString()
    }, [])

    return (
        <div>
            <h1>Memo Component</h1>
            <p>Expensive Calculation: { expensiveCalculation }</p>
        </div>
    )
}

export default MemoComponent