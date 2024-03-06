# Pesquisa

## Problema

Criar variável global em projetos React. Para testes foi utilizada a variável `pokemons` e três projetos React: vite, cra e o fornecido pelo professor.

### Possíveis soluções:

**1.**

**Proposta:** A primeira solução que vem em mente é acessar o objeto global `window` e acrescentar uma propriedade: `windows.pokemons = pokemons`, essa propriedade pode ser acessada de qualquer lugar, ou acessando a propriedade `windows.pokemons` ou invocando diretamente `pokemons` como variável global.

**Resultado:** A solução funcionou para os três projetos.

**2.**

**Proposta:** Criar variável com `var` na raíz do index.js para acrescentá-la no contexto global.

**Resultado:** A variável não foi acrescentada no objeto global `window`. Pesquisas no stackoverflow e na documentação indicam que os arquivos js tratados como ES Modules não são incorporados no contexto global, logo, usar var acrescentaria a variável apenas no contexto local do ES Module em questão. Pesquisa com CommonJS necessitaria os projetos sejam convertidos para CommonJS. O resultado foi o mesmo para os três projetos.

3.

**Proposta:** Criar variável sem usar `let`, `var` ou `const` para usufruir do mecanismo de hoisting para acrescentá-la no contexto global.

**Resultado:** A inclusão automática do strict mode impediu a variável de ser declaradas desse modo. Tentativas de retirar o strict mode incluido diferentes plugins e configurações não tiveram sucesso. Os plugins não funcionaram, e as configurações só eram compatíveis com CommonJS.

Discussões no stackoverflow indicam que o strict mode se torna necessário por causa da natureza do ES Modules, pesquisa com CommonJS necessitaria os projetos sejam convertidos para CommonJS. O resultado foi o mesmo para os três projetos.

Mesmo com o ambiente de desenvolvimento quebrando, foi possível realizar a build dos projetos (no projeto cra, foi necessário adicionar `/* eslint-disable */` no topo do index.js). Um arquivo `usestrict-remove.js` foi adicionado para acessar os arquivos de build e remover os `"use strict";`.

O arquivo foi incluido no processo de build nos packages.json com `&& node usestrict-remove`. Nos projetos cra e o fornecido pelo professor os arquivos de build funcionaram sem erros e a variável foi acrescentada no contexto global.

No projeto vite esse método não funcionou, uma vez que o strict mode não foi incluindo com `"use strict";`. Pesquisa adicional é necessária para entender o mecanismo. Muito provavelmente porque não tem um index.js mas um main.jsx. Trocar o tipo do arquivo pode ser necessário. Uma forma de resolver foi inicializar a variável primeiro no index.html com `<script> var pokemons </script>`.

## Fontes:

https://github.com/hacksysteam/webpack5-remove-use-strict-plugin

https://stackoverflow.com/questions/55642816/how-to-disable-strict-mode-in-webpack

https://babeljs.io/docs/babel-plugin-transform-strict-mode

https://stackoverflow.com/questions/33821312/how-to-remove-global-use-strict-added-by-babel

https://stackoverflow.com/questions/38664229/disable-babel-strict-mode-from-webpack-config-js

https://github.com/YDSS/webpack-remove-strict-mode-plugin

https://github.com/YDSS/webpack-remove-strict-mode-plugin/blob/master/index.js

https://www.npmjs.com/package/babel-plugin-transform-remove-strict-mode

https://github.com/hendrysadrak/remove-strict-webpack-plugin

https://www.jsdelivr.com/package/npm/webpack-remove-strict-mode-plugin

https://snyk.io/advisor/npm-package/webpack-remove-strict-mode-plugin

https://www.npmjs.com/package/remove-strict-webpack-plugin
