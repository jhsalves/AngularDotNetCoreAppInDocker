import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent } from './components/client/add-client/add-client.component';
import { ListClientComponent } from './components/client/list-client/list-client.component';
import { DetailsClientComponent } from './components/client/details-client/details-client.component';

const routes: Routes = [
  { path: '', redirectTo: '/clients', pathMatch: 'full' },
  { path: 'clients/:id', component: DetailsClientComponent },
  { path: 'clients', component: ListClientComponent },
  { path: 'clients-add', component: AddClientComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
