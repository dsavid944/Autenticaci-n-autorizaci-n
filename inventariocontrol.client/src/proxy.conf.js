const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:5001';

const PROXY_CONFIG = [
  {
    context: [
      "/api/Usuarios",
      "/api/TiposDeEquipo",
      "/api/EstadosDeEquipo",
      "/api/Marcas",
      "/api/Inventarios"
    ],
    target,
    secure: false,
    changeOrigin: true
  }
]

module.exports = PROXY_CONFIG;
