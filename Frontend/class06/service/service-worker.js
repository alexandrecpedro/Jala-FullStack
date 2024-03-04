const CACHE_NAME = "my-cache-v1";
const urlsToCache = [
  "",
  "index.html",
  "styles.css",
  "images/image1.jpg",
  "images/image2.jpg",
];

self.addEventListener("install", (event) => {
  event.waitUntil(
    caches.open(CACHE_NAME).then((cache) => cache.addAll(urlsToCache))
  );
});

self.addEventListener("fetch", (event) => {
  event.respondWith(
    caches
      .match(event.request)
      .then((response) => response || fetch(event.request))
  );
});
