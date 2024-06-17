import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) {}

  obtenerUsuarios(): Observable<any> {
    return this.http.get(`${environment.apiUrl}usuarios`);
  }

  crearUsuario(data: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}usuarios`, data);
  }

  actualizarUsuario(id: number, data: any): Observable<any> {
    return this.http.put(`${environment.apiUrl}usuarios/${id}`, data);
  }

  eliminarUsuario(id: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}usuarios/${id}`);
  }
}
