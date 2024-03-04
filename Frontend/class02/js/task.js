const resetForm = () => {
  const form = document.getElementById("create-new-task");
  form.reset();
};

const setValueOfCreateDateInput = () => {
  const createDateInput = document.getElementById("create-date");
  const actualDate = new Date().toISOString().split("T")[0];
  createDateInput.value = actualDate;
};
setValueOfCreateDateInput();

function uuidv4() {
  return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}

const showToast = (message) => {
  const toast = document.getElementById("toast");
  toast.setAttribute("class", "active");
  toast.innerText = message;
  setTimeout(() => {
    toast.removeAttribute("class", "active");
  }, 3000);
};

const handleCreateNewTask = (e) => {
  e.preventDefault();

  // get values of inputs
  const createDate = document.getElementById("create-date").value;
  const limitDate = document.getElementById("limit-date").value;
  const description = document.getElementById("description").value;

  if (description.length < 10) {
    showToast("A descrição deve ter mais que 10 caracteres");
    return;
  }

  if (limitDate < createDate) {
    showToast("A data limite tem que ser maior que a data criada");
    return;
  }

  const list = document.getElementById("task-list");
  const newTask = document.createElement("div");
  const id = uuidv4();
  const checkBoxId = uuidv4();

  newTask.setAttribute("class", "task");
  newTask.setAttribute("id", id);

  newTask.innerHTML = `
    <div class="content">
      <input type="checkbox" onclick="handleToggleTask('${id}', '${checkBoxId}')" id="${checkBoxId}" /> 
      <div class="infos">
        <h2>${description}</h2>
        <div class="dates">
          <sub class="create-date">${createDate.replace(/-/g, "/")}</sub>
          <sub class="limit-date">${limitDate.replace(/-/g, "/")}</sub>
        </div>
      </div>
    </div>
    <div class="deleteIcon" onClick="handleDelete('${id}')">✖</div>
  `;

  list.append(newTask);
  showToast("Tarefa adicionada com sucesso!");
  resetForm();
  setValueOfCreateDateInput();
};

const handleToggleTask = (id, checkBoxId) => {
  const isChecked = document.getElementById(checkBoxId).checked;
  const task = document.getElementById(id);

  if (isChecked) {
    task.classList.remove("pending");
    task.classList.add("done");
  } else {
    task.classList.remove("done");
    task.classList.add("pending");
  }
};
