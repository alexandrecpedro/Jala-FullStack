// works fine
const s: string | null = 'string'
const t: string = s!
console.log(t)


////////////////////////////////////////////////////////////



//will blow up
const a: string | null = null
const b: string = a!
console.log(b)