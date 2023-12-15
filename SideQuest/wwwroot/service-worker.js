self.addEventListener('install', async event => {
    self.skipWaiting();
});

self.addEventListener('fetch', event => {
    return null;
});
