const worker = new Worker("./service-worker.js");

if ("serviceWorker" in navigator) {
  navigator.serviceWorker
    .register(worker)
    .then((registration) => {
      console.log("Service Worker registrado com sucesso:", registration);
    })
    .catch((error) => {
      console.error("Erro ao registrar o Service Worker:", error);
    });
}
