import React from 'react';
import { render, fireEvent } from '@testing-library/react';
import Button from './Button';

describe('Button', () => {
  it('renders properly', () => {
    const text = 'Click me';
    const { getByText, getByRole } = render(<Button onClick={() => {}} text={text} />);

    expect(getByText(text)).toBeInTheDocument();
    expect(getByRole('button')).toHaveAttribute('type', 'button');
    expect(getByRole('button')).toHaveAttribute('aria-label', text);
  });

  it('triggers onClick when clicked', () => {
    const text = 'Click me';
    const onClick = jest.fn();
    const { getByText } = render(<Button onClick={onClick} text={text} />);

    fireEvent.click(getByText(text));
    expect(onClick).toHaveBeenCalledTimes(1);
  });
});