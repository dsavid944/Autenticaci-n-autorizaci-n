import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventarioService {
  private apiUrl = 'http://localhost:5000/api/inventarios';

  constructor(private http: HttpClient) {}

  obtenerInventarios(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  crearInventario(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  actualizarInventario(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  eliminarInventario(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
