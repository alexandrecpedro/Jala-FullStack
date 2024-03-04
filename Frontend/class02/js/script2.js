let list = document.querySelector("#api-tasks");

async function tarefas() {
  let url = `https://jsonplaceholder.typicode.com/todos/`;

  let resposta = await fetch(url);

  let arrayTarefas = await resposta.json();

  arrayTarefas.forEach((tarefa) => {
    if (tarefa.completed === true) {
      list.innerHTML += `<div class="task"><h2>${tarefa.id}.</h2> <del>${tarefa.title}</del></h2></div>`;
    } else {
      list.innerHTML += `<div class="task"><h2>${tarefa.id}.</h2> <p>${tarefa.title}</p></div>`;
    }
  });
}

tarefas();

const backToHome = () => {
  window.location.href = "index.html";
};
