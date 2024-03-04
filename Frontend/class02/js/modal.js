const handleShowConfirmDeleteModal = (id) => {
  const modalOverlay = document.getElementsByClassName("modal-overlay")[0];
  modalOverlay.classList.add("active");

  const buttonConfirm = document.getElementsByClassName("confirm-delete")[0];
  buttonConfirm.setAttribute("onClick", `handleRemoveOfBody('${id}')`);
};

const handleCloseConfirmDeleteModal = () => {
  const modalOverlay = document.getElementsByClassName("modal-overlay")[0];
  modalOverlay.classList.remove("active");
};

const showToast2 = (message) => {
  const toast = document.getElementById("toast");
  toast.setAttribute("class", "active");
  toast.innerText = message;
  setTimeout(() => {
    toast.removeAttribute("class", "active");
  }, 3000);
};

const handleRemoveOfBody = (id) => {
  const task = document.getElementById(id);
  task.remove();
  handleCloseConfirmDeleteModal();
  showToast2("Tarefa excluída com sucesso!");
};

const handleDelete = (id) => {
  handleShowConfirmDeleteModal(id);
};
