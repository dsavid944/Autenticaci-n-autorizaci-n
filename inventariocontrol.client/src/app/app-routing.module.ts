import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
/* import { TipoDeEquipoComponent } from './components/tipoDeEquipo/tipoDeEquipo.component';
import { EstadoDeEquipoComponent } from './components/estadoDeEquipo/estadoDeEquipo.component';
import { MarcaComponent } from './components/marca/marca.component'; */
import { InventarioComponent } from './components/inventario/inventario.component';
/* import { UsuarioComponent } from './components/usuario/usuario.component'; */
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
/*   { path: 'tipos-de-equipo', component: TipoDeEquipoComponent, canActivate: [AuthGuard], data: { role: 'administrador' } },
  { path: 'estados-de-equipo', component: EstadoDeEquipoComponent, canActivate: [AuthGuard], data: { role: 'administrador' } }, */
/*   { path: 'marcas', component: MarcaComponent, canActivate: [AuthGuard], data: { role: 'administrador' } }, */
  { path: 'inventarios', component: InventarioComponent, canActivate: [AuthGuard] },
/*   { path: 'usuarios', component: UsuarioComponent, canActivate: [AuthGuard], data: { role: 'administrador' } }, */
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
