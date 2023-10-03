import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './ui/layout/components/navbar/navbar.component';
import { HeaderComponent } from './ui/layout/components/header/header.component';

const routes: Routes = [
  {path:"navbar",component:NavbarComponent},
  {path:"header",component:HeaderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
