import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:FooterComponent}
    ])
  ],
  exports:[
    FooterComponent
  ]
})
export class FooterModule { }
