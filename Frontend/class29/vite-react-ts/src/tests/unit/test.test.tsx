import { expect, test } from 'vitest';

function sum(a: number, b: number) {
  return a + b;
}

test('adds 1 + 2 to equal 3', () => {
  expect(sum(1, 2)).toBe(3);
});

test('adds 5 + 10 to equal 15', () => {
  expect(sum(5, 10)).toBe(15);
});