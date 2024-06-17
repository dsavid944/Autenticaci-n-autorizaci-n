import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipoDeEquipoService {
  private apiUrl = 'http://localhost:5000/api/tiposdeequipos';

  constructor(private http: HttpClient) {}

  obtenerTiposDeEquipo(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  crearTipoDeEquipo(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  actualizarTipoDeEquipo(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  eliminarTipoDeEquipo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
