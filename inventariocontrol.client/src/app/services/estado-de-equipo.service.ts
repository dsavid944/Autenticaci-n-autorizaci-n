import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstadoDeEquipoService {

  constructor(private http: HttpClient) {}

  obtenerEstadosDeEquipo(): Observable<any> {
    return this.http.get(`${environment.apiUrl}estadosdeequipos`);
  }

  crearEstadoDeEquipo(data: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}estadosdeequipos`, data);
  }

  actualizarEstadoDeEquipo(id: number, data: any): Observable<any> {
    return this.http.put(`${environment.apiUrl}estadosdeequipos/${id}`, data);
  }

  eliminarEstadoDeEquipo(id: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}estadosdeequipos/${id}`);
  }
}
