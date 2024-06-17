export interface Inventario {
  id: number;
  serial: string;
  modelo: string;
  descripcion: string;
  fotoUrl: string;
  color: string;
  fechaCompra: Date;
  precio: number;
  usuarioId: number;
  marcaId: number;
  estadoDeEquipoId: number;
  tipoDeEquipoId: number;
  usuario?: any;
  marca?: any;
  estadoDeEquipo?: any;
  tipoDeEquipo?: any;
}
