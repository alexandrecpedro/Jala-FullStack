// button.spec.tsx
import renderer from 'react-test-renderer'
import Button from '../../components/Button';

function toJson(component: renderer.ReactTestRenderer) {
  const result = component.toJSON()
  console.warn(result)
  expect(result).toBeDefined()
  expect(result).not.toBeInstanceOf(Array)
  return result as renderer.ReactTestRendererJSON
}

test('Button component', () => {
    const component = renderer.create(<Button onClick={() => {}} text="Click me" />);   
    const tree = toJson(component)
    expect(tree).toMatchSnapshot()
    expect(tree.type).toBe('button')
});

test('Button component', () => {
    const component = renderer.create(<Button onClick={() => {}} text="Click me" />);   
    const tree = toJson(component)
    tree.props.onClick()
    expect(tree.props['aria-label']).toBe('Click me')
});

